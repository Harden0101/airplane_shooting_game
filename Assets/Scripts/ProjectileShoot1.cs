using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  //�nrefer prefab����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // �YFirel�QĲ�o
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity); // �ͦ��l�u (�n�ͦ���prefab����, �ͦ���m, ����(identity��������))
        }
    }


}
