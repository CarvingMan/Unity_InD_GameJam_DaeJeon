using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BookObject 클래스는 InteractiveObject를 상속받음
public class BookObject : InteractiveObject
{
    // 책 오브젝트가 상호작용될 때 호출될 메서드 구현
    protected override void DoInteract()
    {
        Debug.Log("The book has been interacted with.");
        // 예: 책을 열기, 책을 줍기 등
        
    }


}
