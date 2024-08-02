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

            //ray �߻� �ؼ� ��ü �浹 Ȯ��
            if(Physics.Raycast(ray, out hit))
            {
                //�浹 ��ü���� InteractiveObject �ִ��� Ȯ��
                InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();
                if (interactiveObject != null)
                {
                    interactiveObject.OnClick();
                }
            }
        }
    }
}
