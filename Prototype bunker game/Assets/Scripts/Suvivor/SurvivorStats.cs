using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorStats : MonoBehaviour
{
    [Header("Stats")]
    private string[] PosSkills = new string[]{"Explorer","Cook", "Filtration"};
    public string FinalSkill;

    public float Health = 10f;
    public float FoodLevel = 100f;

    void Start()
    {
        // Choose a random skill
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
