using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManger : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camer.main.ScreenPointToRay(Input.mousePosition);
            raycastHit hit;

            //ray 발사 해서 객체 충돌 확인
            if(Physics.Raycast(ray, out hit))
            {
                //충돌 객체에서 InteractiveObject 있는지 확인
                InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();
                if (interactiveObject != null)
                {
                    interactiveObject.OnClick();
                }
            }
        }
    }
}
