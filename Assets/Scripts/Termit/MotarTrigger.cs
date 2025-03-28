using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotarTrigger : MonoBehaviour
{
    public GameObject fePeace;
    public GameObject alPeace;
    public GameObject feObject;
    public GameObject alObject;

    
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="SpoonTriggerHand"){

            if(gameObject.tag=="FeMotarTrigger"){
                fePeace.SetActive(true);
                alPeace.SetActive(false);
            }

            else if(gameObject.tag=="AlMotarTrigger"){
                fePeace.SetActive(false);
                alPeace.SetActive(true);
            }

            else if(gameObject.tag=="TermitMotarTrigger"){
                if(fePeace.activeSelf && !feObject.activeSelf) feObject.SetActive(true); 
                if(alPeace.activeSelf && !alObject.activeSelf) alObject.SetActive(true);
                fePeace.SetActive(false);
                alPeace.SetActive(false);
            }

        }
    
    }
}
