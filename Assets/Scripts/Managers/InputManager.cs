using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public bool PhoneOpenCloseInput {  get; private set; }

    private PlayerInput playerInput;

    private InputAction phoneOpenCloseAction;

    private void Awake()
    {
        if (instance == null) 
        { instance = this; }

        playerInput = GetComponent<PlayerInput>();
        phoneOpenCloseAction = playerInput.actions["PhoneOpenClose"];
    }

    private void Update()
    {
        PhoneOpenCloseInput = phoneOpenCloseAction.WasPressedThisFrame();
    }
}
