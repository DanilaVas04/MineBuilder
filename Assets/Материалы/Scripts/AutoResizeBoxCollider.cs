using UnityEngine;

public class AutoResizeBoxCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RectTransform rectTransform;

    void Start()
    {
        // ��������� �����������
        boxCollider = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();

        // ��������, ��� ���������� ������������
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D �� ������ �� �������.");
        }

        if (rectTransform == null)
        {
            Debug.LogError("RectTransform �� ������ �� �������.");
        }
        // ���������� ������� BoxCollider2D � ����������� �� ������� RectTransform
        if (boxCollider != null && rectTransform != null)
        {
            boxCollider.size = rectTransform.rect.size;
        }
    }
}
