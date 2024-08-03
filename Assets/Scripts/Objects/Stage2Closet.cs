using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Closet : InteractiveObject
{

    //2층 옷장은 잠겨있지 않다.

    [SerializeField]
    GameObject m_objTextBox = null;
    [SerializeField]
    GameObject m_objClosetWindow = null;
    [SerializeField]
    Camera m_camera = null;



    //플레이어 제어용
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
            Debug.LogError("m_objTextBox가 없습니다.");
        }

        if(m_objClosetWindow != null)
        {
            m_objClosetWindow.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objClosetWindow가 없습니다.");
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
            Vector2 vecTarget = m_camera.transform.position;
            m_objClosetWindow.transform.position = vecTarget;
            m_objClosetWindow.SetActive(true);
        }
        else
        {
            Debug.LogError("m_camera가 없습니다.");
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
