using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADiary : InteractiveObject
{
    //떨어지거나 상자속 일기장 프리팹으로 동일하게 구현

    [SerializeField]
    GameObject m_objTextBox = null; //설명창
    [SerializeField]
    GameObject m_objDiaryWindow = null;
    [SerializeField]
    Camera m_camera; // 카메라의 중심으로 Window를 표출하기 위함

    bool m_isRedy = false; //준비가 되었을 때에만 클릭이 가능하다.

    //플레이어 제어용
    PlayerControl m_csPlayerControl;

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

        if(m_objDiaryWindow != null)
        {
            m_objDiaryWindow.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objDiaryWindow가 없습니다.");
        }

        if(m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }

    }

    //클릭시 Diary Canvas Active
    protected override void DoInteract()
    {
        if (m_objDiaryWindow.activeSelf == false && m_isRedy)
        {
            
            if (m_camera != null)
            {
                Vector2 vecPos = m_camera.transform.position;
                m_objDiaryWindow.transform.position = vecPos; //카메라 중심 좌표로 Window 이동
                m_objDiaryWindow.SetActive(true);
                m_csPlayerControl.SetPlayerStop(true);
            }
            else
            {
                Debug.LogError("m_camera가 없습니다.");
            }
        }
    }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        if(m_objDiaryWindow.activeSelf == false)
        {
            m_objTextBox.SetActive(true);
        }

    }

    public override void OnMouseHoverExit()
    {
        base.OnMouseHoverExit();
        m_objTextBox.SetActive(false);
    }

    public void SetDiaryRedy(bool isRedy)
    {
        m_isRedy = isRedy;
    }
}
