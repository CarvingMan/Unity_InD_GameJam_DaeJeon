using UnityEngine;

namespace Game
{
    public class Closet : InteractiveObject
    {
        [SerializeField]
        GameObject m_objTextCloset = null;

        [SerializeField]
        GameObject m_objCloset = null;


        private void Start()
        {
            if (m_objTextCloset != null)
            {
                m_objTextCloset.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objCloset가 없습니다.");
            }

            if (m_objCloset != null)
            {
                m_objCloset.SetActive(false);
            }
            else
            {
                Debug.LogError("m_objCloset가 없습니다.");
            }
        }

        protected override void DoInteract()
        {
            m_objCloset.SetActive(true);
            
        }

        public override void OnMouseHoverEnter()
        {
            base.OnMouseHoverEnter();
            m_objTextCloset.SetActive(true);
        }

        public override void OnMouseHoverExit()
        {
            base.OnMouseHoverExit();
            m_objTextCloset.SetActive(false);
        }
    }
}