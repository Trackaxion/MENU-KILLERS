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
    public float controllerAimDeadzone = 0.1f;

    [Header("Bools")]
    public bool isDashing;
    public bool dashCooldown;
    public bool ableToDash;

    [Header("Input")]
    public InputAction dashAction;
    public InputAction aimAction;

    Vector2 moveInput = Vector2.zero;
    Vector2 smoothMoveInput;
    Vector2 moveInputSmoothVelocity;
    Vector2 mousePosition;
    Vector2 aimInput = Vector2.zero;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        dashAction = playerInput.actions.FindAction("Dash");
        aimAction = playerInput.actions.FindAction("Aim");
    }

    void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
        CheckConnectedDevices();
    }

    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void Start()
    {
        isDashing = false;
        dashCooldown = false;
        ableToDash = true;
        dashTimer = maxDashTimer;
        dashCooldownTimer = maxDashCooldownTimer;
    }

    private void Update()
    {
        if (dashAction.WasPressedThisFrame() && ableToDash)
        {
            Dash();
        }
        DashController();
        PlayerRotationUpdate();
    }

    private void FixedUpdate()
    {
        CheckConnectedDevices();
        if (!isDashing)
        {
            SetPlayerVelocity();
        }
    }
    #region Movement
    private void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    private void SetPlayerVelocity()
    {
        smoothMoveInput = Vector2.SmoothDamp(smoothMoveInput, moveInput, ref moveInputSmoothVelocity, 0.1f);
        rb.velocity = smoothMoveInput * moveSpeed;
    }
    #endregion
    #region Rotation
    private void OnAim(InputValue inputValue)
    {
        aimInput = inputValue.Get<Vector2>();
    }

    private void PlayerRotationUpdate()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        screenMousePosition.z = 10f;
        mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
    }

    private void PlayerRotationController()
    {
        Vector2 aimDirection = mousePosition - rb.position;
        if (aimInput.magnitude >= controllerAimDeadzone)
        {
            aimDirection = aimInput;
        }
        else
        {
            aimDirection = Vector2.zero;
        }
        if (aimDirection != Vector2.zero)
        {
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }
    }

    private void PlayerRotationKeyboard()
    {
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
    #endregion
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
    #region Check for Keyboard/Controller
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Reconnected || change == InputDeviceChange.Disconnected)
        {
            CheckConnectedDevices();
        }
    }

    private void CheckConnectedDevices()
    {
        bool gamepadConnected = Gamepad.current != null;
        if (gamepadConnected)
        {
            PlayerRotationController();
        }
        else
        {
            PlayerRotationKeyboard();
        }
    }
    #endregion
}
