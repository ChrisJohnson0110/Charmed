using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 5f;

    [SerializeField] bool canRegen = true; //is able to regen
    [SerializeField] float regenAmount; //amount to regen per sec
    [SerializeField] float timeToRegen; //time before start regening
    float fTimer; //current countdown time for regening


    private void Start()
    {
        //UpdateDisplay();
        fTimer = timeToRegen;
    }

    private void Update()
    {
        if (fTimer > 0 )
        {
            fTimer -= Time.deltaTime;
        }
        else
        {
            //regen
        }
    }

    public void TakeDamage(float a_fDamageToTake)
    {
        health -= a_fDamageToTake;
        fTimer = timeToRegen; //restart regen timer

        if (health <= 0)
        {
            
            //if (StatusReference != null)
            //{
            //    //StatusReference.StatusDisplay.SetActive(false);
            //    Destroy(StatusReference);
            //}
            //if (HealthDisplay != null)
            //{
            //    //HealthDisplay.SetActive(false);
            //    Destroy(HealthDisplay);
            //}
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
        //UpdateDisplay();
    }

    //private void UpdateDisplay()
    //{
    //    if (HealthDisplay != null)
    //    {
    //        HealthDisplay.GetComponent<Text>().text = health.ToString();
    //    }
    //}
}
