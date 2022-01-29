using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    
    //Properties
    [Space(5)]
    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityMultiplier;
    private float Gravity => 9.81f * gravityMultiplier;
    [SerializeField] [Range(0, 1)] private float positiveYGravity;
    [SerializeField] [Range(0, 1)] private float positiveYGravityJumpHold;
    [SerializeField] private LayerMask GroundLayer;
    
    private bool isGrounded;
    
    
    private void Awake() {
        if (!rb) rb = GetComponent<Rigidbody>();
    }
    
    private void Start() {
        InputManager.Instance.OnJump.AddListener(Jump);
    }

    private void FixedUpdate() {
        CheckGrounded();
        Move(InputManager.Instance.MoveInput);
        SetGravity();
    }

    private void SetGravity() {
        if(isGrounded) return;
        
        if (rb.velocity.y <= 0)
            rb.AddForce(Vector2.down * Gravity, ForceMode.Acceleration);
        else if (!InputManager.Instance.JumpHeld)
            rb.AddForce(Vector2.down * Gravity * positiveYGravity, ForceMode.Acceleration);
        else
            rb.AddForce(Vector2.down * Gravity * positiveYGravityJumpHold, ForceMode.Acceleration);

    }

    private void CheckGrounded() {
        isGrounded = Physics.Raycast(transform.position, Vector2.down, 0.9f, GroundLayer);
    }

    private void Move(Vector2 input) {
        var force = new Vector3(input.x * moveSpeed, 0, input.y * moveSpeed);

        if (WorldTypeSwitcher.Instance.WorldType) force = -force;
        
        rb.AddForce(force, ForceMode.Acceleration);
    }

    private void Jump() {
        if (!isGrounded) return;

        var force = transform.up * Mathf.Sqrt(-2f * -Gravity * jumpHeight);
        rb.AddForce(force, ForceMode.Impulse);
    }

}
