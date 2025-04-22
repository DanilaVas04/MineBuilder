using TMPro;
using UnityEngine;

public class MenuEndGame : MonoBehaviour
{
    public static bool isEnd = false;
    public GameObject hook;
    public GameObject[] buttons;
    public float speed = 1f;
    private RectTransform rectTransform;
    private Vector2 targetPosition;

    private void Start()
    {
        isEnd = false;
        rectTransform = GetComponent<RectTransform>();
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            targetPosition = new Vector2(0, 0);
        }
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
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, speed * Time.deltaTime);
        }
    }
}
