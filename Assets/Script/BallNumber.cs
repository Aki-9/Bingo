using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallNumber : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI BingoFigure;//回すボタンを押して表示されるランダムな数字を表示するテキスト

    public int myNumber;

    void Start()
    {
        myNumber = ButtonManager.instance.ballNumber;

        //数字を文字列に変換
        string figure = ButtonManager.instance.ballNumber.ToString();
        BingoFigure.SetText(figure);
    }
}
