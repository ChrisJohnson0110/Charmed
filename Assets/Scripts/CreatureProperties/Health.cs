using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject HealthDisplay;
    Status StatusReference;


    public float health = 5f;

    private void Start()
    {
        UpdateDisplay();
        StatusReference = gameObject.GetComponent<Status>();
    }

    public void TakeDamage(float a_fDamageToTake)
    {
        health -= a_fDamageToTake;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            HealthDisplay.SetActive(false);
            StatusReference.StatusDisplay.SetActive(false);
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (HealthDisplay != null)
        {
            HealthDisplay.GetComponent<Text>().text = health.ToString();
        }
    }
}
