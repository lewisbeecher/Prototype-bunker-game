using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
    // This controls text and is where resources are pull from
    [Header("Values")]
    public float Food;
    public float Water;
    public float Money;

    [Header("UI properties")]
    public TMP_Text FoodText;
    public TMP_Text WaterText;
    public TMP_Text MoneyText;


    void Update(){

        // Update all of the UI elements
        FoodText.text = "Food: " + Food.ToString();
        WaterText.text = "Water:" + Water.ToString();
        MoneyText.text = "Money: " + Money.ToString();

    }
}
