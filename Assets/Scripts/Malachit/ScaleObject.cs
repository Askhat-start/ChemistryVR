using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public Transform objectToScale;
    public float scaleIncreaseRate = 1.5f;
    public float duration = 4f;

    private float timer = 0f;
    private Vector3 initialScale;

    void Start()
    {
        initialScale = objectToScale.localScale;
    }

    void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
            float scaleFactor = Mathf.Pow(scaleIncreaseRate, timer);
            objectToScale.localScale = initialScale * scaleFactor;
        }
    }
}
