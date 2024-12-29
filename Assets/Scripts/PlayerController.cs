using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    private float hInput;
    private float vInput;

    private Rigidbody2D rb;

    // 拿來計算邊界
    private Camera mainCamera;
    private Vector3 screenBounds;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 初始化攝影機
        mainCamera = Camera.main;
        // 計算攝影機邊界（轉換為世界座標）
        screenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        hInput = Input.GetAxisRaw("Horizontal"); //設定水平輸入，按右鍵=1 左鍵=-1 不動作=0
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);

        vInput = Input.GetAxisRaw("Vertical"); //設定垂直輸入，按上=1 下=-1 不動作=0
        transform.Translate(Vector2.up * vInput * moveSpeed * Time.deltaTime);
        */

        float deltaX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(deltaX, deltaY, 0f);

        // 限制位置在攝影機邊界內
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);

        transform.position = newPosition;
    }

}
