using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class BoxObject : InteractiveObject
{
    public Sprite box1Sprite; // 책이 있는 상자 스프라이트
    public Sprite box2Sprite; // 닫힌 상자 스프라이트
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 초기화

        // StageController를 찾고 초기화
        StageController stageController = FindObjectOfType<StageController>();
        if (stageController != null)
        {
            Initialize(stageController); // 초기화 메소드 호출
        }
        else
        {
            Debug.LogError("StageController not found!");
        }
    }

    private void OnMouseDown()
    {
        Interact(); // 클릭 시 상호작용 메소드 호출
    }

    protected override void DoInteract()
    {
        if (!isInteractable) // 상자가 상호작용이 가능 한지?
        {
            Debug.Log("상자가 연다");
            isInteractable = true;
            spriteRenderer.sprite = box1Sprite; // 상자_1 스프라이트로 변경             
        }
        else
        {
            Debug.Log("상자가 열려 있다.");

        }
    }
}
