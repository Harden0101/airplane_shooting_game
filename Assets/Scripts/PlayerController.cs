using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event System.Action<string> OnPlayerDied;
    public static event System.Action<float, GameObject> OnPlayerTakeDamage;

    public float maxHealth = 100f;
    private float currentHealth;

    public float moveSpeed = 5f;
    public float projectileSpeed = 6f;
    public float projectilePower = 5f;

    public GameObject projectilePrefab;

    public string horizontalInput; // 橫向輸入的按鍵名稱
    public string verticalInput;   // 縱向輸入的按鍵名稱

    private Camera mainCamera;
    private Vector3 screenBounds;

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
        currentHealth = maxHealth;
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float deltaX = Input.GetAxis(horizontalInput) * moveSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis(verticalInput) * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(deltaX, deltaY, 0f);

        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);

        transform.position = newPosition;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnPlayerTakeDamage?.Invoke(currentHealth / maxHealth, gameObject);

        if (currentHealth <= 0)
        {
            OnPlayerDied?.Invoke(gameObject.tag);
            Destroy(gameObject);
        }
    }

    /*
    void OnDestroy()
    {
        OnPlayerDied?.Invoke(gameObject.tag);
    }
    */
}
