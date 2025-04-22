using UnityEngine;

public class ResizeObject : MonoBehaviour
{
    // ����������� ����������
    private Vector2 standardResolution = new Vector2(720, 1280);

    void Start()
    {
        // ��������� �������� ���������� ������
        Vector2 currentResolution = new Vector2(Screen.width, Screen.height);

        // ���������� ������������� ���������������
        float scaleFactorY = currentResolution.y / standardResolution.y + 0.5f;

        // ��������������� �������
        transform.localScale = new Vector3(scaleFactorY, scaleFactorY, transform.localScale.z);
    }
}
