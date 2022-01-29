using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Vector3 offset;
    
    [SerializeField] private float lerpAmount;

    // Start is called before the first frame update
    void Start() {
        if (!playerTransform) playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        var position = playerTransform.position;
        var desiredPosition = position + offset;

        var lerpedPosition = Vector3.Lerp(transform.position, desiredPosition, lerpAmount * Time.deltaTime);

        lerpedPosition.y = Mathf.Clamp(lerpedPosition.y, 22, 24);
        
        transform.position = lerpedPosition;
        
        transform.LookAt(position);
    }

    public void OnWorldSwap(bool type) {
        offset.z = -offset.z;
    }
}
