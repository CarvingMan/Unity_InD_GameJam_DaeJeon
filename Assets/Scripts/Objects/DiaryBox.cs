
using UnityEngine;

namespace Game
{
    //책상 밑 일기장 박스 스크립트
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
                Debug.LogError("m_objTextBox가 없습니다.");
            }

            /*if (m_objBox != null)
            {
                m_objBox.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objBox가 없습니다.");
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