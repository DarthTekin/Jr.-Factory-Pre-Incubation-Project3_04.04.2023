using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] cupPrefabs;    
    private float spawnRange = 7.0f;
    private float zIncrement = 9.0f;
    private float posZ = -490.0f;
    
      

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 100; i++)
        {            
            int randomCup = Random.Range(0, cupPrefabs.Length);
            Instantiate(cupPrefabs[randomCup], SpawnPosition(zIncrement), cupPrefabs[randomCup].transform.rotation);
            zIncrement = zIncrement + spawnRange;
        }
            
       
    }

    private Vector3 SpawnPosition(float zOffset)
    {
        float randomPosX = Random.Range(-spawnRange, spawnRange);
        Vector3 randomVector = new Vector3(randomPosX, 1.0f, posZ + zOffset);
        return randomVector;
    }
}
