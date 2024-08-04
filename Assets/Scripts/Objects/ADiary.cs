using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ADiary : InteractiveObject, IPointerEnterHandler, IPointerExitHandler
{
    //�������ų� ���ڼ� �ϱ��� ���������� �����ϰ� ����

    [SerializeField]
    GameObject m_objTextBox = null; //����â
    [SerializeField]
    GameObject m_objDiaryWindow = null;
    [SerializeField]
    Camera m_camera; // ī�޶��� �߽����� Window�� ǥ���ϱ� ����

    bool m_isRedy = false; //�غ� �Ǿ��� ������ Ŭ���� �����ϴ�.

    public string content;

    //�÷��̾� �����
    PlayerControl m_csPlayerControl;

    public bool isCupboard;
    public bool isCat;

    public Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        if(m_objTextBox != null)
        {
            m_objTextBox.SetActive(false);
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

        if (isCat)
        {
            closeButton.onClick.AddListener(() =>
            {
                if (isCat)
                {
                    stageController.UpdateDiaryFound("cat");
                }
            });
        }
    }

    //Ŭ���� Diary Canvas Active
    protected override void DoInteract()
    {
        if (!isCupboard || (m_objDiaryWindow.activeSelf == false && m_isRedy))
        {
            
            if (m_camera != null)
            {
                m_objDiaryWindow.SetActive(true);
                var book = FindObjectOfType<DiaryBook>();
                book.OpenDiary(content);
                m_csPlayerControl.SetPlayerStop(true);

                if (stageController == null)
                {
                    stageController = FindObjectOfType<StageController>();
                }

                if (stageController == null) return;

                if (isCupboard)
                {
                    stageController.UpdateDiaryFound("cupboard");
                }
                else if (isCat)
                {
                    
                }
                else
                {
                    stageController.UpdateDiaryFound("closet");
                }
            }
            else
            {
                Debug.LogError("m_camera�� �����ϴ�.");
            }
        }
    }

    public void SetDiaryRedy(bool isRedy)
    {
        m_isRedy = isRedy;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (m_objTextBox == null) return;
        
        if(m_objDiaryWindow.activeSelf == false)
        {
            m_objTextBox.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (m_objTextBox == null) return;
        
        m_objTextBox.SetActive(false);
    }
}
