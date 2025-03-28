using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalachitDecompose : MonoBehaviour
{
    public GameObject[] objectsToDestroy;
    public float delayBetweenDestroy = 1.0f;
    public GameObject burnerFlame;
    private Renderer malachit_renderer;
    public Material blackMaterial;
    public GameObject waterLeak;
    private bool coroutineRunning = false;


    void Update(){
        if(burnerFlame.activeSelf && !coroutineRunning){
            StartCoroutine(DestroyObjectsCoroutine());
            Invoke("WaterLeaking", 10000f);

        }
    }
    
    void WaterLeaking(){
        waterLeak.SetActive(true);
    }
    
    IEnumerator DestroyObjectsCoroutine()
    {
        coroutineRunning = true; // Set the flag to indicate coroutine is running

        foreach (GameObject obj in objectsToDestroy)
        {
            yield return new WaitForSeconds(delayBetweenDestroy);
            malachit_renderer = obj.GetComponent<Renderer>();
            malachit_renderer.material = blackMaterial;
        }
    }
}
