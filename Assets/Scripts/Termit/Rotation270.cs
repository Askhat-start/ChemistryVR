using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class FlameMg : MonoBehaviour
{   
    public GameObject mgSparkle;
    public GameObject snapZone;

    public void SetRotation270()
    {
        Quaternion currentRotation = mgSparkle.transform.rotation;
        // Set the desired rotation.x
        Quaternion newRotation = Quaternion.Euler(270, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
        // Apply the new rotation to the GameObject
        mgSparkle.transform.rotation = newRotation;
    }


    
}
