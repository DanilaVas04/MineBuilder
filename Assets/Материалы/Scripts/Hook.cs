using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Hook : MonoBehaviour
{
    public GameObject objectPrefab;
    public Sprite[] sprites;
    public Canvas canvas;
    public Button button;
    public GameObject camera;
    public GameObject sky;
    public GameObject[] buttons;
    public GameObject[] scoreObject;

    private Image image;
    private HingeJoint2D hingeJoint;
    private Rigidbody2D connectedRigidbody;
    private Vector2 targetPosition;
    private float speed = 1f;
    private bool isButton = true;
    private int l = 1;
    private Color skyColor;
    private TextMeshProUGUI score;

    void Start()
    {
        CreateBlock();
        targetPosition = new Vector2(camera.transform.position.x, camera.transform.position.y);
        skyColor = new Color(245 / 255f, 245 / 255f, 240 / 245f);
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
            foreach (GameObject b in buttons)
            {
                b.transform.SetAsLastSibling();
            }
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
        if (isButton)
        {
            isButton = false;
            hingeJoint.connectedBody = null;
            targetPosition = new Vector2(camera.transform.position.x, camera.transform.position.y - 1.1f);
            score = scoreObject[0].GetComponent<TextMeshProUGUI>();
            score.text = (int.Parse(score.text) + 10).ToString();
            score = scoreObject[1].GetComponent<TextMeshProUGUI>();
            score.text = (int.Parse(score.text) + 10).ToString();
            StartCoroutine(WaitAndCreateBlock(2f));
        }      
    }

    private IEnumerator WaitAndCreateBlock(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isButton = true;
        CreateBlock();
    }

    void Update()
    {
        camera.transform.position = Vector2.Lerp(camera.transform.position, targetPosition, speed * Time.deltaTime);
        if (camera.transform.position.y<-9-l)
        {
            GameObject newSkyObject = Instantiate(sky, camera.transform);
            RectTransform rectTransform = newSkyObject.GetComponent<RectTransform>();
            Image imageSky = newSkyObject.GetComponent<Image>();
            imageSky.color = skyColor;
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition = new Vector2(0, 2000+150*l);
            }
            l+=2;
            if (skyColor.r>0)
            {
                skyColor.r -= 1 / 255f;
                skyColor.g -= 1 / 255f;
                skyColor.b -= 1 / 255f;
            }           
        }
    }
}
