using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DamageTester : MonoBehaviour
{
    public PlayerHealthManager playerHealth;
    private PlayerInput playerInput;
    public InputAction damageAction;
    public float damageAmount;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        damageAction = playerInput.actions.FindAction("DamageTester");
    }

    void Update()
    {
        if (damageAction.WasPressedThisFrame())
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
