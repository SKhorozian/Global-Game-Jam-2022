using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public UnityEvent OnJump;

    // Start is called before the first frame update
    void Start() {
        var playerInput = new PlayerInput();

        playerInput.Enable();
        
        playerInput.PlayerMovement.HorizontalMovement.performed += OnMovementInput;
        playerInput.PlayerMovement.HorizontalMovement.canceled += OnMovementInput;

        playerInput.PlayerMovement.Jump.performed += OnJumpInput;
        playerInput.PlayerMovement.Jump.started += OnJumpInput;
        playerInput.PlayerMovement.Jump.canceled += OnJumpInput;
    }

    public Vector2 MoveInput { get; private set; }
    private void OnMovementInput(InputAction.CallbackContext context) {
        MoveInput = context.ReadValue<Vector2>();
    }

    public bool JumpHeld { get; private set; }
    private void OnJumpInput(InputAction.CallbackContext context) {
        if (context.performed) OnJump?.Invoke();
        
        JumpHeld = !context.canceled;
    }

    private static InputManager _instance;
    public static InputManager Instance {
        get {
            if (_instance) return _instance;

            _instance = FindObjectOfType<InputManager>();
            
            if (!_instance) Debug.LogError("Singleton of type [InputManager] not found");
            
            return _instance;
        }
    }

}
