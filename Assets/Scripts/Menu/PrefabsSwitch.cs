using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsSwitch : MonoBehaviour
{
    public GameObject newScenePrefab;
    public GameObject termitScenePrefab;
    public GameObject malachitScenePrefab;
    public GameObject O2GetScenePrefab;
    public GameObject completeXrOrigin;
    //public GameObject quad;
    
    //private void UnLoadScreen(){
    //   quad.SetActive(false);
    //}

    //private void LoadScreen(){
    //    quad.SetActive(true);
    //    Invoke("UnLoadScreen", 2.5f);
    //}

    // MENU: 0.053x 0.153y -15.083z
    // TERMIT: 0.115x 0.649y 0.743z
    // MALACHIT: -12.457x 3.407y -15.258z
    // O2: 19.326x 24.809y -29.3847z
    public void GoToTermit(){
        newScenePrefab.SetActive(false);
        termitScenePrefab.SetActive(true);
        completeXrOrigin.transform.position = new Vector3(7.901f, -0.022f, -24.035f);
        //LoadScreen();
    }

    public void GoToMalachit(){
        newScenePrefab.SetActive(false);
        malachitScenePrefab.SetActive(true);
        completeXrOrigin.transform.position = new Vector3(-12.457f, 4.774f, -15.258f);
        //LoadScreen();
    }

    public void GoToO2Get(){
        newScenePrefab.SetActive(false);
        O2GetScenePrefab.SetActive(true);
        completeXrOrigin.transform.position = new Vector3(19.326f, 24.809f, -29.3847f);
        //LoadScreen();
    }
}
