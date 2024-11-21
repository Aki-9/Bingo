using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonManager : MonoBehaviour
{
    //UI�Ƃ̕R�Â�
    [SerializeField]
    TextMeshProUGUI BingoFigure;//�񂷃{�^���������ĕ\������郉���_���Ȑ�����\������e�L�X�g

    [SerializeField]
    float padding = 2;//�Ԋu

    [SerializeField]
    Transform ballNumberParent;//BallNumber�̐e


    //�v���n�u
    public GameObject resultFigureTextPrefab;// �o��������I�u�W�F�N�g��ۑ����Ă���GameObejct�^�̕ϐ�
    public static ButtonManager instance;
    public int ballNumber;
    Vector3 position = Vector3.zero;


    //�{�^���̘A�Ŗh�~�ݒ�
    private bool buttonEnabled = true;//�{�^���̋@�\�I���ɂ���
    private WaitForSeconds waitOneSecond = new WaitForSeconds(1.0f);//�{�^���̑҂����Ԏw��


    //�����_���Ő������o�������͈͎̔w��
    int start = 1;
    int end = 99;

    
    //���X�g
    List<int> numberList = new List<int>();//�񂷃{�^�������������ۂɐ����������_���ɕ\�����邽�߂̃��X�g


    // Start is called before the first frame update 
    void Start()
    {
        //�w�肵���͈͂̐��������X�g�Ɋi�[���鏈��
        for (int i = start; i <= end; i++)
        {
            numberList.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�v���n�u��
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //�{�^���������ꂽ���̏���
    public void ButtonOnclick()
    {
        ButtonClicked();

    }

    //�{�^����A���ŉ����Ȃ��悤�ɂ��鏈��
    public void ButtonClicked()
    {
        // �������͓��삳���Ȃ�
        if (buttonEnabled == false)
        {
            return;
        }
        // ��������Ă��Ȃ��ꍇ
        else
        {
            Debug.Log("Clicked !!");
            buttonEnabled = false;// �{�^���̋@�\���I�t�ɂ���

            StartCoroutine(EnableButton());// ��莞�Ԍo�ߌ�ɋ@�\�̐���������
            RandomDischarge();
        }
    }

    // �{�^���̐�������������R���[�`��
    private IEnumerator EnableButton()
    {
        // 1�b��ɉ���         
        yield return waitOneSecond;
        buttonEnabled = true;
    }

    //�����������_���������e�L�X�g�ɔ��f�����鏈��
    public void RandomDischarge()
    {
        //�J��Ԃ�
        if(numberList.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, numberList.Count);

            int ransu = numberList[index];
            Debug.Log(ransu);

            numberList.RemoveAt(index);

            //�����𕶎���ɕϊ�
            string figure = ransu.ToString();

            //������^�̃f�[�^�ɕϊ��������̂��󂯓n��
            BingoFigure.SetText(figure);


            //�v���n�u��������
            ballNumber = ransu;
            Instantiate(resultFigureTextPrefab, position, Quaternion.identity, ballNumberParent);
            position.x += padding;//�J��Ԃ����x��X���ɑ�����

            //���������ׂďo�����̏���
            if (numberList.Count == 0)
            {
                BingoFigure.SetText("�r���S�I���I");
            }
        }
    }
}
