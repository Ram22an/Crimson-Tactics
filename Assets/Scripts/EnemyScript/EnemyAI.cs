using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IAI
{
    public Transform player;
    public Pathfinding pathfinding;
    public float speed = 2f;

    private bool isMoving = false;
    private Vector3 targetPosition;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned.");
        }
        if (pathfinding == null)
        {
            Debug.LogError("Pathfinding component is not assigned.");
        }
    }

    void Update()
    {
        if (!isMoving)
        {
            Move();
        }
    }

    public void Move()
    {
        if (Vector3.Distance(transform.position, player.position) > 1.5f) // Only move if not adjacent
        {
            List<Node> path = pathfinding.FindPath(transform.position, player.position);
            if (path != null && path.Count > 1)
            {
                targetPosition = new Vector3(path[1].gridX, transform.position.y, path[1].gridY);
                StartCoroutine(MoveAlongPath());
            }
        }
    }

    IEnumerator MoveAlongPath()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }
}
