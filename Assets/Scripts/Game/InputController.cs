using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Camera mainCamera; // ���� ī�޶� ����

    void Start()
    {
        mainCamera = Camera.main; // ���� ī�޶� �ʱ�ȭ
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null) // Ŭ���� ��ġ�� Collider�� �ִ� ���
            {
                InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();
                if (interactiveObject != null && interactiveObject.IsInteractable) // InteractiveObject�� ��ȣ�ۿ� ������ ���
                {
                    interactiveObject.Interact(); // ��ȣ�ۿ� �޼ҵ� ȣ��
                }
            }
        }
    }
}
