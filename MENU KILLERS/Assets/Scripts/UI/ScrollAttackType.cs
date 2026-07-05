using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollAttackType : MonoBehaviour
{
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;

    [SerializeField] private bool attack1Active;
    [SerializeField] private bool attack2Active;
    [SerializeField] private bool attack3Active;

    private void OnEnable()
    {
        attack1Active = true;
        EventSystem.current.SetSelectedGameObject(attack1);
    }

    public void ChangeAttackLeft()
    {
        if (attack1Active)
        {
            attack1Active = false;
            attack1.SetActive(false);
            attack3Active = true;
            attack3.SetActive(true);
            EventSystem.current.SetSelectedGameObject(attack3);
        }
        else if (attack2Active)
        {
            attack2Active = false;
            attack2.SetActive(false);
            attack1Active = true;
            attack1.SetActive(true);
            EventSystem.current.SetSelectedGameObject(attack1);
        }
        else if (attack3Active)
        {
            attack3Active = false;
            attack3.SetActive(false);
            attack2Active = true;
            attack2.SetActive(true);
            EventSystem.current.SetSelectedGameObject(attack2);
        }
    }

    public void ChangeAttackRight()
    {
        if (attack1Active)
        {
            attack1Active = false;
            attack1.SetActive(false);
            attack2Active = true;
            attack2.SetActive(true);
            EventSystem.current.SetSelectedGameObject(attack2);
        }
        else if (attack2Active)
        {
            attack2Active = false;
            attack2.SetActive(false);
            attack3Active = true;
            attack3.SetActive(true);
            EventSystem.current.SetSelectedGameObject(attack3);
        }
        else if (attack3Active)
        {
            attack3Active = false;
            attack3.SetActive(false);
            attack1Active = true;
            attack1.SetActive(true);
            EventSystem.current.SetSelectedGameObject(attack1);
        }
    }
}