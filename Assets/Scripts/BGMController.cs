using UnityEngine;

public class BGMController : MonoBehaviour
{
    public static BGMController Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
