using UnityEngine;

public class Projectile2 : MonoBehaviour // 建立projectile物件
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
    private void OnTriggerEnter2D(Collider2D collision) // 定義子彈1碰撞
    {
        if (collision.gameObject.tag == "Player1") // 子彈2碰到player1
        {
            Destroy(collision.gameObject); //摧毀player1
            Destroy(gameObject);  //摧毀子彈
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
