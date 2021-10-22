using UnityEngine;

public class ColliderListener : MonoBehaviour
{
    public delegate void TriggerHandler(Collider other);
    public delegate void CollisionHandler(Collision collision);

    public event TriggerHandler TriggerEvent;
    public event CollisionHandler CollisionEvent;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEvent?.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEvent?.Invoke(collision);
    }
}
