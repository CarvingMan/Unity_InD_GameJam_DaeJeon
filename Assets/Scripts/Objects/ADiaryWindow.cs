using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ADiaryWindow : InteractiveObject, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    GameObject m_objDiaryPanel = null;

    //�÷��̾� �����
    PlayerControl m_csPlayerControl = null;
    
    void Start()
    {
        if (m_objDiaryPanel != null)
        {
            m_objDiaryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objDiaryPanel�� �����ϴ�.");
        }

        if(m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }
    }
    //Ŭ���� Diary Canvas Active
    protected override void DoInteract()
    {
        m_csPlayerControl.SetPlayerStop(false);//�ٽ� �����̵��� ����
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_objDiaryPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_objDiaryPanel.SetActive(false);
    }
}
