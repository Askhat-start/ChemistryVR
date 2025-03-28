using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZnHolder : MonoBehaviour
{
    public GameObject znObject;
    
    public float minHeight;
    public float maxHeight;
    public float floatingSpeed; // Added floating speed variable
    public GameObject hcl_liquid;
    public GameObject boiling_system;
    public GameObject h2_system;
     public GameObject[] objectsToInitialize; // Массив объектов для инициализации
    public float initializationInterval = 0.8f; // Интервал между инициализациями
    private int currentIndex = 0; // Текущий индекс объекта для инициализации
    bool entered = false;

    private void Update()
    {
        if(entered){
            FloatPosition(); // Call FloatPosition every frame for continuous floating
        }
        //MAIN REACTION OF ZN AND HCL
        if(entered && hcl_liquid.activeSelf){
            Invoke("InitializeObjects", 4f);
            Invoke("EffectH2", 3f);
        }
    }

    void EffectH2(){
        boiling_system.SetActive(true);
        h2_system.SetActive(true);
    }

    void InitializeObjects(){
        StartCoroutine(InitializeObjectsCoroutine());
    }

    IEnumerator InitializeObjectsCoroutine()
    {
        // Проходим по массиву объектов
        while (currentIndex < objectsToInitialize.Length)
        {
            // Делаем текущий объект активным
            objectsToInitialize[currentIndex].SetActive(true);
            currentIndex++; // Увеличиваем индекс для следующего объекта

            // Ждем указанный интервал перед инициализацией следующего объекта
            yield return new WaitForSeconds(initializationInterval);
        }
    }

    private void FloatPosition()
    {
        float newY = Mathf.Lerp(minHeight, maxHeight, (Mathf.Sin(Time.time * floatingSpeed) + 1f) / 2f);
        znObject.transform.position = new Vector3(-12.432f, 4.210319f, -14.514f);
        znObject.transform.rotation = Quaternion.identity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropZone")
        {
            entered = true;
        }
    }
}

