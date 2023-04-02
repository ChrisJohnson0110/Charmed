using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesOnScreen : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    float timer = 2;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GetEnemiesOnScreen();
            timer = 2f;
        }
    }


    private List<GameObject> GetEnemiesOnScreen()
    {
        Debug.Log("Getting ene");
        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, 1000f, LayerMask.GetMask("EnemyCreature"));

        foreach (GameObject g in enemyList)
        {
            g.GetComponent<PropertiesManager>().isDisplayed = false;
        }

        enemyList.Clear();
        foreach (Collider enemyCollider in enemyColliders)
        {
            enemyList.Add(enemyCollider.gameObject);
        }

        return enemyList;
    }
}
