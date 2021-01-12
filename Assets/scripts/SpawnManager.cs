using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyPattern;
 

    float timeBtwSpawns;
    float startTimeBtwSpawns = 4;
    float decreaceTime = 0.05f;
    float minTime = 2f;

    void Update()
    {
        if(timeBtwSpawns <=0)
        {
            int rand = Random.Range(0, enemyPattern.Length);
            GameObject thisPattern = Instantiate(enemyPattern[rand], transform.position, Quaternion.identity);
            Destroy(thisPattern, 1f);
            timeBtwSpawns = startTimeBtwSpawns;
            if(startTimeBtwSpawns >= minTime)
            {
                startTimeBtwSpawns -= decreaceTime;
            }
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
