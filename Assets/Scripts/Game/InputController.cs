using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Camera mainCamera; // 메인 카메라 참조

    void Start()
    {
        mainCamera = Camera.main; // 메인 카메라 초기화
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null) // 클릭한 위치에 Collider가 있는 경우
            {
                InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();
                if (interactiveObject != null && interactiveObject.IsInteractable) // InteractiveObject가 상호작용 가능할 경우
                {
                    interactiveObject.Interact(); // 상호작용 메소드 호출
                }
            }
        }
    }
}
