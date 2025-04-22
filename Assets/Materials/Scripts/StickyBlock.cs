using UnityEngine;

public class StickyBlock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ��� ����������� � ������ ��������, ������� ����� Rigidbody2D
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            // ������� FixedJoint2D ��� �������� ��������
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = collision.rigidbody;
        }
        Rigidbody2D rigid = transform.GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
    }
}
