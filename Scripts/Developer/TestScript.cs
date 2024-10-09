using System.Collections;
using System.Collections.Generic;
using UI.PlayerControls;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private PlayerHealthBar playerHealthBar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealthBar.TakeDamage(10);
        }
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealthBar.Heal(10);
        }
    }
}
