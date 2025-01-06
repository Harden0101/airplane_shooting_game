using System.Collections.Generic; // 引入命名空間
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // 參考子彈 prefab
    public string fireButton;            // 射擊按鍵名稱

    private List<GameObject> projectiles = new List<GameObject>(); // 子彈清單

    void Update()
    {
        if (Input.GetButtonDown(fireButton))
        {
            // 生成子彈並加入清單
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectiles.Add(projectileInstance); // 將子彈加入清單

            Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.SetShooter(gameObject); // 設置射擊者
            }
        }
    }

    public void DestroyAllProjectiles()
    {
        // 銷毀清單中的所有子彈
        foreach (GameObject projectile in projectiles)
        {
            if (projectile != null)
            {
                Destroy(projectile);
            }
        }

        // 清空清單
        projectiles.Clear();
    }

    private void OnDestroy()
    {
        // 銷毀玩家物件時清空子彈
        DestroyAllProjectiles();
    }
}
