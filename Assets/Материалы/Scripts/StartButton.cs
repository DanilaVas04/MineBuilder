using UnityEngine;

public class StartButton : MonoBehaviour
{
    public float amplitudeX = 1.0f;  // Амплитуда по оси X
    public float amplitudeY = 1.0f;  // Амплитуда по оси Y
    public float frequency = 1.0f;   // Частота движения

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
