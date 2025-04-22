using UnityEngine;

public class StartButton : MonoBehaviour
{
    public float amplitudeX = 1.0f;  // ��������� �� ��� X
    public float amplitudeY = 1.0f;  // ��������� �� ��� Y
    public float frequency = 1.0f;   // ������� ��������

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MoveText();
    }

    private void MoveText()
    {
        float t = Time.time * frequency;
        float newX = startPosition.x + amplitudeX * Mathf.Sin(t);
        float newY = startPosition.y + amplitudeY * Mathf.Sin(2 * t);
        transform.position = new Vector3(newX, newY);
    }
}
