using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //�̵�����//
    Vector2 m_vecMoveDirection = Vector2.zero;
    const float m_fSpeed = 0.01f;
    SpriteRenderer m_spriteRenderer; //�¿� ������
    bool m_isLookLeft = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�Է°��� �޼ҵ�
    void InputProcess()
    {
        bool isRightKey = Input.GetKey(KeyCode.D);
        bool isLeftKey = Input
    }

    void Move()
    {

    }
}
