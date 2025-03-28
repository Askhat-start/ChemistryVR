using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeSpheres : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    
    // Время задержки между активациями объектов
    public float activationDelay = 1f;
    
    // Текущий индекс активируемого объекта
    private int currentIndex = 0;
    
    void Start()
    {
        // Запуск корутины для поочередной активации объектов
        StartCoroutine(ActivateObjectsSequentially());
    }
    
    private IEnumerator ActivateObjectsSequentially()
    {
        while (currentIndex < objectsToActivate.Length)
        {
            // Активируем текущий объект
            objectsToActivate[currentIndex].SetActive(true);
            
            // Ждем заданное время перед активацией следующего объекта
            yield return new WaitForSeconds(activationDelay);
            
            // Переходим к следующему объекту
            currentIndex++;
        }
    }
}
