using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialButton : MonoBehaviour
{
    [SerializeField] private GameObject[] objs;
    
    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.tag.Equals("Player")) return;

        foreach (var obj in objs) {
            obj.SetActive(true);
        }
        
        this.gameObject.SetActive(false);
    }
}
