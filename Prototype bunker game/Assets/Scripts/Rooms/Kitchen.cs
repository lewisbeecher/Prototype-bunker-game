using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    // Check if the room is empty or not
    // Generate food + check if the survivor is sleeping or not
    [Header("Cooking properties")]
    public float CookingRate = 1f;

    [Header("Room states")]
    public bool RoomOccupied = false;
    public bool IsTheCorrectRole;
    private string CurrnetOpRole;
    public GameObject SurvivorInRoom;

    [Header("Resources")]
    public GameObject ResourceManager;

    void OnCollisionEnter2D(Collision2D SurEnter){
        //Debug.Log(SurEnter.transform.name);
        RoomOccupied = true;

        CurrnetOpRole = SurEnter.transform.GetComponent<SurvivorStats>().FinalSkill;
        //Debug.Log(CurrnetOpRole);

        SurvivorInRoom = SurEnter.transform.gameObject;

        if(CurrnetOpRole == "Cook"){
            //Debug.Log("This is the correct role");
            IsTheCorrectRole = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D SurExit){
        //Debug.Log("Silly man has left room " + transform.name);
        RoomOccupied = false;
        IsTheCorrectRole = false;

        SurvivorInRoom = null;
    }

    float ResetTimer;

    void Start(){
        ResetTimer += CookingRate;
    }

    void Update(){

        // Check is correct person is in the room
        if(IsTheCorrectRole && SurvivorInRoom.GetComponent<SurvivorStats>().Sleeping == false && Time.time > CookingRate){
            CookingRate = Time.time + ResetTimer;
            
            Debug.Log("Food made");

            ResourceManager.GetComponent<ResourcesManager>().Food += 15f;
        }
    }
}
