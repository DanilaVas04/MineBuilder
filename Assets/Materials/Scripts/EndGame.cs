using UnityEngine;

public class EndGame : MonoBehaviour
{
    public MenuEndGame mng;

    private void Start()
    {
        mng = FindAnyObjectByType<MenuEndGame>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = collision.rigidbody;
            mng.GameOver();
        }
    }
}
