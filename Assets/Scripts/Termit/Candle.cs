using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Candle : MonoBehaviour
{
    public GameObject headCandle;
    public GameObject flameEffect;
    public GameObject flameBurner;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FlameTrigger" & flameBurner.activeSelf){
            flameEffect.SetActive(true);
            headCandle.SetActive(false);
        }
    }
    
    void Effect(){
        flameEffect.SetActive(true);
        headCandle.SetActive(false);
    }

}
