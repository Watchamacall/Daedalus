using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLock : MonoBehaviour
{
    public void MouseLocking(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.LogError("Mouse Clicked");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (context.performed)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
