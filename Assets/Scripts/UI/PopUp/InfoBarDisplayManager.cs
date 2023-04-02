using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBarDisplayManager : MonoBehaviour
{
    EnemiesOnScreen EnemiesOnScreenRef;
    int iNumberOfEnemiesOnScreen = 0;

    [SerializeField] GameObject HealthDisplayPrefab;
    [SerializeField] GameObject StatusDisplayPrefab;

    GameObject[] HealthDisplays;
    GameObject[] StatusDisplays;

    [SerializeField] int iNumberOfInstancesToCreate;


    // Start is called before the first frame update
    void Start()
    {
        HealthDisplays = new GameObject[iNumberOfEnemiesOnScreen];
        StatusDisplays = new GameObject[iNumberOfEnemiesOnScreen];

        EnemiesOnScreenRef = FindObjectOfType<EnemiesOnScreen>();
        CreateDisplayObjects();
    }

    // Update is called once per frame
    void Update()
    {
        //if (EnemiesOnScreenRef.enemyList.Count != iNumberOfEnemiesOnScreen) //if number of eneimes on screen changes
        //{
        //    iNumberOfEnemiesOnScreen = EnemiesOnScreenRef.enemyList.Count; //set new number
        //    UpdateDisplay(); //update
        //}
        UpdateDisplay();
    }

    /// <summary>
    /// update the status of the display on the object
    /// </summary>
    private void UpdateDisplay()
    {
        foreach (GameObject g in EnemiesOnScreenRef.enemyList)
        {
            PropertiesManager h = g.GetComponent<PropertiesManager>();

            h.Initialize();
            h.HealthDisplay = GetAvailable(HealthDisplays);
            h.StatusDisplay = GetAvailable(StatusDisplays);
            h.isDisplayed = true;
            
        }


    }

    /// <summary>
    /// create needed number of displays
    /// </summary>
    private void CreateDisplayObjects()
    {
        for (int i = 0; i < iNumberOfInstancesToCreate; i++)
        {
            HealthDisplays[i] = Instantiate(HealthDisplayPrefab);
            StatusDisplays[i] = Instantiate(StatusDisplayPrefab);
            HealthDisplays[i].SetActive(false);
            StatusDisplays[i].SetActive(false);
        }   
    }

    /// <summary>
    /// get first active in array
    /// </summary>
    private GameObject GetAvailable(GameObject[] a_lgoListToCheck)
    {
        foreach (GameObject go in a_lgoListToCheck)
        {
            if (go.activeSelf == false)
            {
                return go;
            }
        }
        return null;
    }


}
