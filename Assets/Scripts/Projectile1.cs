using UnityEngine;

public class Projectile1 : MonoBehaviour // �إ�projectile����
{
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision) // �w�q�l�u1�I��
    {
        if (collision.gameObject.tag == "Player2") // �l�u1�I��player2
        {
            Destroy(collision.gameObject); //�R��player2
            Destroy(gameObject);  //�R���l�u
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
