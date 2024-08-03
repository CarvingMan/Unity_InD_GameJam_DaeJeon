using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// �ϱ��� �ڽ��� Ŭ���� ȭ�� �߾ӿ� �ڽ��� Ȯ��Ǿ� Ŭ���ϸ� �ϱ����� Ȯ���Ѵ�. ���� ��ũ��Ʈ
// ���� ȭ�� Ȯ�� �� ���ڿ��� �� �ϱ��� ���� �� �ٽ� ��ü 3��Ī ���
public class BoxDiaryWindow : InteractiveObject
{
    Image m_image = null;
    public GameObject boxWithBook;
    public GameObject diary;

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
        stageController.UpdateDiaryFound("box");
    }
}