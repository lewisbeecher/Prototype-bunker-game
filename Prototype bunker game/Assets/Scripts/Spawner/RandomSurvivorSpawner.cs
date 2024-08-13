using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSurvivorSpawner : MonoBehaviour
{
    [Header("Survivor Properties")]
    public Transform SpawnLoc;
    public GameObject SurvivorPrefab;
    float RandAmount;

    [Header("Bunker Properties")]
    public float MaxAmountSurvivor;
    bool StopSpawning;


    IEnumerator Start(){

        // This will forever loop until StopSpawning is eqaul to true
        while(!StopSpawning)
        {
            RandAmount = Random.Range(1f, 10f);
            Instantiate(SurvivorPrefab, SpawnLoc);
            yield return new WaitForSeconds(RandAmount);
        }
    }

    void Update(){
        // Stop spawning in.
        // This will check how many survivros are spawned in. This later can be linked
        // to a shelter manager and that can store the max amount of people. So once the
        // max is reached the spawner will stop automatically
        if(StopSpawning){
            //Debug.Log("Stopped spawner");
        }

        if(this.transform.childCount >= MaxAmountSurvivor){
            //Debug.Log("Max survivor limit has been met");
            StopSpawning = true;
        } else{
            StopSpawning = false; 
        }
    }

}
