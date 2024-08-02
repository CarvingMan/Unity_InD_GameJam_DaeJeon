using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BoxObject : InteractiveObject
{
    // 상자_0 = 열린거, 상자_1 = 상자 열린거에 책 있는 상태 , 상자_2 = 상자 닫혀 있는거
    protected override void DoInteract()
    {
        if(isInteractable == false)
        {
            Debug.Log("상자가 연다");
            

        }
        else
        {
            Debug.Log("상자가 이미 열려 있다.");
        }

        //상자가 열린 상태
        if (isInteracted == true)
        {
            Debug.Log("상자 안에 일기장을 클릭 가능")
        }
        else
        {
            Debug.Log("상자 안에 ")
        }
}
