using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class MalachitTrigger : MonoBehaviour
{
    public GameObject malPeace;
    public GameObject malObjects;
    public GameObject tubeZone;
    public BoxCollider boxCollider;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="MalMotarTrigger"){
            malPeace.SetActive(true);
        }
        else if(other.gameObject.tag=="MainTubeTrigger" && malPeace.activeSelf){
            malObjects.SetActive(true);
            tubeZone.SetActive(true);
            malPeace.SetActive(false);
            boxCollider.isTrigger = false;
        }
    }
}
