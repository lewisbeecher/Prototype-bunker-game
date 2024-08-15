using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerRoom : MonoBehaviour
{
    [Header("Explorer room properties")]
    public float ExploreTime = 1f;

    [Header("Room states")]
    public bool RoomOccupied = false;
    public bool IsTheCorrectRole;
    private string CurrnetOpRole;
    public GameObject SurvivorInRoom;

    [Header("Resources")]
    public GameObject ResourceManager;

    void OnCollisionEnter2D(Collision2D SurEnter)
    {
        //Debug.Log(SurEnter.transform.name);
        RoomOccupied = true;

        CurrnetOpRole = SurEnter.transform.GetComponent<SurvivorStats>().FinalSkill;
        //Debug.Log(CurrnetOpRole);

        SurvivorInRoom = SurEnter.transform.gameObject;

        if (CurrnetOpRole == "Explorer")
        {
            //Debug.Log("This is the correct role");
            IsTheCorrectRole = true;
        }

    }

    void OnCollisionExit2D(Collision2D SurExit)
    {
        //Debug.Log("Silly man has left room " + transform.name);
        RoomOccupied = false;
        IsTheCorrectRole = false;

        SurvivorInRoom = null;
    }

    float ResetTimer;

    void Start()
    {
        ResetTimer += ExploreTime;
    }

    void Update()
    {

        // Check is correct person is in the room
        if (IsTheCorrectRole && SurvivorInRoom.GetComponent<SurvivorStats>().Sleeping == false && Time.time > ExploreTime)
        {
            ExploreTime = Time.time + ResetTimer;

            Debug.Log("Explorer has returned");

            float MoneyAmountFlat = Random.Range(0, 15);
            Mathf.Ceil(MoneyAmountFlat);

            ResourceManager.GetComponent<ResourcesManager>().Money += MoneyAmountFlat;
        }
    }
}
