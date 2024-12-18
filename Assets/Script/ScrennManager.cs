using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrennManager : MonoBehaviour
{
    // 直前のディスプレイ向き
    DeviceOrientation PrevOrientation;

    // 端末の向きを取得するメソッド
    public DeviceOrientation getOrientation()
    {

        DeviceOrientation result = Input.deviceOrientation;

        // Unkownならピクセル数から判断
        if (result == DeviceOrientation.Unknown)
        {
            if (Screen.width < Screen.height)
            {
                result = DeviceOrientation.Portrait;

                //画面の向きを横に固定する処理

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
            // 画面の向きが変わった場合の処理


            PrevOrientation = currentOrientation;
        }
    }
}
