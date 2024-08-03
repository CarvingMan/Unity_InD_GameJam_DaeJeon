using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butterfly : InteractiveObject
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
            Debug.LogError("m_TextBox가 없습니다.");
        }
    }

    protected override void DoInteract()
    {
        Color color = m_ButterFlyImage.color;
        color.a = 1;
        m_ButterFlyImage.color = color;
        Destroy(gameObject);
    }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        m_objTextBox.SetActive(true);
    }

    public override void OnMouseHoverExit()
    {
        base.OnMouseHoverExit();
        m_objTextBox.SetActive(false);
    }
}
