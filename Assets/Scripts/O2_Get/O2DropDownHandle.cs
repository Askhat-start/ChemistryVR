using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2DropDownHandle : MonoBehaviour
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
            {1, "Катализатор"},
            {2, "Реагент"},
            {3, "Окислитель"}
    };

    Dictionary<int, string> third = new Dictionary<int, string>(){
            {1, "Вытеснение воды"},
            {2, "Вытеснение воздуха"}
    };

    Dictionary<int, string> answers = new Dictionary<int, string>(){};

    public void NextButton(){
        //values[currentIndex] = dropdowns[currentIndex].value;
        //answers.Add(currentIndex + 1, dropdown.options[dropdowns[currentIndex].value].text);
        if(currentIndex==0){
            replyText += "1. Формула разложения перманганата калия \n";
            choice = first[dropdowns[currentIndex].value];
            Debug.Log(choice);
            if(choice == "2 KMnO₄ → K₂MnO₄ + MnO₂ + O₂"){
                replyText += "  2 KMnO₄ → K₂MnO₄ + MnO₂ + O₂ ✓ \n\n";
            }
            else{
                replyText += "  Ваш ответ: " + choice + " ✗" + "\n  Правильный ответ: " + "2 KMnO₄ → K₂MnO₄ + MnO₂ + O₂ ✓ \n\n";
            }
        }

        else if(currentIndex==1){
            replyText += "2. Какую функцию выполняет Mno2? \n";
            choice = second[dropdowns[currentIndex].value];
            if(choice == "Катализатор"){
                replyText += "  Катализатор ✓ \n\n";
            }
            else{
                replyText += "  Ваш ответ: " + choice + " ✗" + "\n  Правильный ответ: " + "Катализатор ✓ \n\n";
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

        replyText += "3. Какой метод получение кислорода был использован? \n";
        choice = third[dropdowns[currentIndex].value];
            if(choice == "Вытеснение воздуха"){
                replyText += "  Вытеснение воздуха ✓";
            }
            else{
                replyText += "  Ваш ответ: " + choice + " ✗" + "\n  Правильный ответ: " + "Вытеснение воздуха ✓";
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
