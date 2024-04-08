using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private PlayerInput _playerInput;

    public bool fire;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    void LateUpdate()
    {
        fire = false;
    }

    public void OnFire(InputValue value)
    {
        fire = value.isPressed;
    }

}
