using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;
    public PlayerManager player;
    public ScrollAttackType scrollAttackType;

    private InputActions inputActions;

    [Header("Movement")]
    public Vector2 movementInput;
    public float horizontalInput;
    public float verticalInput;
    public float moveAmount;

    [Header("Input Actions")]
    [SerializeField] bool dashInput = false;
    [SerializeField] bool leftAttackInput = false;
    [SerializeField] bool rightAttackInput = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new InputActions();

            inputActions.Player.Move.performed += i => movementInput = i.ReadValue<Vector2>();

            inputActions.Player.Dash.performed += i => dashInput = true;

            inputActions.ActionMenu.Left.performed += i => leftAttackInput = true;
            inputActions.ActionMenu.Right.performed += i => rightAttackInput = true;
        }

        inputActions.Enable();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (enabled)
        {
            if (focus)
            {
                inputActions.Enable();
            }
            else
            {
                inputActions.Disable();
            }
        }
    }

    private void Update()
    {
        HandleAllInputs();
    }

    private void HandleAllInputs()
    {
        HandlePlayerMovement();
        HandleLeftChange();
        HandleRightChange();
    }

    private void HandlePlayerMovement()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

        if (moveAmount > 0 && moveAmount <= 1)
        {
            moveAmount = 1;
        }

        if (player == null)
        {
            return;
        }
    }

    private void HandleLeftChange()
    {
        if (leftAttackInput)
        {
            leftAttackInput = false;
            scrollAttackType.ChangeAttackLeft();
        }
    }

    private void HandleRightChange()
    {
        if (rightAttackInput)
        {
            rightAttackInput = false;
            scrollAttackType.ChangeAttackRight();
        }
    }
}
