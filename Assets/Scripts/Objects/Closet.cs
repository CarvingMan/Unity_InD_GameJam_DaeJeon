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

        // �÷��̾� ����� ��ũ��Ʈ ����
        PlayerControl m_csPlayerControl = null;

        private void Start()
        {
            if (m_objTextCloset != null)
            {
                m_objTextCloset.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objTextCloset�� �����ϴ�.");
            }

            if (m_objCloset != null)
            {
                m_objCloset.SetActive(false);
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
            // ���콺 Ŭ�� ����
            if (Input.GetMouseButtonDown(0) && m_objCloset.activeSelf)
            {
                // Ŭ���� ��ġ�� Raycast�� Ȯ��
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // Ŭ���� ��ġ�� Ŭ������ �ƴ� ���
                if (hit.collider == null || hit.collider.gameObject != m_objCloset)
                {
                    CloseCloset(); // Ŭ���� �ݱ�
                }
            }
        }

        private void CloseCloset()
        {
            m_objCloset.SetActive(false);
            m_csPlayerControl.SetPlayerStop(false); // �÷��̾� �̵� �簳
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
