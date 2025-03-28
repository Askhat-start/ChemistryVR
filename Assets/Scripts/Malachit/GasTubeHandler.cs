using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTubeHandler : MonoBehaviour
{
    public GameObject boiling_system;
    public GameObject GasTube;
    public Vector3 checkPosition;
    public GameObject up;
    public GameObject left; 
    public float delayBetweenDestroy;
    private Renderer malachit_renderer;
    public Material cleanCu;
    public GameObject[] objectsToClean;
    public GameObject theory;
    public GameObject question;
    public bool once_ques = true;

    void Update(){
        if(boiling_system.activeSelf & GasTube.transform.position == checkPosition){
            up.SetActive(true);
            left.SetActive(true);
            Debug.Log("LEFT GAS IS ACTIVATED!");
            Invoke("StartCleaning", 8f);
            if(once_ques){
                Invoke("Ques", 3f);
            }
        }
    }

    public void Ques(){
        theory.SetActive(false);
        question.SetActive(true);
        Debug.Log("FIRST QUESTION ACTIVATED!");
        once_ques = false;
    }

    void StartCleaning(){
        StartCoroutine(CleanCuprum());
    }

    IEnumerator CleanCuprum()
    {
        foreach (GameObject obj in objectsToClean)
        {
            yield return new WaitForSeconds(delayBetweenDestroy);
            malachit_renderer = obj.GetComponent<Renderer>();
            malachit_renderer.material = cleanCu;
        }
    }
}
