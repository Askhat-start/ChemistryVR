using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustToCheck : MonoBehaviour
{
    public GameObject candleFlame;
    public GameObject headMGsparkle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(candleFlame.activeSelf);
        Debug.Log("X: " + headMGsparkle.transform.position.x + "Y: " + headMGsparkle.transform.position.y +  "Z: " + headMGsparkle.transform.position.z);
    }
}
