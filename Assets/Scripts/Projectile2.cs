using UnityEngine;

public class Projectile2 : MonoBehaviour // �إ�projectile����
{
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) // �w�q�l�u1�I��
    {
        if (collision.gameObject.tag == "Player1") // �l�u2�I��player1
        {
            Destroy(collision.gameObject); //�R��player1
            Destroy(gameObject);  //�R���l�u
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
