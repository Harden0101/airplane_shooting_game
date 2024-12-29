using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  //要refer prefab物件

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // 若Firel被觸發
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity); // 生成子彈 (要生成的prefab物件, 生成位置, 旋轉(identity為不旋轉))
        }
    }


}
