using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{   
    AsyncOperation asyncLoad;
    public Camera mainCamera;

    public void SimpleSwitch(int sceneIndex){
        asyncLoad = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;            
    }

    public void EasySwitch(int sceneIndex){
        mainCamera.enabled = false;
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void StartSceneSwitch(int sceneIndex){
        StartCoroutine(SceneSwitch(sceneIndex));
    }

    public IEnumerator SceneSwitch(int sceneIndex){
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        operation.allowSceneActivation = true; 
        yield return null;
    }


}
