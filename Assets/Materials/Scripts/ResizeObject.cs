using UnityEngine;

public class ResizeObject : MonoBehaviour
{
    // Стандартное разрешение
    private Vector2 standardResolution = new Vector2(720, 1280);

    void Start()
    {
        // Получение текущего разрешения экрана
        Vector2 currentResolution = new Vector2(Screen.width, Screen.height);

        // Вычисление коэффициентов масштабирования
        float scaleFactorY = currentResolution.y / standardResolution.y + 0.5f;

        // Масштабирование объекта
        transform.localScale = new Vector3(scaleFactorY, scaleFactorY, transform.localScale.z);
    }
}
