using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScnesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    //�X�^�[�g�{�^���������ꂽ���̏���
    public void ChangeScene()
    {
        //�x������
        Invoke("ChangeScene", 1.5f);
        //�V�[���J��
        SceneManager.LoadScene("ExplanationScene");
    }

    //�Q�[���I������
    public void Quit()
    {
        Application.Quit();
    }
}
