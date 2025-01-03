using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBarImage; // 血條的 Image 組件
    public GameObject player; // 關聯的玩家
    private PlayerController playerController; // 關聯的玩家腳本

    public float maxHealth ; // 最大血量
    private float currentHealth;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        healthBarImage = GetComponent<Image>();
        currentHealth = playerController.maxHealth;
        healthBarImage.fillAmount = 1;
    }

    void OnEnable()
    {
        // 訂閱損血事件
        PlayerController.OnPlayerTakeDamage += UpdateHealthBar;
    }

    void OnDisable()
    {
        // 取消訂閱事件
        PlayerController.OnPlayerTakeDamage -= UpdateHealthBar;
    }


    private void UpdateHealthBar(float healthPercentage, GameObject damagedPlayer)
    {
        // 只更新與此血條相關聯的玩家
        if (damagedPlayer == player)
        {
            if (healthBarImage != null)
            {
                healthBarImage.fillAmount = healthPercentage;
            }
        }
    }
}
