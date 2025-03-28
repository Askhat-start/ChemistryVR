using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandle : MonoBehaviour
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
            {1, "Получение чистого железа из ржавчины"},
            {2, "Сварка железных рельс"},
            {3, "Энергетика"}
    };

    Dictionary<int, string> second = new Dictionary<int, string>(){
            {1, "Fe2O3 + 2 Al  → 2 Fe + Al2O3"},
            {2, "Fe + Al2O3  → Fe2O3 + 2Al"},
            {3, "Fe2O3 + 2Al → 2Fe + Al3O2"}
    };

    Dictionary<int, string> third = new Dictionary<int, string>(){
            {1, "Эндотермическая реакция"},
            {2, "Экзотермическая реакция"}
    };

    Dictionary<int, string> answers = new Dictionary<int, string>(){};

    public void NextButton(){
        values[currentIndex] = dropdowns[currentIndex].value;
        gameObjects[currentIndex].SetActive(false);
        //answers.Add(currentIndex + 1, dropdown.options[dropdowns[currentIndex].value].text);
        if(currentIndex==0){
            replyText += "1.В каких целях используется термит? \n";
            choice = first[dropdowns[currentIndex].value];
            if(choice == "Сварка железных рельс"){
                replyText += "  Сварка железных рельс ✓ \n\n";
            }
            else{
                replyText += "  Ваш ответ: " + choice + " ✗" + "\n  Правильный ответ: " + "Сварка железных рельс ✓ \n\n";
            }
        }

        else if(currentIndex==1){
            replyText += "2. Правильная формула реакции? \n";
            choice = second[dropdowns[currentIndex].value];
            if(choice == "Fe2O3 + 2 Al  → 2 Fe + Al2O3"){
                replyText += "  Fe2O3 + 2 Al  → 2 Fe + Al2O3 ✓ \n\n";
            }
            else{
                replyText += "  Ваш ответ: " + choice + " ✗" + "\n  Правильный ответ: " + "Fe2O3 + 2 Al  → 2 Fe + Al2O3 ✓ \n\n";
            }
        }
        
        currentIndex++;
        gameObjects[currentIndex].SetActive(true);
    }  

    public void Reply(){
        values[currentIndex] = dropdowns[currentIndex].value;
        //videoObject.SetActive(true);
        gameObjects[currentIndex].SetActive(false);

        replyText += "3. Укажите тип данной реакции \n";
        choice = third[dropdowns[currentIndex].value];
            if(choice == "Экзотермическая реакция"){
                replyText += "  Экзотермическая реакция ✓";
            }
            else{
                replyText += "  Ваш ответ: " + choice + " ✗" + "\n  Правильный ответ: " + "Экзотермическая реакция ✓";
            }

        for(int i = 0; i < 3; i++){
            result += values[i];
        }
        textComponent.text = replyText;
        replyUI.SetActive(true);
    }

    public void ShowQuestion(){
        videoObject.SetActive(false);
        questionOne.SetActive(true);
    }
}
