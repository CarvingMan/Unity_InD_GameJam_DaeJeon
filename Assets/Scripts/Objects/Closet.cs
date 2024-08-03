using UnityEngine;

namespace Game
{
    public class Closet : InteractiveObject
    {
        [SerializeField]
        private GameObject m_objTextCloset = null;
        private bool UnLocked = false; // �رݻ��� �߰�

        [SerializeField]
        private GameObject m_objCloset = null;

        [SerializeField]
        private Camera m_camera = null;

        // �÷��̾� ����� ��ũ��Ʈ ����
        private PlayerControl m_csPlayerControl = null;

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

        private void CloseCloset()
        {
            m_objCloset.SetActive(false);
            m_csPlayerControl.SetPlayerStop(false); // �÷��̾� �̵� �簳
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

        // m_objTextCloset ��Ȱ��ȭ �޼ҵ� �߰�
        public void SetTextClosetInactive()
        {
            if (m_objTextCloset != null)
            {
                m_objTextCloset.SetActive(false);
            }
        }
    }
}
