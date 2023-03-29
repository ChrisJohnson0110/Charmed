using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "NewEnemy")]
public class EnemySO : ScriptableObject
{
    //ememy prefab
    public GameObject EnemyModel;

    //properties
    public float MovementSpeed;
    public float Mana; //resource needed to use abilities
    public float Health;

    //resistences
    public float Armour;
    public float MagicResistence;
    public Damage.type ResitanceType;

    //attacks
    public bool IsRanged;
    public float AttackDamage;
    public float AttackSpeed;
    public Damage.type DamageType;

    //behaviour
    EnemyBehaviour.Type BehaviourType;

    //abilities




}
