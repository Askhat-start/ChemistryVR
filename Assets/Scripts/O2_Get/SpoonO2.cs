using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonO2 : MonoBehaviour
{
    public GameObject powderSpoon;
    public GameObject powderInTube;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="MalMotarTrigger" && !powderSpoon.activeSelf){
            powderSpoon.SetActive(true);
        }

        else if (other.gameObject.tag == "TubeTrigger" && powderSpoon.activeSelf){
            powderInTube.SetActive(true);
            powderSpoon.SetActive(false);
        }
    }
}
