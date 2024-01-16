using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public float speed;
    public Transform[] points;

    private int movePoint = 0;

    private void Update()
    {
        Vector3 moveDirection = points[movePoint].position - transform.position;
        transform.position = transform.position + moveDirection.normalized * (Time.deltaTime * speed);

        if (moveDirection.magnitude < 0.1f)
        {
            movePoint = movePoint + 1;

            if (movePoint >= points.Length)
            {
                movePoint = 0;
            }
        }
    }
}
