using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    [SerializeField] private Vector3 newPos;
    [SerializeField] private UnityEvent OnPortalEnter;
    
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.tag.Equals("Player")) return;

        other.gameObject.transform.position = newPos;
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        OnPortalEnter?.Invoke();
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(newPos, Vector3.one);
    }
}
