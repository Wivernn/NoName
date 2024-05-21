using UnityEngine;

public class P2DCameraFollow : MonoBehaviour
{
    private Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 position = target.position;
        position.z = transform.position.z;

        transform.position = position;
    }
}
