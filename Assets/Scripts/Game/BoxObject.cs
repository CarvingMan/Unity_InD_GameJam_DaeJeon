using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BoxObject : InteractiveObject
{
    // ����_0 = ������, ����_1 = ���� �����ſ� å �ִ� ���� , ����_2 = ���� ���� �ִ°�
    protected override void DoInteract()
    {
        if(isInteractable == false)
        {
            Debug.Log("���ڰ� ����");
            

        }
        else
        {
            Debug.Log("���ڰ� �̹� ���� �ִ�.");
        }

        //���ڰ� ���� ����
        if (isInteracted == true)
        {
            Debug.Log("���� �ȿ� �ϱ����� Ŭ�� ����")
        }
        else
        {
            Debug.Log("���� �ȿ� ")
        }
}
