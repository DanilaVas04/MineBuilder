using UnityEngine;

public class MenuEndGame : MonoBehaviour
{
    public static bool isEnd = false;
    public GameObject hook;
    public GameObject[] buttons;
    public float speed = 1f;

    private Vector2 targetPosition;


    private void Start()
    {
        targetPosition = new Vector2(0, 0);
        isEnd = false;
    }

    private void Update()
    {
        if (isEnd)
        {
            hook.SetActive(false);
            foreach (GameObject button in buttons)
            {
                button.SetActive(false);
            }
            transform.SetAsLastSibling();
            transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
