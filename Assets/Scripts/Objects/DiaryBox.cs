
using UnityEngine;

namespace Game
{
    //å�� �� �ϱ��� �ڽ� ��ũ��Ʈ
    public class DiaryBox : InteractiveObject
    {

        [SerializeField]
        GameObject m_objTextBox = null;

        //[SerializeField]
        //GameObject m_objBox = null;


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

            /*if (m_objBox != null)
            {
                m_objBox.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objBox�� �����ϴ�.");
            }*/
        }

        protected override void DoInteract()
        {
            //m_objBox.SetActive(true);
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