using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstact class InteractiveObject : MonoBehaviour
{
    //Ŭ���ϴ� �޼ҵ�
    public abstact void onClick(); 

    public void LoadPrefab(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab != null)
        {
            Instantiate(prefab, positon, rotation); // ������ �ν��Ͻ�ȭ ������ 
        }
        else
        {
            Debug.LogWarning("Prefab is null!");
        }
    }
}


