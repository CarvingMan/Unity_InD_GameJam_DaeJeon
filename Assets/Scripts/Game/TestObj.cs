using UnityEngine;

namespace Game
{
    public class TestObj: InteractiveObject
    {
        protected override void DoInteract()
        {
            
        }

        public override void OnMouseHoverEnter()
        {
            base.OnMouseHoverEnter();
            Debug.Log("On Mouse hover enter");
        }

        public override void OnMouseHoverExit()
        {
            base.OnMouseHoverExit();
            Debug.Log("On Mouse hover exit");
        }
    }
}