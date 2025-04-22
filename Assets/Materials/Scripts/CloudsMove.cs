using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    public float speed = 1f;

    private Vector3 localBackPosition;

    void Start()
    {
        localBackPosition = transform.localPosition;
    }

    void Update()
    {
        MoveCloud();
    }

    private void MoveCloud()
    {
        localBackPosition.x += speed * Time.deltaTime;
        if (localBackPosition.x >= 4f) { localBackPosition.x = -4f; }
        transform.localPosition = localBackPosition;
        transform.SetAsLastSibling();
    }
}
