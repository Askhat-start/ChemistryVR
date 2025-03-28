using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleLiquid : MonoBehaviour
{
    public Transform objectToScale;
    public float scaleIncreaseRate = 1.5f; // Rate at which scaling increases
    public float duration = 4f; // Duration of the scaling effect in seconds

    private float timer = 0f;
    private Vector3 initialScale;

    void Start()
    {
        // Store the initial scale of the object
        initialScale = objectToScale.localScale;
    }

    void Update()
    {
        if (timer < duration)
        {
            // Increment timer based on elapsed time
            timer += Time.deltaTime;

            // Calculate the scale factor based on the elapsed time
            float scaleFactor = Mathf.Pow(scaleIncreaseRate, timer);

            // Compute the new scale
            Vector3 newScale = initialScale;
            newScale.y *= scaleFactor;

            // Apply the new scale while keeping X and Z unchanged
            objectToScale.localScale = newScale;
        }
    }
}
