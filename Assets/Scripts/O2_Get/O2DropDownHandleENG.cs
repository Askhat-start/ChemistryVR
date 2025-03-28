using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2DropDownHandleENG : MonoBehaviour
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
            {1, " 2 KMnO₄ → 2 K + 2 MnO + O₃"},
            {2, "2 KMnO₄ → K₂MnO₄ + MnO₂ + O₂"},
            {3, "KMnO₄ → K₂O + MnO + O₂"}
    };

    Dictionary<int, string> second = new Dictionary<int, string>(){
            {1, "Catalyst"},
            {2, "Reagent"},
            {3, "Oxidant"}
    };

    Dictionary<int, string> third = new Dictionary<int, string>(){
            {1, "Water displacement"},
            {2, "Air displacement"}
    };

    Dictionary<int, string> answers = new Dictionary<int, string>(){};

    public void NextButtonENG(){
        //values[currentIndex] = dropdowns[currentIndex].value;
        //answers.Add(currentIndex + 1, dropdown.options[dropdowns[currentIndex].value].text);
        if(currentIndex==0){
            replyText += "1. 1. Formula for the decomposition of potassium permanganate \n";
            choice = first[dropdowns[currentIndex].value];
            Debug.Log(choice);
            if(choice == "2 KMnO₄ → K₂MnO₄ + MnO₂ + O₂"){
                replyText += "  2 KMnO₄ → K₂MnO₄ + MnO₂ + O₂ ✓ \n\n";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "2 KMnO₄ → K₂MnO₄ + MnO₂ + O₂ ✓ \n\n";
            }
        }

        else if(currentIndex==1){
            replyText += "2. 2. What is the function of Mno2? \n";
            choice = second[dropdowns[currentIndex].value];
            if(choice == "Catalyst"){
                replyText += "  Catalyst ✓ \n\n";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "Catalyst ✓ \n\n";
            }
        }
        gameObjects[currentIndex].SetActive(false);
        currentIndex++;
        gameObjects[currentIndex].SetActive(true);
    }  

    public void FinalButtonENG(){
        //values[currentIndex] = dropdowns[currentIndex].value;
        videoObject.SetActive(true);
        gameObjects[currentIndex].SetActive(false);

        replyText += "3. 3. What method of obtaining oxygen was used? \n";
        choice = third[dropdowns[currentIndex].value];
            if(choice == "Air displacement"){
                replyText += "  Air displacement ✓";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "Air displacement ✓";
            }

        for(int i = 0; i < 3; i++){
            result += values[i];
        }

        Debug.Log(replyText);
        Debug.Log(result);
    }

    public void ReplyENG(){
        videoObject.SetActive(false);
        
        replyUI.SetActive(true);
        textComponent.text = replyText;
    }
}
