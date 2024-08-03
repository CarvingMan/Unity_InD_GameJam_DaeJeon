using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teadbear : InteractiveObject
{
    [SerializeField]
    private GameObject m_cleanImageObject; // 클린한 이미지 오브젝트

    [SerializeField]
    private Sprite m_cleanImageSprite; // 클린한 이미지 스프라이트

    [SerializeField]
    private Camera m_camera = null;

    // 플레이어 제어용 스크립트 변수
    private PlayerControl m_csPlayerControl = null;


    private SpriteRenderer m_spriteRenderer; // SpriteRenderer 변수

    private void Start()
    {

        if (m_cleanImageObject != null)
        {
            m_spriteRenderer = m_cleanImageObject.GetComponent<SpriteRenderer>();
            m_cleanImageObject.SetActive(false); // 초기 상태에서 비활성화
        }
        else
        {
            Debug.LogError("m_cleanImageObject가 없습니다.");
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
            // 테디베어 오브젝트 비활성화
            gameObject.SetActive(false);

            // 클린한 이미지 오브젝트 활성화 및 이미지 설정
            m_cleanImageObject.SetActive(true);
            if (m_spriteRenderer != null && m_cleanImageSprite != null)
            {
                m_spriteRenderer.sprite = m_cleanImageSprite; // 이미지 스프라이트 설정
            }
        }
    }
}
