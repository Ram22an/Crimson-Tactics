using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Pathfinding pathfinding;
    public float speed = 2f;

    private List<Node> path;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetPosition = hit.collider.transform.position;
                path = pathfinding.FindPath(transform.position, targetPosition);
                if (path != null)
                {
                    StartCoroutine(MoveAlongPath());
                }
            }
        }
    }

    IEnumerator MoveAlongPath()
    {
        isMoving = true;

        foreach (Node node in path)
        {
            Vector3 targetPosition = new Vector3(node.gridX, transform.position.y, node.gridY);
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
        }

        isMoving = false;
    }
}
