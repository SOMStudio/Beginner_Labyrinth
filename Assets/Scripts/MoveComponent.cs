using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public float speed;
    public Transform pointStart;
    public Transform pointFinal;
    
    private bool moveFirsPoint = true;
    
    private void Update()
    {
        if (moveFirsPoint)
        {
            Vector3 moveDirection = pointStart.position - transform.position;
            transform.position = transform.position + moveDirection.normalized * (Time.deltaTime * speed);

            if (moveDirection.magnitude < 0.1f)
            {
                moveFirsPoint = false;
            }
        }
        else
        {
            Vector3 moveDirection = pointFinal.position - transform.position;
            transform.position = transform.position + moveDirection.normalized * (Time.deltaTime * speed);

            if (moveDirection.magnitude < 0.1f)
            {
                moveFirsPoint = true;
            }
        }
    }
}
