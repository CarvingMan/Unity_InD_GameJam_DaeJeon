using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BookObject Ŭ������ InteractiveObject�� ��ӹ���
public class BookObject : InteractiveObject
{
    // å ������Ʈ�� ��ȣ�ۿ�� �� ȣ��� �޼��� ����
    protected override void DoInteract()
    {
        Debug.Log("The book has been interacted with.");
        // ��: å�� ����, å�� �ݱ� ��
        
    }


}
