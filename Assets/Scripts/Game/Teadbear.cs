using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Teadbear : InteractiveObject
{
    [SerializeField]
    private GameObject m_cleanImageObject; // Ŭ���� �̹��� ������Ʈ

    [SerializeField]
    private Sprite m_cleanImageSprite; // Ŭ���� �̹��� ��������Ʈ

    [SerializeField]
    private Camera m_camera = null;

    // �÷��̾� ����� ��ũ��Ʈ ����
    private PlayerControl m_csPlayerControl = null;


    private Image m_image; // SpriteRenderer ����

    private void Start()
    {

        if (m_cleanImageObject != null)
        {
            m_image = m_cleanImageObject.GetComponent<Image>();
            m_cleanImageObject.SetActive(false); // �ʱ� ���¿��� ��Ȱ��ȭ
        }
        else
        {
            Debug.LogError("m_cleanImageObject�� �����ϴ�.");
        }

        if (m_csPlayerControl == null)
        {
            m_csPlayerControl = FindObjectOfType<PlayerControl>();
        }
    }

    protected override void DoInteract()
    {

        if (!m_cleanImageObject.activeSelf)
        {
            if (m_camera != null)
            {
                m_cleanImageObject.SetActive(true);
            }
        }

        if (m_cleanImageObject != null)
        {
            // �׵𺣾� ������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);

            // Ŭ���� �̹��� ������Ʈ Ȱ��ȭ �� �̹��� ����
            m_cleanImageObject.SetActive(true);
            if (m_image != null && m_cleanImageSprite != null)
            {
                m_image.sprite = m_cleanImageSprite; // �̹��� ��������Ʈ ����
            }
        }
    }
}
