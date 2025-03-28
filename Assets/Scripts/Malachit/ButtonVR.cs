using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject press;
    public GameObject flameEffect;


    public void ActiveFlame(){
        press.transform.localPosition -= new Vector3(0f, 0.01f, 0f);
        flameEffect.SetActive(!flameEffect.activeSelf);
    }

    public void OnRelease(){
        press.transform.localPosition += new Vector3(0f, 0.01f, 0f);
    }

}
