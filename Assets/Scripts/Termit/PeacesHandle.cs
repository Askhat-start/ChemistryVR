using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeacesHandle : MonoBehaviour
{
    public GameObject fePeace;
    public GameObject alPeace;
    public GameObject spoonHand;
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Success!");
        fePeace.SetActive(true);
        if(other.gameObject.tag=="FeMotarTrigger"){
            Debug.Log("FeMotarTrigger!");
            fePeace.SetActive(true);
            alPeace.SetActive(false);
        }
        else if(other.gameObject.tag=="AlMotarTrigger"){
            Debug.Log("AlMotarTrigger!");
            alPeace.SetActive(true);
            fePeace.SetActive(false);
        }

    }

}
