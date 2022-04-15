using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    [SerializeField] float maxDistance = 5f;
    Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsValidTarget(other.gameObject))
        {
            EventManager.TriggerEvent(Constants.Events.FLEA_FOCUS);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsValidTarget(other.gameObject))
        {
            EventManager.TriggerEvent(Constants.Events.FLEA_UNFOCUS);
        }
    }

    bool IsValidTarget(GameObject target) {
        return target.activeInHierarchy && target.CompareTag(Constants.Tags.FLEA) && Vector3.Distance(target.transform.position, transform.position) <= maxDistance;
    }
}
