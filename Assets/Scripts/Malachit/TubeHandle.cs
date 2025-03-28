using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeHandle : MonoBehaviour
{
    public GameObject handleTube;
    public GameObject mainTube;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="MainTubeZone"){
            mainTube.SetActive(true);
            handleTube.SetActive(false);
        }
    }
}
