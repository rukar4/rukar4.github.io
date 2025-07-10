using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;


public class AStarPath {
    public List<Vector3> Path { get; private set; }

    private Vector3 start;
    private Vector3 goal;
    private Tilemap tilemap;

    public AStarPath(Vector3 start, Vector3 goal, Tilemap tilemap) {
        this.start = start;
        this.goal = goal;
        this.tilemap = tilemap;

        Debug.Log("Pathfinding from " + start + " to " + goal);
        Path = FindPath();
        foreach (Vector3 node in Path) {
            Debug.Log("Node: " + node);
        }
    }

    private List<Vector3> FindPath() {
        Vector3Int startTile = tilemap.WorldToCell(start);
        Vector3Int endTile = tilemap.WorldToCell(goal);

        // Keep track of which nodes have been visited / are in the fringe
        List<AStarNode> fringe = new List<AStarNode>();
        HashSet<Vector3Int> closedSet = new HashSet<Vector3Int>();

        // Start node
        AStarNode startNode = new AStarNode(0, startTile, goal, tilemap);
        fringe.Add(startNode);

        // Dictionary for tracking the path
        Dictionary<Vector3Int, AStarNode> cameFrom = new Dictionary<Vector3Int, AStarNode>();


        while (fringe.Count > 0) {
            AStarNode currNode = GetLowestFCost(fringe);

            if (currNode.tile == endTile) {
                return GetPath(cameFrom, currNode);
            }

            fringe.Remove(currNode);
            closedSet.Add(currNode.tile);

            foreach (AStarNode neighbor in currNode.GetNeighbors(endTile)) {
                if (closedSet.Contains(neighbor.tile)) {
                    continue;
                }

                if (!fringe.Exists(n  => n.tile == neighbor.tile)) {
                    fringe.Add(neighbor);
                    cameFrom[neighbor.tile] = currNode;
                }
            }
        }

        // Return an empty list if no paths are found
        return new List<Vector3>();
    }

    private AStarNode GetLowestFCost(List<AStarNode> fringe) {
        AStarNode bestNode = fringe[0];
        foreach (AStarNode node in fringe) {
            if (node.estimatedTotalFCost < bestNode.estimatedTotalFCost) {
                bestNode = node;
            }
        }
        return bestNode;
    }

    private List<Vector3> GetPath(Dictionary<Vector3Int , AStarNode> cameFrom, AStarNode currNode) {
        List<Vector3> path = new List<Vector3>();
        while (cameFrom.ContainsKey(currNode.tile)) {
            path.Add(tilemap.CellToWorld(currNode.tile));
            currNode = cameFrom[currNode.tile];
        }

        path.Add(tilemap.CellToWorld(currNode.tile));
        path.Reverse();

        PrintPathToConsole(path);

        return path;
    }

    private void PrintPathToConsole(List<Vector3> path) {
        if (path != null && path.Count > 0) {
            string pathString = "Path: ";
            foreach (Vector3 point in path) {
                pathString += $"({point.x}, {point.y}) -> ";
            }
            // Remove the last " -> "
            pathString = pathString.Substring(0, pathString.Length - 4);
            Debug.Log(pathString);
        }
        else {
            Debug.Log("No path found.");
        }
    }
}
