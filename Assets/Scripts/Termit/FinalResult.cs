using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalResult : MonoBehaviour
{
    public GameObject sparkleFlameEffect;
    public GameObject finalEffect;
    public GameObject feObject;
    public GameObject alObject;
    public GameObject finalObject;
    public GameObject mgRocket;
    public GameObject questionOne;
    public GameObject theoryUI;
    public GameObject smoke;
    public GameObject videoObject;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="SparkleEffectTrigger" && feObject.activeSelf && alObject.activeSelf){
            finalEffect.SetActive(true);
            sparkleFlameEffect.SetActive(false);
            mgRocket.SetActive(false);
            Invoke("DestroyFinalEffect", 2.5f);
            Invoke("ShowVideo", 2.0f);
            theoryUI.SetActive(false);
        }
    }

    void ShowVideo(){
        videoObject.SetActive(true);
        smoke.SetActive(true);
    }


    void DestroyFinalEffect(){
        finalEffect.SetActive(false);
        finalObject.SetActive(true);
        feObject.SetActive(false);
        alObject.SetActive(false);
    }
}
