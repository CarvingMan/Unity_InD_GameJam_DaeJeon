using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// �ϱ��� �ڽ��� Ŭ���� ȭ�� �߾ӿ� �ڽ��� Ȯ��Ǿ� Ŭ���ϸ� �ϱ����� Ȯ���Ѵ�. ���� ��ũ��Ʈ
// ���� ȭ�� Ȯ�� �� ���ڿ��� �� �ϱ��� ���� �� �ٽ� ��ü 3��Ī ���
public class BoxDiaryWindow : InteractiveObject
{
    public bool isStage1 = false;
    
    Image m_image = null;
    public GameObject boxWithBook;
    public GameObject diary;

    public TextMeshProUGUI tmp;

    //�÷��̾� ����� ��ũ��Ʈ
    PlayerControl m_csPlayerControl = null;

    private void Start()
    {
        if (m_image == null)
        {
            m_image = GetComponent<Image>();
        }

        if (m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }

        
    }

    private void OnEnable()
    {
        boxWithBook.SetActive(true);
        diary.SetActive(false);
    }

    protected override void DoInteract()
    {
        boxWithBook.SetActive(false);
        diary.SetActive(true);

        var stageController = FindObjectOfType<StageController>();
        if (stageController == null) return;
        
        m_csPlayerControl.SetPlayerStop(false);

        stageController.UpdateDiaryFound("box");

        if (tmp == null) return;

        if (isStage1)
        {
            tmp.text = "8월 4일! 오늘은 내 생일이다!\n드디어 원하던 곰인형을 선물받아서 기뻐!";
        }
        else
        {
            tmp.text = "11월 11일\n여긴 나만의 공간이야! 내가 좋아하는 것들도 옷장 안에 잔뜩 있어!";
        }
    }
}