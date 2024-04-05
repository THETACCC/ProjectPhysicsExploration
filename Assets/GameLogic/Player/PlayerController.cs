using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerHealth;
    public float PlayerMaxHealth;

    public void Start()
    {
        PlayerHealth = PlayerMaxHealth;

    }

    public void ResetHealth()
    {
        PlayerHealth = PlayerMaxHealth;
    }

}
