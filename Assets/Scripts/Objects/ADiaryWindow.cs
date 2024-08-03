using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADiaryWindow : InteractiveObject
{
    //���̾ �������� ������ �� ȭ�� ��� ������� �ϱ��� ���� ���


    [SerializeField]
    GameObject m_objDiaryPanel = null; //�ϱ��忡 ���콺�� ������ ������ panel�� ���� ���

    //�÷��̾� �����
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
