using UnityEngine;

namespace Game
{
    //å�� �� �ϱ��� �ڽ� ��ũ��Ʈ
    public class DiaryBox : InteractiveObject
    {

        [SerializeField]
        GameObject m_objTextBox = null;


        //�ڽ��� ��������
        bool m_isBoxOpen = false;

        [SerializeField]
        Sprite m_spOpenBox = null;



        private void Start()
        {
            if(m_objTextBox != null)
            {
                m_objTextBox.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objTextBox�� �����ϴ�.");
            }
        }

        protected override void DoInteract()
        {
            Debug.Log("INTERACT!!!");
        }

        public override void OnMouseHoverEnter()
        {
            base.OnMouseHoverEnter();
            m_objTextBox.SetActive(true);
        }

        public override void OnMouseHoverExit()
        {
            base.OnMouseHoverExit();
            m_objTextBox.SetActive(false);
        }
    }
}