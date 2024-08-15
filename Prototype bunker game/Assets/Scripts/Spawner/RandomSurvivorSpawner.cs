using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSurvivorSpawner : MonoBehaviour
{
    [Header("Survivor Properties")]
    public Transform SpawnLoc;
    public GameObject SurvivorPrefab;
    public float SpawnRate;

    [Header("Bunker Properties")]
    public float MaxAmountSurvivor;
    public bool StopSpawning;
    public bool resetSpawner;


    void Update(){
        if(StopSpawning){
            //Debug.Log("Stopped spawner");
        }
        
        // 
        if(this.transform.childCount >= MaxAmountSurvivor){
            //Debug.Log("Max survivor limit has been met");
            StopSpawning = true;
        } else{
            StopSpawning = false; 
        }

        if(Time.time >= SpawnRate && !StopSpawning)
        {
            float FlatTime = Random.Range(5, 30);
            Mathf.Ceil(FlatTime);
            SpawnRate = Time.time + FlatTime;

            Instantiate(SurvivorPrefab, SpawnLoc);
        }
    }

}
