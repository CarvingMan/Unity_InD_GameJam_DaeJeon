using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Butterfly : InteractiveObject, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    Image m_ButterFlyImage = null;

    [SerializeField]
    GameObject m_objTextBox = null;

    // Start is called before the first frame update
    void Start()
    {
        if(m_objTextBox != null)
        {
            m_objTextBox.SetActive(false);
        }
        else
        {
            Debug.LogError("m_TextBox�� �����ϴ�.");
        }
    }

    protected override void DoInteract()
    {
        Color color = m_ButterFlyImage.color;
        color.a = 1;
        m_ButterFlyImage.color = color;
        Destroy(gameObject);
        
        m_objTextBox.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_objTextBox.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_objTextBox.SetActive(false);
    }
}
