using UnityEngine;

namespace Game
{
    public class Closet : InteractiveObject
    {
        [SerializeField]
        GameObject m_objTextCloset = null;

        [SerializeField]
        GameObject m_objCloset = null;

        [SerializeField]
        Camera m_camera = null;

        // 플레이어 제어용 스크립트 변수
        PlayerControl m_csPlayerControl = null;

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

        private void Update()
        {
            // 마우스 클릭 감지
            if (Input.GetMouseButtonDown(0) && m_objCloset.activeSelf)
            {
                // 클릭한 위치를 Raycast로 확인
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // 클릭한 위치가 클로짓이 아닌 경우
                if (hit.collider == null || hit.collider.gameObject != m_objCloset)
                {
                    CloseCloset(); // 클로짓 닫기
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
            if (!m_objCloset.activeSelf)
            {
                m_objTextCloset.SetActive(true);
            }
        }

        public override void OnMouseHoverExit()
        {
            base.OnMouseHoverExit();
            m_objTextCloset.SetActive(false);
        }
    }
}
