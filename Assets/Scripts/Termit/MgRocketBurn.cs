using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgRocketBurn : MonoBehaviour
{
    public GameObject sparkleFlameEffect;
    public GameObject spuskObject;
    public GameObject candleFlame;

    public GameObject mgSparkle;
    public GameObject candleObject;
    private bool inSnapZone=false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="CandleFlame" && candleFlame.activeSelf && inSnapZone){
            sparkleFlameEffect.SetActive(true);
            spuskObject.SetActive(true);
            Invoke("CandleFalse", 1.5f);
        }
        else if(other.gameObject.tag=="SnapZoneTermit"){
            Triggered();
            inSnapZone = true;
        }
    }

    void CandleFalse(){
        candleObject.SetActive(false);
    }

    public void Triggered(){
        BoxCollider boxCollider = mgSparkle.GetComponent<BoxCollider>();

        if (boxCollider != null)
        {
            // Set the isTrigger property to true
            boxCollider.isTrigger = true;
        }
    }
}
