using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADiary : InteractiveObject
{
    //�������ų� ���ڼ� �ϱ��� ���������� �����ϰ� ����

    [SerializeField]
    GameObject m_objTextBox = null; //����â
    [SerializeField]
    GameObject m_objDiaryWindow = null;
    [SerializeField]
    Camera m_camera; // ī�޶��� �߽����� Window�� ǥ���ϱ� ����

    bool m_isRedy = false; //�غ� �Ǿ��� ������ Ŭ���� �����ϴ�.

    //�÷��̾� �����
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
            Debug.LogError("m_objTextBox�� �����ϴ�.");
        }

        if(m_objDiaryWindow != null)
        {
            m_objDiaryWindow.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objDiaryWindow�� �����ϴ�.");
        }

        if(m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }

    }

    //Ŭ���� Diary Canvas Active
    protected override void DoInteract()
    {
        if (m_objDiaryWindow.activeSelf == false && m_isRedy)
        {
            
            if (m_camera != null)
            {
                Vector2 vecPos = m_camera.transform.position;
                m_objDiaryWindow.transform.position = vecPos; //ī�޶� �߽� ��ǥ�� Window �̵�
                m_objDiaryWindow.SetActive(true);
                m_csPlayerControl.SetPlayerStop(true);
            }
            else
            {
                Debug.LogError("m_camera�� �����ϴ�.");
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
