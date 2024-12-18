using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrennManager : MonoBehaviour
{
    // ���O�̃f�B�X�v���C����
    DeviceOrientation PrevOrientation;

    // �[���̌������擾���郁�\�b�h
    public DeviceOrientation getOrientation()
    {

        DeviceOrientation result = Input.deviceOrientation;

        // Unkown�Ȃ�s�N�Z�������画�f
        if (result == DeviceOrientation.Unknown)
        {
            if (Screen.width < Screen.height)
            {
                result = DeviceOrientation.Portrait;

                //��ʂ̌��������ɌŒ肷�鏈��

            }
            else
            {
                result = DeviceOrientation.LandscapeLeft;
            }
        }

        //Debug.Log(result);

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        PrevOrientation = getOrientation();
    }

    // Update is called once per frame
    void Update()
    {
        DeviceOrientation currentOrientation = getOrientation();
        if (PrevOrientation != currentOrientation)
        {
            // ��ʂ̌������ς�����ꍇ�̏���


            PrevOrientation = currentOrientation;
        }
    }
}
