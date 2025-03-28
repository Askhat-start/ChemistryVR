using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRotation : MonoBehaviour
{
     public float rotationSpeed = 100f;

    void Update()
    {
        // Получаем значение скорости вращения
        float rotation = rotationSpeed * Time.deltaTime;

        // Вращаем объект по оси Z
        transform.Rotate(0, 0, rotation);
    }
}
