using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawn;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, spawn.Length);
        GameObject thisSpawn = spawn[rand];
        Instantiate(thisSpawn, transform.position, thisSpawn.transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
