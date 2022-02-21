using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Enemies", fileName = "NewEnemiesData", order = 0)]

public class EnemiesData : ScriptableObject
{

    public float maxHealth;
    public float speed;
    public float minimumDistance;
    public float stopDistance;

}
