using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    public float speed = 10f;

    private RectTransform tr;
    private Vector2 backPosition;

    void Start()
    {
        tr = GetComponent<RectTransform>();
        backPosition = tr.anchoredPosition;
    }

    void Update()
    {
        MoveCloud();
    }

    private void MoveCloud()
    {
        backPosition.x += speed * Time.deltaTime;
        if (backPosition.x >= 1000f) { backPosition.x = -1000f; }
        tr.anchoredPosition = backPosition;
        transform.SetAsLastSibling();
    }
}
