using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SpoonGet : MonoBehaviour
{
    public GameObject spoon;
    public GameObject left_hand;
    private Transform originalParent;
    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    public void GetSpoon(){
        originalParent = spoon.transform.parent;
        originalLocalPosition = spoon.transform.localPosition;
        originalLocalRotation = spoon.transform.localRotation;

        // Attach the spoon to the left hand controller
        spoon.transform.SetParent(left_hand.transform);
        spoon.transform.localPosition = Vector3.zero;
        spoon.transform.localRotation = Quaternion.identity;
    }

}
