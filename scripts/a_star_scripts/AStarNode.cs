using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class AStarNode {
    public Vector3Int tile;
    public float estimatedTotalFCost;

    private int costToEnter;
    private float heuristic;
    private Tilemap tilemap;

    public AStarNode(int costToEnter, Vector3Int tile, Vector3 destination, Tilemap tilemap) {
        this.costToEnter = costToEnter;
        this.tile = tile;
        this.tilemap = tilemap;

        Vector2 position = tilemap.CellToWorld(tile);

        heuristic = Vector2.Distance(position, destination);
        estimatedTotalFCost = heuristic + costToEnter;
    }

    public List<AStarNode> GetNeighbors(Vector3 destination) {
        List<AStarNode> neighbors = new List<AStarNode>();

        // Cardinal directions
        Vector3Int[] directions = new Vector3Int[]
        {
        new Vector3Int(tile.x + 1, tile.y, 0),  // East
        new Vector3Int(tile.x - 1, tile.y, 0),  // West
        new Vector3Int(tile.x, tile.y + 1, 0),  // North
        new Vector3Int(tile.x, tile.y - 1, 0),  // South
        new Vector3Int(tile.x + 1, tile.y + 1, 0),  // Northeast
        new Vector3Int(tile.x - 1, tile.y - 1, 0),  // Southwest
        new Vector3Int(tile.x + 1, tile.y - 1, 0),  // Southeast
        new Vector3Int(tile.x - 1, tile.y + 1, 0)   // Northwest
        };

        foreach (Vector3Int direction in directions) {
            if (IsNodeWalkable(direction)) {
                int costToNode = GetCostToEnter(direction);
                neighbors.Add(new AStarNode(costToNode, direction, destination, tilemap));
            }
        }

        return neighbors;
    }

    private bool IsNodeWalkable(Vector3Int node) {
        TileBase newTile = tilemap.GetTile(node);

        if (newTile == null) return false;

        if (tilemap.HasTile(node)) {
            Collider2D collider = tilemap.GetComponent<TilemapCollider2D>();
            if (collider != null) {
                Bounds tileBounds = tilemap.GetBoundsLocal(node);
                Collider2D[] hitColliders = Physics2D.OverlapBoxAll(tileBounds.center, tileBounds.size, 0);
                foreach (var hitCollider in hitColliders) {
                    if (hitCollider.isTrigger == false) // Non-trigger colliders block movement
                        return false;
                }
            }
        }
        return true;
    }

    private int GetCostToEnter(Vector3Int node) {
        // Costs for movement:
        // Diagonal: 14, Straight: 10
        int movementCost = (node.x != tile.x && node.y != tile.y) ? 14 : 10;
        return costToEnter + movementCost;
    }

    public override bool Equals(object obj) {
        if (obj is AStarNode otherNode) {
            return tile == otherNode.tile; // Compare tile positions
        }
        return false;
    }

    public override int GetHashCode() {
        return tile.GetHashCode(); // Use tile's hash code
    }
}
