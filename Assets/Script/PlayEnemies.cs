using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnemies : Entity
{
    [SerializeField] private EnemiesData enemyBasicData;
    protected void MovingForward()
    {
        transform.position -= new Vector3(0, 0, 1) * enemyBasicData.speed * Time.deltaTime;
    }
}
