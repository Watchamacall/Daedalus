using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementRb: MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float playerRunSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    public string tagName;

    private Rigidbody controller;
    private Animator anim;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private Controls inputController;
    private Transform cameraTransform;
    
    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        inputController = Controls.Instance;
        cameraTransform = Camera.main.transform;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputController.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;

        anim.SetFloat("Speed", move.normalized.sqrMagnitude);

        if (inputController.PlayerRun() > 0)
        {
            controller.transform.position += (move * Time.deltaTime * playerRunSpeed);
        }
        else
        {
            controller.transform.position += (move * Time.deltaTime * playerSpeed);
        }


        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (inputController.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.transform.position += playerVelocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == (tagName))
        {
            groundedPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == (tagName))
        {
            groundedPlayer = false;
        }
    }

}
