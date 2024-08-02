using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class BoxObject : InteractiveObject
{
    public Sprite box1Sprite; // å�� �ִ� ���� ��������Ʈ
    public Sprite box2Sprite; // ���� ���� ��������Ʈ
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // ��������Ʈ ������ �ʱ�ȭ

        // StageController�� ã�� �ʱ�ȭ
        StageController stageController = FindObjectOfType<StageController>();
        if (stageController != null)
        {
            Initialize(stageController); // �ʱ�ȭ �޼ҵ� ȣ��
        }
        else
        {
            Debug.LogError("StageController not found!");
        }
    }

    private void OnMouseDown()
    {
        Interact(); // Ŭ�� �� ��ȣ�ۿ� �޼ҵ� ȣ��
    }

    protected override void DoInteract()
    {
        if (!isInteractable) // ���ڰ� ��ȣ�ۿ��� ���� ����?
        {
            Debug.Log("���ڰ� ����");
            isInteractable = true;
            spriteRenderer.sprite = box1Sprite; // ����_1 ��������Ʈ�� ����             
        }
        else
        {
            Debug.Log("���ڰ� ���� �ִ�.");

        }
    }
}
