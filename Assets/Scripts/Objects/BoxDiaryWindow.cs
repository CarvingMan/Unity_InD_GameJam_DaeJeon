using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    // 일기장 박스를 클릭시 화면 중앙에 박스가 확대되어 클릭하며 일기장을 확인한다. 관련 스크립트
    // 상자 화면 확대 → 상자열림 → 일기장 열림 → 다시 전체 3인칭 배경
    public class BoxDiaryWindow : InteractiveObject
    {
        SpriteRenderer m_spriteRenderer = null;
        [SerializeField]
        List<Sprite> m_lstSprites = new List<Sprite>(); //이미지 전환 스프라이트

        [SerializeField]
        GameObject m_objDiaryTextPanel = null;

        int m_nIndex = 0;
        int m_nMaxIndex = 0;

        //플레이어 제어용 스크립트
        PlayerControl m_csPlayerControl = null;

        private void Start()
        {
            if(m_spriteRenderer == null)
            {
                m_spriteRenderer = GetComponent<SpriteRenderer>();
            }
            m_spriteRenderer.sprite = m_lstSprites[m_nIndex];

            m_nMaxIndex = m_lstSprites.Count - 1;

            if(m_objDiaryTextPanel != null)
            {
                m_objDiaryTextPanel.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objDiaryTextPanel이 없습니다.");
            }

            if(m_csPlayerControl == null)
            {
                m_csPlayerControl = FindObjectOfType<PlayerControl>();
            }
        }

        //클릭시 Diary Canvas Active
        protected override void DoInteract()
        {
            
            if (m_nIndex + 1 <= m_nMaxIndex) //이번이 마지막 스프라이트가 아닐 시
            {
                m_nIndex++; // 인덱스 증가
                m_spriteRenderer.sprite = m_lstSprites[m_nIndex]; // 이미지 소스 변경
            }
            else //마지막 스프라이트일 시
            {
                m_csPlayerControl.SetPlayerStop(false);
                m_nIndex = 0; //인덱스 초기화
                m_spriteRenderer.sprite = m_lstSprites[m_nIndex];
                gameObject.SetActive(false); // 다시 비 활성화
            }
        }

        public override void OnMouseHoverEnter()
        {
            base.OnMouseHoverEnter();
            if(m_objDiaryTextPanel.activeSelf == false && m_nIndex == m_lstSprites.Count-1) // 마지막 인덱스 일때
            {
                m_objDiaryTextPanel.SetActive(true);
            }
        }

        public override void OnMouseHoverExit()
        {
            base.OnMouseHoverExit();
            if(m_objDiaryTextPanel.activeSelf == true)
            {
                m_objDiaryTextPanel.SetActive(false);
            }
        }
    }
}
