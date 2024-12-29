using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    private float hInput;
    private float vInput;

    private Rigidbody2D rb;

    // ���ӭp�����
    private Camera mainCamera;
    private Vector3 screenBounds;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ��l����v��
        mainCamera = Camera.main;
        // �p����v����ɡ]�ഫ���@�ɮy�С^
        screenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        hInput = Input.GetAxisRaw("Horizontal"); //�]�w������J�A���k��=1 ����=-1 ���ʧ@=0
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);

        vInput = Input.GetAxisRaw("Vertical"); //�]�w������J�A���W=1 �U=-1 ���ʧ@=0
        transform.Translate(Vector2.up * vInput * moveSpeed * Time.deltaTime);
        */

        float deltaX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(deltaX, deltaY, 0f);

        // �����m�b��v����ɤ�
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBounds.x, screenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -screenBounds.y, screenBounds.y);

        transform.position = newPosition;
    }

}
