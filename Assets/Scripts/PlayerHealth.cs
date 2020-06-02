using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;

    private void Start() {
        SetHealthText();
    }

    private void OnTriggerEnter(Collider other) {
        health -= healthDecrease;
        SetHealthText();
    }

    private void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
