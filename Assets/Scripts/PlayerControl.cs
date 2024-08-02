using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //이동관련//
    Vector2 m_vecMoveDirection = Vector2.zero;
    const float m_fSpeed = 0.01f;
    SpriteRenderer m_spriteRenderer; //좌우 반전용
    bool m_isLookLeft = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //입력관련 메소드
    void InputProcess()
    {
        bool isRightKey = Input.GetKey(KeyCode.D);
        bool isLeftKey = Input
    }

    void Move()
    {

    }
}
