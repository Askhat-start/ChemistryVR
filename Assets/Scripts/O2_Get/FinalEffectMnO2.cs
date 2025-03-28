using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEffectMnO2 : MonoBehaviour
{
    public GameObject h2o2_liquid;
    public GameObject MnO2_object;
    public GameObject black_liquid;
    public GameObject upper_liquid;
    public GameObject spheres;
    public GameObject throwerGas;
    public GameObject mal_peace;
    private bool alreadyDone = false;

    void Update(){
        if(h2o2_liquid.activeSelf && MnO2_object.activeSelf && !alreadyDone){
            Final();
            alreadyDone = true;
        } 
    }   

    void Final(){
        Invoke("BlackLiquid", 6.5f);
        Invoke("DeactivateH2O2", 7f);
        //upper_liquid.SetActive(true);
        Invoke("ActiveSpheresGas", 7.0f);
        Invoke("DeactivateThrower", 12f);
    }

    void BlackLiquid(){
        black_liquid.SetActive(true);
    }


    void DeactivateThrower(){
        throwerGas.SetActive(false);
    }
    void DeactivateH2O2(){
        h2o2_liquid.SetActive(false);
        mal_peace.SetActive(false);
    }

    void ActiveSpheresGas(){
        throwerGas.SetActive(true);
        spheres.SetActive(true);
    }
}
