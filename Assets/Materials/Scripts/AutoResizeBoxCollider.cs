using UnityEngine;

public class AutoResizeBoxCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RectTransform rectTransform;

    void Start()
    {
        // Получение компонентов
        boxCollider = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();

        // Проверка, что компоненты присутствуют
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D не найден на объекте.");
        }

        if (rectTransform == null)
        {
            Debug.LogError("RectTransform не найден на объекте.");
        }
        // Обновление размера BoxCollider2D в зависимости от размера RectTransform
        if (boxCollider != null && rectTransform != null)
        {
            boxCollider.size = rectTransform.rect.size;
        }
    }
}
