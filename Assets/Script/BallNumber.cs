using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallNumber : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI BingoFigure;//�񂷃{�^���������ĕ\������郉���_���Ȑ�����\������e�L�X�g

    public int myNumber;

    void Start()
    {
        myNumber = ButtonManager.instance.ballNumber;

        //�����𕶎���ɕϊ�
        string figure = ButtonManager.instance.ballNumber.ToString();
        BingoFigure.SetText(figure);
    }
}
