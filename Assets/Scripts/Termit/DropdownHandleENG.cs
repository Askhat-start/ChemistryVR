using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandleENG : MonoBehaviour
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
    public GameObject questionOne;

    
    

    Dictionary<int, string> first = new Dictionary<int, string>(){
            {1, "Obtaining pure iron from rust"},
            {2, "Welding of iron rails"},
            {3, "Energy obtaning"}
    };

    Dictionary<int, string> second = new Dictionary<int, string>(){
            {1, "Fe2O3 + 2 Al  → 2 Fe + Al2O3"},
            {2, "Fe + Al2O3  → Fe2O3 + 2Al"},
            {3, "Fe2O3 + 2Al → 2Fe + Al3O2"}
    };

    Dictionary<int, string> third = new Dictionary<int, string>(){
            {1, "Endothermic reaction"},
            {2, "Exothermic reaction"}
    };

    Dictionary<int, string> answers = new Dictionary<int, string>(){};

    public void NextButtonENG(){
        values[currentIndex] = dropdowns[currentIndex].value;
        gameObjects[currentIndex].SetActive(false);
        //answers.Add(currentIndex + 1, dropdown.options[dropdowns[currentIndex].value].text);
        if(currentIndex==0){
            replyText += "1.What are the purposes of thermite in production? \n";
            choice = first[dropdowns[currentIndex].value];
            if(choice == "Welding of iron rails"){
                replyText += "  Welding of iron rails ✓ \n\n";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "Welding of iron rails ✓ \n\n";
            }
        }

        else if(currentIndex==1){
            replyText += "2. 2. What is the correct reaction formula? \n";
            choice = second[dropdowns[currentIndex].value];
            if(choice == "Fe2O3 + 2 Al  → 2 Fe + Al2O3"){
                replyText += "  Fe2O3 + 2 Al  → 2 Fe + Al2O3 ✓ \n\n";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "Fe2O3 + 2 Al  → 2 Fe + Al2O3 ✓ \n\n";
            }
        }
        
        currentIndex++;
        gameObjects[currentIndex].SetActive(true);
    }  

    public void ReplyENG(){
        values[currentIndex] = dropdowns[currentIndex].value;
        //videoObject.SetActive(true);
        gameObjects[currentIndex].SetActive(false);

        replyText += "3. 3. Specify the type of this reaction. \n";
        choice = third[dropdowns[currentIndex].value];
            if(choice == "Endothermic reaction"){
                replyText += "  Endothermic reaction ✓";
            }
            else{
                replyText += "  Your answer: " + choice + " ✗" + "\n  Correct answer: " + "Endothermic reaction ✓";
            }

        for(int i = 0; i < 3; i++){
            result += values[i];
        }
        textComponent.text = replyText;
        replyUI.SetActive(true);
    }

    public void ShowQuestionENG(){
        videoObject.SetActive(false);
        questionOne.SetActive(true);
    }
}
