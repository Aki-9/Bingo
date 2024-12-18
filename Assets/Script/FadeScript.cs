using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UIを使用可能にする

public class FadeScript : MonoBehaviour
{
    

    public float speed = 0.0005f;  //透明化の速さ
    public float alfa;    //A値を操作するための変数
    public bool fadeFlag = false;
    float red, green, blue;    //RGBを操作するための変数

    //StoryManagerを参照できるようにした
    public StoryManager storyManager;

    // Start is called before the first frame update
    void Start()
    {
        //Panelの色を取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        bool fFadeFlag;
        fFadeFlag = storyManager.flag;

        //フェードイン・アウト処理
        if (fFadeFlag == true)//フェードイン
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;//透明度を上げる
        }
        else if (alfa > 0.01f && fadeFlag == false)//フェードアウト
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa -= speed;//透明度を下げる
        }
    }
}
