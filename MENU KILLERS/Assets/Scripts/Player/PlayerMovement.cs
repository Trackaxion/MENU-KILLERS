using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    private PlayerInput playerInput;

    [Header("Settings")]
    public float moveSpeed;
    public float dashSpeed;
    public float maxDashTimer;
    private float dashTimer;
    public float maxDashCooldownTimer;
    private float dashCooldownTimer;

    [Header("Bools")]
    public bool isDashing;
    public bool dashCooldown;
    public bool ableToDash;

    [Header("Input")]
    public InputAction dashAction;

    Vector2 moveInput = Vector2.zero;
    private Vector3 dashDirection;


    private void Start()
    {
        isDashing = false;
        dashCooldown = false;
        ableToDash = true;
        dashTimer = maxDashTimer;
        dashCooldownTimer = maxDashCooldownTimer;
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        dashAction = playerInput.actions.FindAction("Dash");
    }

    private void Update()
    {
        if (dashAction.WasPressedThisFrame() && ableToDash)
        {
            Dash();
        }
        DashController();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = moveInput * moveSpeed;
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    #region Dash
    private void Dash()
    {
        rb.velocity = moveInput * dashSpeed;
        isDashing = true;
        ableToDash = false;
    }

    private void DashController()
    {
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
        }
        if (dashTimer <= 0)
        {
            isDashing = false;
            dashCooldown = true;
            dashTimer = maxDashTimer;
        }
        if (dashCooldown)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
        if (dashCooldownTimer <= 0)
        {
            dashCooldown = false;
            ableToDash = true;
            dashCooldownTimer = maxDashCooldownTimer;
        }
    }
    #endregion
}
