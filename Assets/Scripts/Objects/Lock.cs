using UnityEngine;

namespace Game
{
    public class Lock : InteractiveObject
    {
        [SerializeField]
        private GameObject m_objLock = null; // ��� ������Ʈ
        private bool isLocked = true; // ��� ���� �߰�

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
        }

        // ����� �����ϴ� �޼ҵ�
        public void Unlock()
        {
            if (m_objLock != null && isLocked)
            {
                m_objLock.SetActive(false); // ��û�� ���� ��Ȱ��ȭ
                isLocked = false; // ��� ���� ������Ʈ
            }
        }

        protected override void DoInteract()
        {
            if (!isLocked) // ��� ������ ��쿡�� Ȱ��ȭ
            {
                m_objLock.SetActive(false); // ���⼭ Ȱ��ȭ ��û
            }
            else
            {
                m_objLock.SetActive(true); // ���⼭ Ȱ��ȭ ��û
            }
        }

        private void Update()
        {
            // ���콺 Ŭ�� ����
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                // Ŭ���� ��ġ�� Lock ������Ʈ�� �ƴ� ���
                if (hit.collider == null || hit.collider.gameObject != m_objLock)
                {
                    DeactivateLock(); // Lock ������Ʈ ��Ȱ��ȭ
                }
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
