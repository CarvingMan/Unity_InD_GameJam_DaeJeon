using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item1 : InteractiveObject //������1 �� Ŭ�� ������ ȹ��
{
    public override void onClick()
    {
        //ȹ��
    }
}

public class item2 : InteractiveObject //������2 �� Ŭ�� ������ ������ ����
{
    public GameObject a/*prefab�̸�*/; //prefab ����

    public override void onClick()
    {
        LoadPrefab(dialoguePrefab, transform.position + Vector3.up, Quaternion.identity); //������ ���� ��ġ
    }
}