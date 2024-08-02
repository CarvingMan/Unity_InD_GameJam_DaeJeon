using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item1 : InteractiveObject //아이템1 를 클릭 했을때 획득
{
    public override void onClick()
    {
        //획득
    }
}

public class item2 : InteractiveObject //아이템2 를 클릭 했을때 프리팹 열기
{
    public GameObject a/*prefab이름*/; //prefab 연결

    public override void onClick()
    {
        LoadPrefab(dialoguePrefab, transform.position + Vector3.up, Quaternion.identity); //프리팹 나올 위치
    }
}