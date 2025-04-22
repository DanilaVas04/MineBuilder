using UnityEngine;

public class ResizeObject2 : MonoBehaviour
{
    // ����������� ����������
    private Vector2 standardResolution2 = new Vector2(720, 1280);

    void Start()
    {
        // ��������� �������� ���������� ������
        Vector2 currentResolution = new Vector2(Screen.width, Screen.height);

        // ���������� ������������� ���������������
        float scaleFactorY = currentResolution.y / standardResolution2.y;

        // ��������������� �������
        transform.localScale = new Vector3(scaleFactorY, scaleFactorY, transform.localScale.z);
    }
}
