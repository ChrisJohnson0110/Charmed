using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesManager : MonoBehaviour
{
    bool hasBeenInitialized = false;
    public bool isDisplayed = false;
    public GameObject HealthDisplay;
    public GameObject StatusDisplay;

    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (isDisplayed == true)
        {
            if (HealthDisplay != null)
            {
                HealthDisplay.SetActive(true);
                HealthDisplay.GetComponent<Text>().text = gameObject.GetComponent<Health>().health.ToString();
            }
            if (StatusDisplay != null)
            {
                StatusDisplay.SetActive(true);
                StatusDisplay.GetComponent<Text>().text = gameObject.GetComponent<Status>().Effects[0].ToString();
            }
        }
    }


    public void Initialize()
    {
        if (hasBeenInitialized == false)
        {
            EnemySO Enemy = gameObject.GetComponent<Creature>().CreatureProperties;
            //Enemy.
            if (gameObject.GetComponent<Health>())
            {
                Health goHealth = gameObject.GetComponent<Health>();
                goHealth.health = Enemy.Health;
            }
            if (gameObject.GetComponent<Health>())
            {
                Health goHealth = gameObject.GetComponent<Health>();
                goHealth.health = Enemy.Health;
            }
            hasBeenInitialized = true;
        }
        
    }

}
