using UnityEngine;

namespace Game
{
    public class Lock : InteractiveObject
    {
        [SerializeField]
        private GameObject m_objLock = null; // 잠금 오브젝트
        private bool isLocked = true; // 잠금 상태 추가

        [SerializeField]
        private Camera m_camera = null;

        // 플레이어 제어용 스크립트 변수
        private PlayerControl m_csPlayerControl = null;

        // Closet 참조 추가
        [SerializeField]
        private Closet m_closet = null; // Closet 클래스의 인스턴스를 참조

        private void Start()
        {
            // m_objLock을 비활성화
            if (m_objLock != null)
            {
                m_objLock.SetActive(false); // 초기 상태를 잠금으로 설정
            }
            else
            {
                Debug.LogError("m_objLock가 없습니다.");
            }

            if (m_csPlayerControl == null)
            {
                m_csPlayerControl = FindObjectOfType<PlayerControl>();
            }
        }

        // 잠금을 해제하는 메소드
        public void Unlock()
        {
            if (m_objLock != null && isLocked)
            {
                m_objLock.SetActive(false); // 요청에 따라 비활성화
                isLocked = false; // 잠금 상태 업데이트

                // Closet의 m_objTextCloset 비활성화
                if (m_closet != null)
                {
                    m_closet.SetTextClosetInactive(); // 메소드 호출
                }
            }
        }

        protected override void DoInteract()
        {
            if (!m_objLock.activeSelf)
            {
                if (m_camera != null)
                {
                    m_objLock.transform.position = new Vector2(m_camera.transform.position.x, m_camera.transform.position.y);
                    m_objLock.SetActive(true);
                    m_csPlayerControl.SetPlayerStop(true);
                }
            }

            if (!isLocked) // 잠금 해제된 경우에만 활성화
            {
                m_objLock.SetActive(false); // 여기서 활성화 요청
            }
            else
            {
                m_objLock.SetActive(true); // 여기서 활성화 요청
            }
        }

        private void DeactivateLock()
        {
            if (m_objLock != null)
            {
                m_objLock.SetActive(false); // Lock 오브젝트 비활성화
            }
        }
    }
}
