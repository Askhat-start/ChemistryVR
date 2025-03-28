using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSwitch : MonoBehaviour
{
    public void LoadSceneAsync(int sceneIndex)
    {
        // Start loading the scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        // Optionally, you can disable scene activation to control when the scene is actually displayed
        operation.allowSceneActivation = true;

        // Check if the scene is fully loaded
        //StartCoroutine(WaitForSceneLoad(operation));
    }

    private IEnumerator WaitForSceneLoad(AsyncOperation operation)
    {
        // Wait until the asynchronous operation is done
        while (!operation.isDone)
        {
            // Calculate progress and possibly update a loading bar
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // Yielding here allows the game to continue to run smoothly
            yield return null;
        }

        // Now the scene has been fully loaded
        Debug.Log("Scene fully loaded");

        // Activate the scene
        operation.allowSceneActivation = true;
    }
}
