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

    //スタートボタンが押された時の処理
    public void ChangeScene()
    {
        //遅延処理
        Invoke("ChangeScene", 1.5f);
        //シーン遷移
        SceneManager.LoadScene("ExplanationScene");
    }

    //ゲーム終了処理
    public void Quit()
    {
        Application.Quit();
    }
}
