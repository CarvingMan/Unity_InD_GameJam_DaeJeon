using UnityEngine;

namespace Game
{
    public class Lock : InteractiveObject
    {
        [SerializeField]
        private GameObject m_objLock = null; // 잠금 오브젝트
        private bool isLocked = true; // 잠금 상태 추가

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
        }

        // 잠금을 해제하는 메소드
        public void Unlock()
        {
            if (m_objLock != null && isLocked)
            {
                m_objLock.SetActive(false); // 요청에 따라 비활성화
                isLocked = false; // 잠금 상태 업데이트
            }
        }

        protected override void DoInteract()
        {
            if (!isLocked) // 잠금 해제된 경우에만 활성화
            {
                m_objLock.SetActive(false); // 여기서 활성화 요청
            }
            else
            {
                m_objLock.SetActive(true); // 여기서 활성화 요청
            }
        }

        private void Update()
        {
            // 마우스 클릭 감지
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // 클릭한 위치가 Lock 오브젝트가 아닐 경우
                if (hit.collider == null || hit.collider.gameObject != m_objLock)
                {
                    DeactivateLock(); // Lock 오브젝트 비활성화
                }
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
