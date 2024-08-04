using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowObject : ZoomedInteractiveObject
{

    [SerializeField]
    GameObject m_objWindow = null;

    [SerializeField]
    Camera m_camera = null;

    PlayerControl m_csPlayerControl = null;

    private void Start()
    {

        if (m_objWindow != null)
        {
            m_objWindow.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objCloset�� �����ϴ�.");
        }

        if (m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }
    }

    protected override void DoInteract()
    {
        if (!m_objWindow.activeSelf)
        {
            if (m_camera != null)
            {

                m_objWindow.SetActive(true);
                m_csPlayerControl.SetPlayerStop(true);
            }
        }
    }

}
