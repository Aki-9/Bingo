using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI���g�p�\�ɂ���

public class FadeScript : MonoBehaviour
{
    

    public float speed = 0.0005f;  //�������̑���
    public float alfa;    //A�l�𑀍삷�邽�߂̕ϐ�
    public bool fadeFlag = false;
    float red, green, blue;    //RGB�𑀍삷�邽�߂̕ϐ�

    //StoryManager���Q�Ƃł���悤�ɂ���
    public StoryManager storyManager;

    // Start is called before the first frame update
    void Start()
    {
        //Panel�̐F���擾
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

        //�t�F�[�h�C���E�A�E�g����
        if (fFadeFlag == true)//�t�F�[�h�C��
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;//�����x���グ��
        }
        else if (alfa > 0.01f && fadeFlag == false)//�t�F�[�h�A�E�g
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa -= speed;//�����x��������
        }
    }
}
