using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public AudioSource clickSE; //�]�����O�����s�������ڪ����g�b�o��
    public void ChangeScene(string sceneName)
    {
        clickSE.Play();
        SceneManager.LoadScene(sceneName);
    }
}
