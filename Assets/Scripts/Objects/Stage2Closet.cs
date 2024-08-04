using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stage2Closet : InteractiveObject
{

    //2�� ������ ������� �ʴ�.

    [SerializeField]
    GameObject m_objTextBox = null;
    [SerializeField]
    GameObject m_objClosetWindow = null;
    [SerializeField]
    Camera m_camera = null;

    //�÷��̾� �����
    PlayerControl m_csPlayerControl = null;

    // Start is called before the first frame update
    void Start()
    {
        if(m_objTextBox != null)
        {
            m_objTextBox.SetActive(false);  
        }
        else
        {
            Debug.LogError("m_objTextBox�� �����ϴ�.");
        }

        if(m_objClosetWindow != null)
        {
            m_objClosetWindow.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objClosetWindow�� �����ϴ�.");
        }

        if(m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }
    }

    protected override void DoInteract()
    {
        m_objTextBox.SetActive(false);
        if(m_camera != null)
        {
            m_csPlayerControl.SetPlayerStop(true);
            m_objClosetWindow.SetActive(true);
        }
        else
        {
            Debug.LogError("m_camera�� �����ϴ�.");
        }
    }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        if(m_objClosetWindow.activeSelf == false)
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
