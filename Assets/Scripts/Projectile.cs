using UnityEngine;

public class Projectile : MonoBehaviour // 建立projectile物件
{
    public float moveSpeed;
    public float power;
    private GameObject shooter;
    PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = shooter.GetComponent<PlayerController>();
        power = playerController.projectilePower;
        moveSpeed = playerController.projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter.tag == "Player1")
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else if (shooter.tag == "Player2")
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // 定義子彈碰撞
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") 
        {
            if (shooter.tag != collision.gameObject.tag)
            {
                PlayerController damagePlayerController = collision.gameObject.GetComponent<PlayerController>();
                if (damagePlayerController != null)
                {

                    damagePlayerController.TakeDamage(power); // 通知玩家損血
                }

                Destroy(gameObject);  //摧毀子彈
            }


        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }

    public void SetShooter(GameObject playerObject)
    {
        shooter = playerObject;
    }
}
