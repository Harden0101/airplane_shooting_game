using UnityEngine;

public class Projectile : MonoBehaviour // �إ�projectile����
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
    private void OnTriggerEnter2D(Collider2D collision) // �w�q�l�u�I��
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") 
        {
            if (shooter.tag != collision.gameObject.tag)
            {
                PlayerController damagePlayerController = collision.gameObject.GetComponent<PlayerController>();
                if (damagePlayerController != null)
                {

                    damagePlayerController.TakeDamage(power); // �q�����a�l��
                }

                Destroy(gameObject);  //�R���l�u
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
