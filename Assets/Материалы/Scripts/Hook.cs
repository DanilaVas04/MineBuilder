using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hook : MonoBehaviour
{
    public GameObject objectPrefab;
    public Sprite[] sprites;
    public Canvas canvas;
    public Button button;
    public GameObject camera;

    private Image image;
    private HingeJoint2D hingeJoint;
    private Rigidbody2D connectedRigidbody;
    private Vector2 targetPosition; // Целевая позиция для камеры
    private float speed = 1f;

    void Start()
    {
        CreateBlock();
    }

    public void CreateBlock()
    {
        if (sprites.Length > 0)
        {
            int k = Random.Range(0, sprites.Length);

            GameObject newObject = Instantiate(objectPrefab, canvas.transform);
            RectTransform rectTransform = newObject.GetComponent<RectTransform>();
            hingeJoint = GetComponent<HingeJoint2D>();
            connectedRigidbody = newObject.GetComponent<Rigidbody2D>();
            hingeJoint.connectedBody = connectedRigidbody;
            button.transform.SetAsLastSibling();
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(0, 0);
            }

            image = newObject.GetComponent<Image>();

            if (image != null)
            {
                image.sprite = sprites[k];
            }
            else
            {
                Debug.LogError("Компонент Image не найден на объекте.");
            }
        }
        else
        {
            Debug.LogError("Массив sprites пустой.");
        }
    }

    public void DestroyHinge()
    {
        hingeJoint.connectedBody = null;
        targetPosition = new Vector2(camera.transform.position.x, camera.transform.position.y - 1.3f);
        StartCoroutine(WaitAndCreateBlock(1f));
    }

    private IEnumerator WaitAndCreateBlock(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CreateBlock();
    }

    void Update()
    {
        camera.transform.position = Vector2.Lerp(camera.transform.position, targetPosition, speed * Time.deltaTime);
    }
}
