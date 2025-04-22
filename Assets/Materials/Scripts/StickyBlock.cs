using UnityEngine;

public class StickyBlock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, что столкнулись с другим объектом, который имеет Rigidbody2D
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            // Создаем FixedJoint2D для фиксации объектов
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = collision.rigidbody;
        }
        Rigidbody2D rigid = transform.GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
    }
}
