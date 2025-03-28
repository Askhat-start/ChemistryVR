using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class FloatingObject : MonoBehaviour
{
    public float minHeight = 1.572f;
    public float maxHeight = 1.669f;
    public float floatingSpeed = 0.1f;
    private bool isTriggered = false;
    private GameObject metalObject;

    void Update()
    {   
        if(isTriggered){
            Invoke("FloatPosition", 1f);
        }
    }

    private void FloatPosition(){
        // Calculate the new y-coordinate using a sine wave to create a smooth floating motion
        float newY = Mathf.Lerp(minHeight, maxHeight, (Mathf.Sin(Time.time * floatingSpeed) + 1f) / 2f);

        // Update the object's position
        metalObject.transform.position = new Vector3(-0.1453176f, newY, 1.7704f);
        metalObject.transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MetalObject")){
            metalObject = other.gameObject;
            // Remove XR Grab Interactable Component
            XRGrabInteractable grabInteractable = metalObject.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                Destroy(grabInteractable);
            }

            // Remove Rigidbody component
            Rigidbody rb = metalObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Destroy(rb);
            }
            isTriggered = true;
            metalObject.transform.position = new Vector3(-0.1453176f, 1.572f, 1.669f);
        }
    }
}

