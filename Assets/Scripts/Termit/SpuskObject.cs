using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpuskObject : MonoBehaviour
{
    public GameObject sparkleFlameEffect;
    public float speed = 0.09f; // скорость спуска
    public float maxY = -0.989f; // значение Y, до которого объект будет спускаться


    // Update is called once per frame
    void Update()
    {
        if (sparkleFlameEffect.transform.position.y > maxY)
        {
            // Вычисляем новую позицию объекта
            Vector3 newPosition = new Vector3(sparkleFlameEffect.transform.position.x, sparkleFlameEffect.transform.position.y - (speed * Time.deltaTime), sparkleFlameEffect.transform.position.z);

            // Применяем новую позицию объекта
            sparkleFlameEffect.transform.position = newPosition;
        }
    }
}
