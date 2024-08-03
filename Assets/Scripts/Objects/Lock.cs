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
    }
}
