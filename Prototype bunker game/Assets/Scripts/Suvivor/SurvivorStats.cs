using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SurvivorStats : MonoBehaviour
{
    // Specific stats
    // Specific skils
    // Food will tick down over time so will water. Once these are done
    // Either of them once empty will start to remove health.
    // if both are gone well it just puts both together.
    // If they are within a part of the settlement they can pull from food
    // resources.

    [Header("Stats")]
    public float Health = 100f;
    public float FoodLevel = 100;
    public float WaterLevel = 100;
    public bool Sleeping;
    public float TimeBetweenSleep = 60f;
    bool StartedDying = false;

    [Header("Skills")]
    public bool Cook;
    public bool Filteration;
    public bool Explorer;
    // These are hard code 
    private string[] PosSkills = new string[]{"Cook", "Filteration", "Explorer"};
    public string FinalSkill;

    [Header("Popup UI")]
    public TMP_Text NameText;
    public TMP_Text SkillText;
    public TMP_Text HealthText;
    public TMP_Text FoodText;
    public TMP_Text WaterText;
    public TMP_Text SleepingText;

    private string[] PossibleNames = new string[] { "Piotr", "Sol", "Jonah", "Callum", "George", "Riley", "Juke", "Goop", "Cory" };
    private string FinalName;

    [Header("Misc")]
    public GameObject SettlementResources;

    void Start()
    {

        // Choose a random skill
        FinalSkill = PosSkills[Random.Range(0, PosSkills.Length)];

        //Set name
        FinalName = PossibleNames[Random.Range(0, PossibleNames.Length)];
        NameText.text = "Name: " + FinalName;

        // this skill needs to then apply to gameplay. a cook cant be an explorer etc
        if (FinalSkill == "Cook"){
            //Debug.Log("A cook has arrived");
            Cook = true;
        }

        if(FinalSkill == "Filteration"){
            //Debug.Log("A Filteration has arrived");
            Filteration = true;
        }

        if(FinalSkill == "Explorer"){
            //Debug.Log("A Explorer has arrived");
            Explorer = true;
        }

        // Set skillset to UI
        SkillText.text = "Skillset: " + FinalSkill;

        // This will take food over time
        InvokeRepeating("TickFood", 4f, 4f);

        // This will take water over time
        InvokeRepeating("TickWater", 4f, 4f);

        // Need to grab the resources because the surviors need to pull from the resources
        SettlementResources = GameObject.Find("Settlement Resources");

        // Switch between sleeping and not
        InvokeRepeating("Sleep", TimeBetweenSleep, TimeBetweenSleep);
    }

    void TickFood(){
        FoodLevel -= 2f;
    }
    void TickWater(){
        WaterLevel -= 5f;
    }

    void Sleep(){
        if(Sleeping){
            Sleeping = false;
        } else{
            Sleeping = true;
        }
    }

    void Update(){
        // Is survivor out of food? if yes check if there is any food in resources. if yes
        // eat something. Also do something like 25 rather than 0
        if(FoodLevel <= 25 && SettlementResources.GetComponent<ResourcesManager>().Food >= 85){
            Debug.Log("hmmm im feeling peckish");
            EatSomething();
        }

        // Now same as for food but with water
        if(WaterLevel <= 50 && SettlementResources.GetComponent<ResourcesManager>().Water >= 50){
            Debug.Log("hmmm I could do with a bit of O2 in my system");
            DrinkSomething();
        }

        // for ones missing health. If their food levels are above say 50 they will heal otherwise
        // they will not

        // loose health if both water and food are gone
        if(WaterLevel <= 0 && FoodLevel <= 0){
            WaterLevel = 0;
            FoodLevel = 0;
            
            
            if(!StartedDying){
                TickAwayHealth();
                //Debug.Log("Survivor has started to die");
            } 
            

        }

        if(Health <= 0){
            this.transform.GetComponent<SpriteRenderer>().color = Color.red;
            //Debug.Log("Survivor has died");

            Destroy(this.gameObject, 5f);
        }

        //yucky code
        HealthText.text = "Health: " + Health;
        FoodText.text = "Food: " + FoodLevel;
        WaterText.text = "Water: " + WaterLevel;

        if(Sleeping)
        {
            SleepingText.text = "Sleeping: Yes";
        }
        else
        {
            SleepingText.text = "Sleeping: No";
        }

        if (WaterLevel <= 0)
        {
            WaterLevel = 0;
        }

        if (FoodLevel <= 0)
        {
            FoodLevel = 0;
        }


    }

    void EatSomething(){
        // Taking away the amount that will fill the survivor to their max
        SettlementResources.GetComponent<ResourcesManager>().Food -= 75;
        FoodLevel += 75;
        Debug.Log("hmmm that was delicious. Im stuffed");
    }

    void DrinkSomething(){
        SettlementResources.GetComponent<ResourcesManager>().Water -= 50;
        WaterLevel += 50;
        Debug.Log("Ahh how refreshing");
    }

    float StartRate = 1f;

    void TickAwayHealth(){
        if(Time.time > StartRate){
            StartRate = Time.time + 1f;
            
            Health -= 5;
        }
    }
}
