using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool usePhysic;
    public float speed = 1f;
    [SerializeField] private AxisComponent axisComponent;

    private Rigidbody rigidbody;
    
    private void Start()
    {
        axisComponent = GetComponent<AxisComponent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (usePhysic) return;
        
        if (axisComponent.axis.magnitude > 0f)
        {
            transform.position += new Vector3(axisComponent.axis.x, 0f, axisComponent.axis.y) * Time.deltaTime * speed;
        }
    }

    private void FixedUpdate()
    {
        if (!usePhysic) return;

        if (axisComponent.axis.magnitude > 0f)
        {
            rigidbody.AddForce(new Vector3(axisComponent.axis.x, 0f, axisComponent.axis.y) * Time.deltaTime * speed);
        }
    }
}
