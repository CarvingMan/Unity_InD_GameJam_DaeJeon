using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADiaryWindow : InteractiveObject
{
    //다이어리 프리팹을 눌렀을 때 화면 가운데 띄어지는 일기장 관련 기믹


    [SerializeField]
    GameObject m_objDiaryPanel = null; //일기장에 마우스를 가져다 놓을시 panel에 내용 출력

    //플레이어 제어용
    PlayerControl m_csPlayerControl = null;

 

    // Start is called before the first frame update
    void Start()
    {
       

        if (m_objDiaryPanel != null)
        {
            m_objDiaryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objDiaryPanel이 없습니다.");
        }

        if(m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }

       
        
    }
    //클릭시 Diary Canvas Active
    protected override void DoInteract()
    {
        m_csPlayerControl.SetPlayerStop(false);//다시 움직이도록 설정
        gameObject.SetActive(false);
    }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        m_objDiaryPanel.SetActive(true);
    }

    public override void OnMouseHoverExit()
    {
        base.OnMouseHoverExit();
        m_objDiaryPanel.SetActive(false);
    }
}
