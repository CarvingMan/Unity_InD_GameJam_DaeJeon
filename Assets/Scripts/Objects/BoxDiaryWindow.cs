using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    // �ϱ��� �ڽ��� Ŭ���� ȭ�� �߾ӿ� �ڽ��� Ȯ��Ǿ� Ŭ���ϸ� �ϱ����� Ȯ���Ѵ�. ���� ��ũ��Ʈ
    // ���� ȭ�� Ȯ�� �� ���ڿ��� �� �ϱ��� ���� �� �ٽ� ��ü 3��Ī ���
    public class BoxDiaryWindow : InteractiveObject
    {
        SpriteRenderer m_spriteRenderer = null;
        [SerializeField]
        List<Sprite> m_lstSprites = new List<Sprite>(); //�̹��� ��ȯ ��������Ʈ

        [SerializeField]
        GameObject m_objDiaryTextPanel = null;

        int m_nIndex = 0;
        int m_nMaxIndex = 0;

        //�÷��̾� ����� ��ũ��Ʈ
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
                Debug.LogError("m_objDiaryTextPanel�� �����ϴ�.");
            }

            if(m_csPlayerControl == null)
            {
                m_csPlayerControl = FindObjectOfType<PlayerControl>();
            }
        }

        //Ŭ���� Diary Canvas Active
        protected override void DoInteract()
        {
            
            if (m_nIndex + 1 <= m_nMaxIndex) //�̹��� ������ ��������Ʈ�� �ƴ� ��
            {
                m_nIndex++; // �ε��� ����
                m_spriteRenderer.sprite = m_lstSprites[m_nIndex]; // �̹��� �ҽ� ����
            }
            else //������ ��������Ʈ�� ��
            {
                m_csPlayerControl.SetPlayerStop(false);
                m_nIndex = 0; //�ε��� �ʱ�ȭ
                m_spriteRenderer.sprite = m_lstSprites[m_nIndex];
                gameObject.SetActive(false); // �ٽ� �� Ȱ��ȭ
            }
        }

        public override void OnMouseHoverEnter()
        {
            base.OnMouseHoverEnter();
            if(m_objDiaryTextPanel.activeSelf == false && m_nIndex == m_lstSprites.Count-1) // ������ �ε��� �϶�
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
