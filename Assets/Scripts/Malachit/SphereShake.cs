using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShake : MonoBehaviour
{
    public float shakeAmount = 0.1f;
    public float shakeSpeed = 5f;
    private bool isActive=false;
    public float minActivationInterval = 0.1f; // Минимальный интервал между активациями
    public float maxActivationInterval = 0.4f; // Максимальный интервал между активациями    private bool isActive = false; // Флаг для отслеживания активности объекта

    // Начальная позиция сферы
    private Vector3 initialPosition;

    void Start()
    {
        // Сохраняем начальную позицию сферы
        initialPosition = transform.position;
        Invoke("ToggleActivation", Random.Range(minActivationInterval, maxActivationInterval));
    }

    void ToggleActivation()
    {
        // Меняем состояние активации объекта
        isActive = !isActive;

        // Устанавливаем активность объекта в соответствии с флагом
        gameObject.SetActive(isActive);
        
        Invoke("ToggleActivation", Random.Range(minActivationInterval, maxActivationInterval));
    }

    void Update()
    {
        // Вычисляем смещение позиции сферы с помощью синусоиды для имитации дергания
        float offsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
        float offsetY = Mathf.Cos(Time.time * shakeSpeed) * shakeAmount;
        float offsetZ = Mathf.Sin(Time.time * shakeSpeed * 0.7f) * shakeAmount; // Немного изменяем частоту для Z, чтобы имитировать третье измерение
        
        // Применяем смещение к позиции сферы
        transform.position = initialPosition + new Vector3(offsetX, offsetY, offsetZ);
    }
}
