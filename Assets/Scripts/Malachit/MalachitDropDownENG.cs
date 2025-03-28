using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MalachitDropDownENG : MonoBehaviour
{
    public Dropdown[] dropdowns = {};
    int currentIndex = 0;
    int[] values = {0, 0, 0};
    public GameObject[] gameObjects = {};
    public GameObject videoObject;
    string result = "";
    //string correct_result = "212";

    string replyText;
    string choice;
    public GameObject replyUI;
    public Text textComponent; 
    

    Dictionary<int, string> first = new Dictionary<int, string>(){
            {1, "Endothermic"},
            {2, "Exothermic"}
    };

    Dictionary<int, string> second = new Dictionary<int, string>(){
            {1, "Cu2CO3(OH)2 → 2CuO + CO2 + H2O"},
            {2, "Cu2CO3 → CuO2 + CO2 + H2O"},
            {3, "Cu3CO2(OH)2 → 2CuO + 2CO2 + H2"}
    };

    Dictionary<int, string> third = new Dictionary<int, string>(){
            {1, "Pure copper"},
            {2, "Gas C02"}, 
            {3, "Both options"},
    };

    Dictionary<int, string> answers = new Dictionary<int, string>(){};

    public void NextButton(){
        //values[currentIndex] = dropdowns[currentIndex].value;
        //answers.Add(currentIndex + 1, dropdown.options[dropdowns[currentIndex].value].text);
        if(currentIndex==0){
            replyText += "1.Type of reaction? \n";
            choice = first[dropdowns[currentIndex].value];
            if(choice == "Endothermic"){
                replyText += "  Endothermic ✓ \n\n";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "Endothermic ✓ \n\n";
            }
        }

        else if(currentIndex==1){
            replyText += "2. What is the correct formula for the combustion reaction of malachite? \n";
            choice = second[dropdowns[currentIndex].value];
            if(choice == "Cu2CO3 → CuO2 + CO2 + H2O"){
                replyText += "  Cu2CO3 → CuO2 + CO2 + H2O ✓ \n\n";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "Cu2CO3 → CuO2 + CO2 + H2O ✓ \n\n";
            }
        }
        gameObjects[currentIndex].SetActive(false);
        currentIndex++;
        gameObjects[currentIndex].SetActive(true);
    }  

    public void FinalButton(){
        //values[currentIndex] = dropdowns[currentIndex].value;
        videoObject.SetActive(true);
        gameObjects[currentIndex].SetActive(false);

        replyText += "3. What is released as a result of the reaction? \n";
        choice = third[dropdowns[currentIndex].value];
            if(choice == "Both options"){
                replyText += "  Both options ✓";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "Both options ✓";
            }

        for(int i = 0; i < 3; i++){
            result += values[i];
        }

        Debug.Log(replyText);
        Debug.Log(result);
    }

    public void Reply(){
        videoObject.SetActive(false);
        
        replyUI.SetActive(true);
        textComponent.text = replyText;
    }
}
