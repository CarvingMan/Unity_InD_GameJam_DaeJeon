using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//책상 밑 일기장 박스 스크립트
public class DiaryBox : InteractiveObject
{
    //마우스 enter시 보일 props 설명
    [SerializeField]
    GameObject m_objTextBox = null;


    [SerializeField]
    GameObject m_objDiaryWindow = null; // 상자 화면 확대 → 상자열림 → 일기장 열림 → 다시 전체 3인칭 배경) 창
    [SerializeField]
    Camera m_camera = null;

    //플레이어 제어용 스크립트 변수
    PlayerControl m_csPlayerControl = null;

    private void Start()
    {
        if (m_objTextBox != null)
        {
            m_objTextBox.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objTextBox가 없습니다.");
        }

        if (m_objDiaryWindow != null)
        {
            m_objDiaryWindow.SetActive(false);
        }
        else
        {
            Debug.Log("DiaryPenel이 없습니다.");
        }

        if (m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }
    }

    //클릭시 Diary Canvas Active
    protected override void DoInteract()
    {
        if (m_objDiaryWindow.activeSelf == false)
        {
            if (m_camera != null)
            {
                m_objDiaryWindow.transform.position = new Vector2(m_camera.transform.position.x, m_camera.transform.position.y);
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