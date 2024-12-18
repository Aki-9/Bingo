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
    [SerializeField] private Image rightImage;
    [SerializeField] private Image leftImage;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private TextMeshProUGUI explantionText;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private GameObject fadePanel;

    //�X�g�[���[�̃G�������g�z��ԍ����K�v�Ȃ̂Ńv���p�e�B��ύX
    public int storyIndex { get; private set; }
    public int textIndex { get; private set; }

    //�e�L�X�g�����ׂĕ\�����ꂽ���ǂ���
    private bool finishText = false;

    //FadeScript���Q�Ƃł���悤�ɂ���
    public FadeScript fadeScript;

    public bool flag = false;

    // Start is called before the first frame update
    public void Start()
    {
        storyText.text = "";
        characterName.text = "";
        SetStoryElement(storyIndex, textIndex);
        fadePanel.SetActive(true);

        // ��������L���ɂ���
        Screen.autorotateToLandscapeLeft = true;
        // �E������L���ɂ���
        Screen.autorotateToLandscapeRight = true;

        // ��ʂ̌�����������]�ɐݒ肷��
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    private void Update()
    {
        float cAlfa;//A�l�𑀍삷�邽�߂̕ϐ�
        cAlfa = fadeScript.alfa;

        Debug.Log("alfa�l��" + cAlfa);

        if ((Input.GetKeyDown(KeyCode.Return) && finishText == true && cAlfa < 0.2) || (Input.GetMouseButtonDown(0) && finishText == true && cAlfa < 0.2))//��ŏ���������
        {
            textIndex++;//�C���f�b�N�X�𑝂₷

            //�e�L�X�g����������
            storyText.text = "";
            explantionText.text = "";
            ProgressionStory(storyIndex);
            finishText = false;
        }
    }
    private void ProgressionStory(int _storyIndex)
    {
        //�X�g�[���[�C���f�b�N�X�����傫���e�L�X�g�͑��݂��Ȃ��̂Ń`�F�b�N���đΉ�
        if (textIndex < storyDatas[_storyIndex].stories.Count)
        {
            //���ɕ\��������X�g�[���[�f�[�^������ꍇ�̓Z�b�g���鏈��
            SetStoryElement(_storyIndex, textIndex);
        }
        else
        {
            //�\��������X�g�[���[�f�[�^���Ȃ��Ȃ�����̏���
            //�t�F�[�h�C�������̃t���O��true�ɕύX
            flag = true;
        }
    }

    //������1�����Â\������R���[�`��
    private IEnumerator TypeSentence(int _storyIndex, int _textIndex)
    {
        //�P�����Â����𕪊�������Ԃɂ���
        foreach (var letter in storyDatas[_storyIndex].stories[_textIndex].StoryText.ToCharArray())
        {
            storyText.text += letter;//1�����\��
            yield return new WaitForSeconds(0.025f);//�K���X�s�[�h�F0.025f
        }
        finishText = true;
    }

    //�Ăяo�����\�b�h
    private void SetStoryElement(int _storyIndex, int _textIndex)
    {
        //�������t���܂Ƃ߂Ă������߂�var
        var storyElement = storyDatas[_storyIndex].stories[_textIndex];
        
        //�ǂ̃X�g�[���[�f�[�^�́A�ǂ̃o�b�N�O�����h��
        background.sprite = storyElement.Background;
        
        //�ǂ̃X�g�[���[�f�[�^�́A�ǂ̃L�����N�^��
        andkunImage.sprite = storyElement.AndkunImage;
        sorukunImage.sprite = storyElement.SorukunImage;

        //�ǂ̃X�g�[���[�f�[�^�́A�ǂ̉摜��
        rightImage.sprite = storyElement.RightImage;
        leftImage.sprite = storyElement.LeftImage;

        //�ǂ̃X�g�[���[�f�[�^�́A�ǂ̃e�L�X�g��
        // storyText.text = storyElement.StoryText;
        //1�����Â\������R���[�`��
        StartCoroutine(TypeSentence(_storyIndex, _textIndex));

        // �ǂ̃X�g�[���[�f�[�^�́A�ǂ̃e�L�X�g��
        explantionText.text = storyElement.ExplantionText;
        
        //�ǂ̃X�g�[���[�f�[�^�́A�ǂ̃L��������
        characterName.text = storyElement.CharacterName;
    }
}
