using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoard : InteractiveObject
{

    bool m_isOpen = false;
    //���콺 enter�� ���� props ����
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
            Debug.LogError("m_objTextBox�� �����ϴ�.");
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
