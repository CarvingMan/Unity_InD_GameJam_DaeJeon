using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//å�� �� �ϱ��� �ڽ� ��ũ��Ʈ
public class DiaryBox : InteractiveObject
{
    //���콺 enter�� ���� props ����
    [SerializeField]
    GameObject m_objTextBox = null;


    [SerializeField]
    GameObject m_objDiaryWindow = null; // ���� ȭ�� Ȯ�� �� ���ڿ��� �� �ϱ��� ���� �� �ٽ� ��ü 3��Ī ���) â
    [SerializeField]
    Camera m_camera = null;

    //�÷��̾� ����� ��ũ��Ʈ ����
    PlayerControl m_csPlayerControl = null;

    private void Start()
    {
        if (m_objTextBox != null)
        {
            m_objTextBox.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objTextBox�� �����ϴ�.");
        }

        if (m_objDiaryWindow != null)
        {
            m_objDiaryWindow.SetActive(false);
        }
        else
        {
            Debug.Log("DiaryPenel�� �����ϴ�.");
        }

        if (m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }
    }

    //Ŭ���� Diary Canvas Active
    protected override void DoInteract()
    {
        if (m_objDiaryWindow.activeSelf == false)
        {
            if (m_camera != null)
            {
                m_objDiaryWindow.SetActive(true);
                m_csPlayerControl.SetPlayerStop(true);

            }
        }
    }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        if (m_objDiaryWindow.activeSelf == false)
        {
            m_objTextBox.SetActive(true);
        }
    }

    public override void OnMouseHoverExit()
    {
        base.OnMouseHoverExit();
        m_objTextBox.SetActive(false);
    }
}