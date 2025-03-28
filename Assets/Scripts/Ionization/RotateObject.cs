using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Переменные для управления скоростью вращения по осям X, Y и Z
    public float rotationSpeedX = 100f;
    public float rotationSpeedY = 100f;
    public float rotationSpeedZ = 100f;

    void Update()
    {
        // Получаем значения скорости вращения для каждой оси
        float rotationX = rotationSpeedX * Time.deltaTime;
        float rotationY = rotationSpeedY * Time.deltaTime;
        float rotationZ = rotationSpeedZ * Time.deltaTime;

        // Вращаем объект по осям X, Y и Z
        transform.Rotate(rotationX, rotationY, rotationZ);
    }
}
