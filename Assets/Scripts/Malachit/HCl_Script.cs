using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCl_Script : MonoBehaviour
{
    public GameObject hcl_leak;
    public GameObject hcl_liquid;
    public GameObject bankZone;
    bool entered_already = false;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="HCL_Trigger" && !entered_already){
            entered_already = true;
            hcl_leak.SetActive(true);
            bankZone.SetActive(true);
            Invoke("AppearLiquid", 1.5f);
            Invoke("DestroyLeak", 4.7f);
        }
    }               

    void AppearLiquid(){
        hcl_liquid.SetActive(true);
    }   

    void DestroyLeak(){
        hcl_leak.SetActive(false);
    }
        
}
