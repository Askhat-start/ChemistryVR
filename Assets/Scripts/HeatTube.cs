using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatTube : MonoBehaviour
{
    public GameObject gasParticles;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FlameTrigger")){
            Debug.Log("Tube Entered The Flame!");
            Invoke("InitializeGas", 4.0f);
        }
    }

    public void InitializeGas(){
        gasParticles.SetActive(true);
    }
}