using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private StoryData[] storyDatas;
    [SerializeField] private Image background;
    [SerializeField] private Image andkunImage;
    [SerializeField] private Image sorukunImage;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private TextMeshProUGUI explantionText;
    [SerializeField] private TextMeshProUGUI characterName;

    //ストーリーのエレメント配列番号が必要なのでプロパティを
    public int storyIndex { get; private set; }
    public int textIndex { get; private set; }

    //テキストがすべて表示されたかどうか
    private bool finishText = false;

    // Start is called before the first frame update
    void Start()
    {
        storyText.text = "";
        characterName.text = "";
        SetStoryElement(storyIndex, textIndex);

        // 左向きを有効にする
        Screen.autorotateToLandscapeLeft = true;
        // 右向きを有効にする
        Screen.autorotateToLandscapeRight = true;

        // 画面の向きを自動回転に設定する
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    private void Update()
    {
     if ((Input.GetKeyDown(KeyCode.Return) && finishText == true) || (Input.GetMouseButtonDown(0) && finishText == true))
        {
            textIndex++;//インデックスを増やす
            //テキスト部を初期化して
            storyText.text = "";
            explantionText.text = "";
            ProgressionStory(storyIndex);
            finishText = false;
        }
    }
    private void ProgressionStory(int _storyIndex)
    {
        //ストーリーインデックスよりも大きいテキストは存在しないのでチェックして対応
        if (textIndex < storyDatas[_storyIndex].stories.Count)
        {
            //次に表示させるストーリーデータがある場合はセットする処理
            SetStoryElement(_storyIndex, textIndex);
        }
        else
        {
            //表示させるストーリーデータがなくなった後の処理
            Debug.Log("説明終了");
        }
    }

    //文字を1文字づつ表示するコルーチン
    private IEnumerator TypeSentence(int _storyIndex, int _textIndex)
    {
        //１文字づつ文字を分割した状態にする
        foreach (var letter in storyDatas[_storyIndex].stories[_textIndex].StoryText.ToCharArray())
        {
            storyText.text += letter;//1文字表示
            yield return new WaitForSeconds(0.05f);
        }
        finishText = true;
    }

    //呼び出しメソッド
    private void SetStoryElement(int _storyIndex, int _textIndex)
    {
        //同じ言葉をまとめておくためのvar
        var storyElement = storyDatas[_storyIndex].stories[_textIndex];
        
        //どのストーリーデータの、どのバックグランドか
        background.sprite = storyElement.Background;
        
        //どのストーリーデータの、どのキャラクタか
        andkunImage.sprite = storyElement.AndkunImage;
        sorukunImage.sprite = storyElement.SorukunImage;

        //どのストーリーデータの、どのテキストか
        // storyText.text = storyElement.StoryText;
        //1文字づつ表示するコルーチン
        StartCoroutine(TypeSentence(_storyIndex, _textIndex));

        // どのストーリーデータの、どのテキストか
        explantionText.text = storyElement.ExplantionText;
        
        //どのストーリーデータの、どのキャラ名か
        characterName.text = storyElement.CharacterName;
    }
}
