using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    public float speed = 1f;

    private Transform tr;
    private Vector2 backPosition;

    void Start()
    {
        tr = GetComponent<Transform>();
        backPosition = tr.position;
    }

    void Update()
    {
        MoveCloud();
    }

    private void MoveCloud()
    {
        backPosition.x += speed * Time.deltaTime;
        if (backPosition.x >= 6f) { backPosition.x = -6f; }
        tr.position = backPosition;
    }

    public void downMove()
    {

    }
}
