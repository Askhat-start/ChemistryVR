using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTubeZone : MonoBehaviour
{
    public GameObject dropZone;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Dropper"){
            dropZone.SetActive(false);
        }
    }
}
