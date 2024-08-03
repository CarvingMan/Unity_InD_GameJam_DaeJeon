using UnityEngine;

namespace Game
{
    public class Lock : ZoomedInteractiveObject
    {
        [SerializeField]
        private GameObject m_objLock = null; // ��� ������Ʈ
        private bool isLocked = true; // ��� ���� �߰�

        [SerializeField]
        private Camera m_camera = null;

        // �÷��̾� ����� ��ũ��Ʈ ����
        private PlayerControl m_csPlayerControl = null;

        // Closet ���� �߰�
        [SerializeField]
        private Closet m_closet = null; // Closet Ŭ������ �ν��Ͻ��� ����

        private void Start()
        {
            // m_objLock�� ��Ȱ��ȭ
            if (m_objLock != null)
            {
                m_objLock.SetActive(false); // �ʱ� ���¸� ������� ����
            }
            else
            {
                Debug.LogError("m_objLock�� �����ϴ�.");
            }

            if (m_csPlayerControl == null)
            {
                m_csPlayerControl = FindObjectOfType<PlayerControl>();
            }
        }

        // ����� �����ϴ� �޼ҵ�
        public void Unlock()
        {
            if (m_objLock != null && isLocked)
            {
                m_objLock.SetActive(false); // ��û�� ���� ��Ȱ��ȭ
                isLocked = false; // ��� ���� ������Ʈ

                // Closet�� m_objTextCloset ��Ȱ��ȭ
                if (m_closet != null)
                {
                    m_closet.SetTextClosetInactive(); // �޼ҵ� ȣ��
                }
            }
        }

        protected override void DoInteract()
        {
            if (!m_objLock.activeSelf)
            {
                if (m_camera != null)
                {
                    // m_objLock.transform.position = new Vector2(m_camera.transform.position.x, m_camera.transform.position.y);
                    m_objLock.SetActive(true);
                    m_csPlayerControl.SetPlayerStop(true);
                }
            }

            if (!isLocked) // ��� ������ ��쿡�� Ȱ��ȭ
            {
                m_objLock.SetActive(false); // ���⼭ Ȱ��ȭ ��û
            }
            else
            {
                m_objLock.SetActive(true); // ���⼭ Ȱ��ȭ ��û
            }
        }

        private void DeactivateLock()
        {
            if (m_objLock != null)
            {
                m_objLock.SetActive(false); // Lock ������Ʈ ��Ȱ��ȭ
            }
        }
    }
}
