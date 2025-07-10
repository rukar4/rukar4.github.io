using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;


public class LinkAi : MonoBehaviour {
    private Rigidbody2D rb2D;
    private Animator animator;

    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float stoppingDistance = 0.2f;
    private List<Vector3> path;
    private int currentPathIndex = 1;

    private Vector2 movement;
    private Transform target;
    private AStarPath pathfinder;

    private Tilemap tilemap;

    // Start is called before the first frame update
    void Start() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        animator = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update() {
        // Stop at a certain distance from the player
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance) {
            if (path == null || currentPathIndex >= path.Count || Vector2.Distance(target.position, path[path.Count - 1]) > 0.5f) {
                pathfinder = new AStarPath(transform.position, target.position, tilemap);
                path = pathfinder.Path;
                currentPathIndex = 1;
            }

            if (path != null && currentPathIndex < path.Count) {
                Vector3 nextPosition = path[currentPathIndex];
                movement = (nextPosition - transform.position).normalized;

                if (Vector2.Distance(transform.position, nextPosition) < 0.2f) {
                    currentPathIndex++;
                }
            }
        }
        else {
            movement = Vector2.zero;
            path = null;
        }

        if (path == null || path.Count == 0)
            movement = Vector2.zero;
    }


    private void FixedUpdate() {
        if (movement != Vector2.zero) {
            animator.SetBool("isIdle", false);

            bool isEast = movement.x > 0;
            bool isNorth = movement.y > 0;
            bool isVertical = Mathf.Abs(movement.x) < Mathf.Abs(movement.y);

            animator.SetBool("north", isNorth && isVertical);
            animator.SetBool("south", !isNorth && movement.y != 0 && isVertical);

            animator.SetBool("east", isEast && !isVertical);
            animator.SetBool("west", !isEast && movement.x != 0 && !isVertical);

            rb2D.velocity = movement * speed;
        }
        else {
            bool isEast = movement.x > 0;
            bool isNorth = movement.y > 0;

            animator.SetBool("east", false);
            animator.SetBool("west", false);
            animator.SetBool("north", false);
            animator.SetBool("south", false);

            animator.SetBool("isIdle", true);
            rb2D.velocity = Vector2.zero;
        }
    }

    void OnDrawGizmos() {
        if (path != null) {
            Gizmos.color = Color.blue;
            for (int i = 0; i < path.Count - 1; i++) {
                Gizmos.DrawLine(path[i], path[i + 1]);
            }
        }
    }
}
