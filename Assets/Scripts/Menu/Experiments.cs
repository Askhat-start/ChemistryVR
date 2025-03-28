using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiments : MonoBehaviour
{
    public GameObject malachitScreen;
    public GameObject termitScreen;
    public GameObject O2Screen;

    public void ToTermit(){
        O2Screen.SetActive(false);
        termitScreen.SetActive(true);
    }

    public void ToO2(){
        malachitScreen.SetActive(false);
        O2Screen.SetActive(true);
    }

    public void ToMalachit(){
        termitScreen.SetActive(false);
        malachitScreen.SetActive(true);
    }
}
