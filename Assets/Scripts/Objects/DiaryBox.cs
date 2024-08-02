using UnityEngine;

namespace Game
{
    //책상 밑 일기장 박스 스크립트
    public class DiaryBox : InteractiveObject
    {

        [SerializeField]
        GameObject m_objTextBox = null;


        //박스가 열렸을때
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
                Debug.LogError("m_objTextBox가 없습니다.");
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