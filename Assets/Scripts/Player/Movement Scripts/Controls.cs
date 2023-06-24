using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    private static Controls _instance;

    public static Controls Instance
    {
        get { return _instance; }
    }
    private FirstPersonController playerControls;

    private void Awake()
    {
        
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new FirstPersonController();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseDeltas()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
    public bool PlayerJumped()
    {
        return playerControls.Player.Jump.triggered;
    }

    public bool PlayerFocused()
    {
        return playerControls.Player.Focus.triggered;
    }

    public bool PlayerPilled()
    {
        return playerControls.Player.Pill.triggered;
    }

    public float PlayerRun()
    {
        return playerControls.Player.Run.ReadValue<float>();
    }

    public bool MouseDown()
    {
        return playerControls.Player.Mouse.triggered;
    }

    public bool PlayerPause()
    {
        return playerControls.Player.UI.triggered;
    }

}
