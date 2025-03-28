using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowderHandle : MonoBehaviour
{
    public GameObject[] gunpowderObjects; // Массив уже существующих элементов пороха
    public float effectInterval = 0.1f;   // Интервал между появлениями/исчезновениями
    public float moveDistance = 0.5f;     // Расстояние, на которое элемент будет перемещаться

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= effectInterval)
        {
            timer = 0f;

            foreach (GameObject gunpowder in gunpowderObjects)
            {
                if (Random.value < 0.5f) // Вероятность появления элемента
                {
                    gunpowder.SetActive(true);
                    // Переместите элемент в случайное положение в радиусе
                    Vector3 newPosition = gunpowder.transform.localPosition;
                    newPosition.x += Random.Range(-moveDistance, moveDistance);
                    gunpowder.transform.localPosition = newPosition;

                }
                else
                {
                    gunpowder.SetActive(false);
                }
            }
        }
    }

}
