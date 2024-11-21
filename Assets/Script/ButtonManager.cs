using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonManager : MonoBehaviour
{
    //UIとの紐づけ
    [SerializeField]
    TextMeshProUGUI BingoFigure;//回すボタンを押して表示されるランダムな数字を表示するテキスト

    [SerializeField]
    float padding = 2;//間隔

    [SerializeField]
    Transform ballNumberParent;//BallNumberの親


    //プレハブ
    public GameObject resultFigureTextPrefab;// 出現させるオブジェクトを保存しておくGameObejct型の変数
    public static ButtonManager instance;
    public int ballNumber;
    Vector3 position = Vector3.zero;


    //ボタンの連打防止設定
    private bool buttonEnabled = true;//ボタンの機能オンにする
    private WaitForSeconds waitOneSecond = new WaitForSeconds(1.0f);//ボタンの待ち時間指定


    //ランダムで数字を出す処理の範囲指定
    int start = 1;
    int end = 99;

    
    //リスト
    List<int> numberList = new List<int>();//回すボタンを押下した際に数字をランダムに表示するためのリスト


    // Start is called before the first frame update 
    void Start()
    {
        //指定した範囲の数字をリストに格納する処理
        for (int i = start; i <= end; i++)
        {
            numberList.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プレハブが
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //ボタンが押された時の処理
    public void ButtonOnclick()
    {
        ButtonClicked();

    }

    //ボタンを連続で押せないようにする処理
    public void ButtonClicked()
    {
        // 制限中は動作させない
        if (buttonEnabled == false)
        {
            return;
        }
        // 制限されていない場合
        else
        {
            Debug.Log("Clicked !!");
            buttonEnabled = false;// ボタンの機能をオフにする

            StartCoroutine(EnableButton());// 一定時間経過後に機能の制限を解除
            RandomDischarge();
        }
    }

    // ボタンの制限を解除するコルーチン
    private IEnumerator EnableButton()
    {
        // 1秒後に解除         
        yield return waitOneSecond;
        buttonEnabled = true;
    }

    //数字をランダム生成しテキストに反映させる処理
    public void RandomDischarge()
    {
        //繰り返す
        if(numberList.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, numberList.Count);

            int ransu = numberList[index];
            Debug.Log(ransu);

            numberList.RemoveAt(index);

            //数字を文字列に変換
            string figure = ransu.ToString();

            //文字列型のデータに変換したものを受け渡す
            BingoFigure.SetText(figure);


            //プレハブ生成処理
            ballNumber = ransu;
            Instantiate(resultFigureTextPrefab, position, Quaternion.identity, ballNumberParent);
            position.x += padding;//繰り返される度にX軸に増える

            //数字がすべて出た時の処理
            if (numberList.Count == 0)
            {
                BingoFigure.SetText("ビンゴ終了！");
            }
        }
    }
}
