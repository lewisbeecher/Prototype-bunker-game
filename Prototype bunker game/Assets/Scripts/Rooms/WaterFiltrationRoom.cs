using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFiltrationRoom : MonoBehaviour
{
    [Header("Water room properties")]
    public float FiltrationRate = 1f;

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

        if(CurrnetOpRole == "Filteration"){
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
        ResetTimer += FiltrationRate;
    }

    void Update(){

        // Check is correct person is in the room
        if(IsTheCorrectRole && SurvivorInRoom.GetComponent<SurvivorStats>().Sleeping == false && Time.time > FiltrationRate){
            FiltrationRate = Time.time + ResetTimer;
            
            Debug.Log("Water made");

            ResourceManager.GetComponent<ResourcesManager>().Water += 15f;
        }
    }
}
