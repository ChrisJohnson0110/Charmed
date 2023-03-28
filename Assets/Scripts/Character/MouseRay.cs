using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour
{
    ClickToMove ClickToMoveRef;
    AutoAttack AutoAttackRef;
    Outline OutlineRef; //outline 

    bool HoveringDamageable = false;


    // Start is called before the first frame update
    void Start()
    {
        ClickToMoveRef = GetComponent<ClickToMove>();
        AutoAttackRef = GetComponent<AutoAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //////////////////Outline//////////////////
            if (hit.transform.gameObject.tag == "Damageable")
            {
                OutlineRef = hit.transform.gameObject.GetComponent<Outline>();
                OutlineRef.ApplyOutline();
                HoveringDamageable = true;
            }
            else
            {
                if (OutlineRef != null)
                {
                    OutlineRef.RemoveOutline();
                }
                HoveringDamageable = false;
            }


            if (Input.GetMouseButtonDown(0))
            {
                //////////////////Move//////////////////
                if (HoveringDamageable == false)
                {
                    ClickToMoveRef.MoveToClickPoint(hit);
                }
                //////////////////Attack//////////////////
                else if (HoveringDamageable == true)
                {
                    AutoAttackRef.Attack(hit);
                    ClickToMoveRef.StopMoving();
                }
            }
        }
    }
}
