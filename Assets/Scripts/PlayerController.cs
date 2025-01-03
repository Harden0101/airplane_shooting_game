using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event System.Action OnPlayerDied;
    public static event System.Action<float, GameObject> OnPlayerTakeDamage; // 玩家損血事件，傳遞當前血量

    public float maxHealth = 100f; // 最大血量
    private float currentHealth;

    public float moveSpeed = 5f;

    public float projectileSpeed = 6f;
    public float projectilePower = 5f;

    // 拿來計算邊界
    private Camera mainCamera;
    private Vector3 screenBounds;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 初始化攝影機
        mainCamera = Camera.main;
        // 計算攝影機邊界（轉換為世界座標）
        screenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(deltaX, deltaY, 0f);

        // 限制位置在攝影機邊界內
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);

        transform.position = newPosition;
    }

    // 注意：如果沒有啟用 PlayerController 的話，血量會是 0，測試時會直接死亡
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 確保血量不低於0

        OnPlayerTakeDamage?.Invoke(currentHealth / maxHealth, gameObject); // 通知損血事件，傳遞當前血量百分比

        if (currentHealth <= 0)
        {
            OnPlayerDied?.Invoke();
            Destroy(gameObject); // 玩家死亡，銷毀物件
        }
    }


    void OnDestroy()
    {
        OnPlayerDied?.Invoke();
    }
}
