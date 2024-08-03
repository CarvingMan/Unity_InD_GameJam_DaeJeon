using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoard : InteractiveObject
{

    bool m_isOpen = false;
    //마우스 enter시 보일 props 설명
    [SerializeField]
    GameObject m_objTextBox = null;


    private void Start()
    {
        if(m_objTextBox != null)
        {
            m_objTextBox.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objTextBox가 없습니다.");
        }
    }

    protected override void DoInteract()
    {
        Debug.Log("INTERACT!!!");
    }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        if(m_isOpen == false)
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
