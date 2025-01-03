using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBarImage; // ����� Image �ե�
    public GameObject player; // ���p�����a
    private PlayerController playerController; // ���p�����a�}��

    public float maxHealth ; // �̤j��q
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
        // �q�\�l��ƥ�
        PlayerController.OnPlayerTakeDamage += UpdateHealthBar;
    }

    void OnDisable()
    {
        // �����q�\�ƥ�
        PlayerController.OnPlayerTakeDamage -= UpdateHealthBar;
    }


    private void UpdateHealthBar(float healthPercentage, GameObject damagedPlayer)
    {
        // �u��s�P����������p�����a
        if (damagedPlayer == player)
        {
            if (healthBarImage != null)
            {
                healthBarImage.fillAmount = healthPercentage;
            }
        }
    }
}
