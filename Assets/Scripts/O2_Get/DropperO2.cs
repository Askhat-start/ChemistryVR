using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperO2 : MonoBehaviour
{
    public GameObject H2O2_leak;
    public GameObject H2O2_Liquid;
    private bool alreadyDone = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TubeTrigger" && !alreadyDone){
            H2O2_leak.SetActive(true);
            Invoke("AppearLiquid", 2.5f);
            Invoke("DestroyLeak", 7.5f);
            alreadyDone = true;
        }
    }

    void DestroyLeak(){
        Destroy(H2O2_leak);
    }

    void AppearLiquid(){
        H2O2_Liquid.SetActive(true);
    }
}
