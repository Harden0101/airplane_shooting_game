using System.Collections.Generic; // �ޤJ�R�W�Ŷ�
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // �ѦҤl�u prefab
    public string fireButton;            // �g������W��

    private List<GameObject> projectiles = new List<GameObject>(); // �l�u�M��

    void Update()
    {
        if (Input.GetButtonDown(fireButton))
        {
            // �ͦ��l�u�å[�J�M��
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectiles.Add(projectileInstance); // �N�l�u�[�J�M��

            Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.SetShooter(gameObject); // �]�m�g����
            }
        }
    }

    public void DestroyAllProjectiles()
    {
        // �P���M�椤���Ҧ��l�u
        foreach (GameObject projectile in projectiles)
        {
            if (projectile != null)
            {
                Destroy(projectile);
            }
        }

        // �M�ŲM��
        projectiles.Clear();
    }

    private void OnDestroy()
    {
        // �P�����a����ɲM�Ťl�u
        DestroyAllProjectiles();
    }
}
