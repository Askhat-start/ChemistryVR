using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class O2TubeHandler : MonoBehaviour
{
    public bool isO2 = false;
    public GameObject flame;
    public GameObject mainTube;
    public float newSize;
    public float oldSize;
    public GameObject flameObject;
    public ParticleSystem flameParticle;
    public GameObject headCandle;
    public GameObject bunsenBurnerFlame;
    public GameObject gasTube;
    public Vector3 checkPositionForGasTube;
    public bool actionDone = false;
    public bool secondActionDone = false;
    public GameObject gunPowder;
    public GameObject blackLiquid;
    public GameObject questionOne;
    public GameObject theoryOne;
    public GameObject theoryTwo;
    public GameObject blackHead;
    public GameObject woodHead;

    
    //public GameObject triggerForCheck;

    void Update(){
        if(flame.activeSelf && mainTube.activeSelf && gasTube.transform.position == checkPositionForGasTube){
            if(!actionDone){
                Invoke("PutTrueO2", 5.5f);
                actionDone = true;
            }
            Collider collider = gasTube.GetComponent<Collider>();
            collider.isTrigger = true;
            //Debug.Log("You can check the O2!");
            //triggerForCheck.SetActive(true);
        }
        else if(flame.activeSelf && mainTube.activeSelf && gasTube.transform.position != new Vector3(-0.3404733f, 1.54275f, -0.6745174f)){
            if(!secondActionDone){
                Invoke("SmashPowder", 3f);
                Invoke("StopSmashing", 10f);
                secondActionDone = true;
            }
        }
    }
    void SmashPowder(){
        gunPowder.SetActive(true);
    }

    void StopSmashing(){
        Destroy(gunPowder);
    }

    void PutTrueO2(){
        isO2 = true;
    }
    private bool doneOne;
    private bool doneTwo;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BunsenBurner"){
            headCandle.SetActive(false);
            flameObject.SetActive(true);
            blackHead.SetActive(true);
            woodHead.SetActive(false);
        }

        else if(other.gameObject.tag == "CheckO2" && isO2 && flameObject.activeSelf){
            var mainModule = flameParticle.main;
            mainModule.startSize = newSize;
            doneOne = true;
        }

        else if(other.gameObject.tag == "CheckO2MnO2" && blackLiquid.activeSelf){
            var mainModule = flameParticle.main;
            mainModule.startSize = newSize;
            doneTwo = true;
        }

        if(doneOne && doneTwo){
            questionOne.SetActive(true);
            theoryOne.SetActive(false);
            theoryTwo.SetActive(false);
        }
    }


    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "CheckO2" && isO2 && flameObject.activeSelf){
            var mainModule = flameParticle.main;
            mainModule.startSize = oldSize;
            Invoke("DeactivateCane", 3.5f);
        }

        else if(other.gameObject.tag == "CheckO2MnO2" && blackLiquid.activeSelf){
            var mainModule = flameParticle.main;
            mainModule.startSize = oldSize;
            Invoke("DeactivateCane", 3.5f);
        }
        
    }

    void DeactivateCane(){
        flameObject.SetActive(false);
    }
}
