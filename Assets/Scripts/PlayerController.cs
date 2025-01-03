using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event System.Action OnPlayerDied;
    public static event System.Action<float, GameObject> OnPlayerTakeDamage; // ���a�l��ƥ�A�ǻ���e��q

    public float maxHealth = 100f; // �̤j��q
    private float currentHealth;

    public float moveSpeed = 5f;

    public float projectileSpeed = 6f;
    public float projectilePower = 5f;

    // ���ӭp�����
    private Camera mainCamera;
    private Vector3 screenBounds;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ��l����v��
        mainCamera = Camera.main;
        // �p����v����ɡ]�ഫ���@�ɮy�С^
        screenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(deltaX, deltaY, 0f);

        // �����m�b��v����ɤ�
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);

        transform.position = newPosition;
    }

    // �`�N�G�p�G�S���ҥ� PlayerController ���ܡA��q�|�O 0�A���ծɷ|�������`
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // �T�O��q���C��0

        OnPlayerTakeDamage?.Invoke(currentHealth / maxHealth, gameObject); // �q���l��ƥ�A�ǻ���e��q�ʤ���

        if (currentHealth <= 0)
        {
            OnPlayerDied?.Invoke();
            Destroy(gameObject); // ���a���`�A�P������
        }
    }


    void OnDestroy()
    {
        OnPlayerDied?.Invoke();
    }
}
