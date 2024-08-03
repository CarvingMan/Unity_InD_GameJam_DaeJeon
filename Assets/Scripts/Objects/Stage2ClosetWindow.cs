using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2ClosetWindow : InteractiveObject
{
    //2층 옷장 클릭시 확대 창 코드

    [SerializeField]
    List<Sprite> m_lstSptites = new List<Sprite>();
    int m_nMaxIndex = 0;
    int m_nCurrentIndex = 0;
    SpriteRenderer m_spriteRenderer = null;


    //장롱창 Window속 오브젝트들
    [SerializeField]
    GameObject m_objDiary = null;
    [SerializeField]
    GameObject m_objButterfly = null;

    //플레이어 검증용
    PlayerControl m_csPlayerControl = null;

    // Start is called before the first frame update
    void Start()
    {
        m_nMaxIndex = m_lstSptites.Count -1;
        if(m_spriteRenderer == null)
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
            m_spriteRenderer.sprite = m_lstSptites[m_nCurrentIndex];
        }

        if(m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }

        if (m_objDiary != null)
        {
            m_objDiary.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objDiary가 없습니다.");
        }

        if (m_objButterfly != null)
        {
            m_objButterfly.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objButterfly가 없습니다.");
        }
    }

    protected override void DoInteract()
    {
        if(m_nCurrentIndex < m_nMaxIndex)
        {
            m_nCurrentIndex++;
            if(m_nCurrentIndex == m_nMaxIndex)
            {
                m_objDiary.GetComponentInChildren<ADiary>().SetDiaryRedy(true);
                m_objDiary.SetActive(true);
                if(m_objButterfly != null)
                {
                    m_objButterfly.SetActive(true);
                }
            }
            m_spriteRenderer.sprite = m_lstSptites[m_nCurrentIndex];
        }
        else
        {
            m_objDiary.GetComponentInChildren<ADiary>().SetDiaryRedy(false);
            m_objDiary.SetActive(false);
            if (m_objButterfly != null)
            {
                m_objButterfly.SetActive(false);
            }
            m_nCurrentIndex = 0;
            m_spriteRenderer.sprite = m_lstSptites[m_nCurrentIndex];
            m_csPlayerControl.SetPlayerStop(false);
            gameObject.SetActive(false);
        }
    }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        //Debug.Log("On Mouse hover enter");
    }

    public override void OnMouseHoverExit()
    {
        base.OnMouseHoverExit();
        //Debug.Log("On Mouse hover exit");
    }
}
