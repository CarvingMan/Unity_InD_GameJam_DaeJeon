using UnityEngine;

namespace Game
{
    public class Closet : InteractiveObject
    {
        [SerializeField]
        private GameObject m_objTextCloset = null;
        private bool UnLocked = false; // 해금상태 추가

        [SerializeField]
        private GameObject m_objCloset = null;

        [SerializeField]
        private Camera m_camera = null;

        // 플레이어 제어용 스크립트 변수
        private PlayerControl m_csPlayerControl = null;

        private void Start()
        {
            if (m_objTextCloset != null)
            {
                m_objTextCloset.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objTextCloset가 없습니다.");
            }

            if (m_objCloset != null)
            {
                m_objCloset.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objCloset가 없습니다.");
            }

            if (m_csPlayerControl == null)
            {
                m_csPlayerControl = FindObjectOfType<PlayerControl>();
            }
        }

        protected override void DoInteract()
        {
            if (!m_objCloset.activeSelf)
            {
                if (m_camera != null)
                {
                    m_objCloset.transform.position = new Vector2(m_camera.transform.position.x, m_camera.transform.position.y);
                    m_objCloset.SetActive(true);
                    m_csPlayerControl.SetPlayerStop(true);
                }
            }
        }

        private void CloseCloset()
        {
            m_objCloset.SetActive(false);
            m_csPlayerControl.SetPlayerStop(false); // 플레이어 이동 재개
        }

        public override void OnMouseHoverEnter()
        {
            base.OnMouseHoverEnter();
            if (m_objCloset.activeSelf == false)
            {
                m_objTextCloset.SetActive(true);
            }
        }

        public override void OnMouseHoverExit()
        {
            base.OnMouseHoverExit();
            m_objTextCloset.SetActive(false);
        }

        // m_objTextCloset 비활성화 메소드 추가
        public void SetTextClosetInactive()
        {
            if (m_objTextCloset != null)
            {
                m_objTextCloset.SetActive(false);
            }
        }
    }
}
