using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// cast auto attacks
/// </summary>
public class AutoAttack : MonoBehaviour
{
    //auto attack variables
    float fAutoAttackSpeed; //speed of the fired projectlile

    //script references
    AutoAttackMelee AutoAttackMeleeReference;
    AutoAttackRanged AutoAttackRangedReference;
    Player PlayerReference;

    private void Start()
    {
        AutoAttackMeleeReference = GameObject.FindGameObjectWithTag("AttacksHolder").GetComponent<AutoAttackMelee>();
        AutoAttackRangedReference = GameObject.FindGameObjectWithTag("AttacksHolder").GetComponent<AutoAttackRanged>();
        PlayerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);

        if (hit.transform.gameObject.tag == "Damageable")
        {
            //hit.transform.gameObject
        }


        if (Input.GetMouseButtonDown(0))
        {
            

            if (PlayerReference.EquippedWeapon.IsRanged == true)
            {
                AutoAttackRanged(this.gameObject.transform, hit.point);
            }
            else
            {
                AutoAttackMelee();
            }
        }
    }

    /// <summary>
    /// use ranged attack
    /// </summary>
    private void AutoAttackRanged(Transform a_ProjectileLaunchPosition, Vector3 a_TargetPosition)
    {   
        AutoAttackRangedReference.AutoAttack(a_ProjectileLaunchPosition, a_TargetPosition, PlayerReference.EquippedWeapon);
    }

    /// <summary>
    /// use melee attack
    /// </summary>
    private void AutoAttackMelee()
    {
        //AutoAttackMeleeReference.AutoAttack();
    }


}
