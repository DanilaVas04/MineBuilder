using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Hook : MonoBehaviour
{
    public GameObject block;
    public Sprite[] sprites;
    public GameObject background;
    public GameObject sky;
    public GameObject[] scoreObject;

    private HingeJoint2D hingeJoint;
    private float speed = 1f;
    private bool isButton = true;
    private float l = 1;
    private Color skyColor;
    private TextMeshProUGUI score;
    private Vector3 vector;
    private SpriteRenderer sprite;

    void Start()
    {
        hingeJoint = transform.GetComponent<HingeJoint2D>();
        skyColor = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        CreateBlock();       
    }

    public void CreateBlock()
    {
        GameObject newObject = Instantiate(block, new Vector3(0,0,-3), Quaternion.identity);
        sprite = newObject.GetComponent<SpriteRenderer>();
        int index = Random.Range(0,sprites.Length);
        sprite.sprite = sprites[index];
        GameObject newSky = Instantiate(sky, background.transform);
        newSky.transform.position = new Vector3(newSky.transform.position.x, 10 * l, -1);
        l+=0.1f;
        if (skyColor.r > 0)
        {
            skyColor.r -= 1 / 255f;
            skyColor.g -= 1 / 255f;
            skyColor.b -= 1 / 255f;
        }
        sprite = newSky.GetComponent<SpriteRenderer>();
        sprite.color = new Color(skyColor.r, skyColor.g, skyColor.b);
        hingeJoint.connectedBody = newObject.GetComponent<Rigidbody2D>();       
    }

    public void DestroyHinge()
    {
        if (isButton)
        {
            vector = new Vector2(background.transform.position.x, background.transform.position.y - 1.1f);
            isButton = false;
            hingeJoint.connectedBody = null;           
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
        if (!isButton)
        {
            background.transform.position = Vector2.Lerp(background.transform.position, vector, speed * Time.deltaTime);           
        }                
    }
}
