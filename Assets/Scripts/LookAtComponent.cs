using UnityEngine;

public class LookAtComponent : MonoBehaviour
{
    [Header("Main")]
    public Transform target;
    public float speedRotate = 1f;
    public float limitRotate = 15f;

    [Header("Delay start rotate")]
    public bool useDelay = true;
    public float delaySeconds;

    private Quaternion startRotate;
    private bool useRerp;

    private void Start()
    {
        startRotate = transform.rotation;
        
        if (useDelay)
        {
            useRerp = false;
            Invoke(nameof(UseLerp), delaySeconds);
        }
        else
        {
            useRerp = true;
        }
    }

    private void UseLerp()
    {
        useRerp = true;
    }

    private void Update()
    {
        if (!useRerp) return;
        
        var targetRotate = Quaternion.LookRotation(target.position - transform.position);
        var angleTargetRotate = Mathf.Abs(Quaternion.Angle(startRotate, targetRotate));
        var angleRealRotate = Mathf.Abs(Quaternion.Angle(startRotate, transform.rotation));
        
        if (angleRealRotate <= limitRotate || angleTargetRotate <= limitRotate)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotate, Time.deltaTime * speedRotate);
        }
    }
}
