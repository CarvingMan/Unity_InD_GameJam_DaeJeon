using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public abstact class InteractiveObject : MonoBehaviour
{
    //클릭하는 메소드
    public abstact void onClick(); 

    public void LoadPrefab(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab != null)
        {
            Instantiate(prefab, positon, rotation); // 프래팹 인스턴스화 프리팹 
        }
        else
        {
            Debug.LogWarning("Prefab is null!");
        }
    }
}


