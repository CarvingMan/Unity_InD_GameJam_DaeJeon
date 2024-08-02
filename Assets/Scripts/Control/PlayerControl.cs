using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //PlayerControl ����



    //�̵�����//
    Vector2 m_vecMoveDirection = Vector2.zero;
    
    [SerializeField, Range(0.01f, 0.1f)]
    float m_fMoveSpeed = 0.01f; //�̵� �ӵ�

    //�ִϸ��̼� ����
    Animator m_PlayerAnimator = null; // ���� ���� 
    SpriteRenderer m_spriteRenderer = null; //�¿� ������


    // Start is called before the first frame update
    void Start()
    {
        if (m_spriteRenderer == null)
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if(m_PlayerAnimator == null)
        {
            m_PlayerAnimator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputProcess();
    }

    private void LateUpdate()
    {
        SetAnimation();
    }

    private void FixedUpdate()
    {
        transform.Translate(m_vecMoveDirection * m_fMoveSpeed);
    }

    //�Է°��� �޼ҵ�
    void InputProcess()
    {
        //�¿� �̵� Ű
        bool isRightKey = Input.GetKey(KeyCode.D);
        bool isLeftKey = Input.GetKey(KeyCode.A);
        // �Է¹��� Ű�� Move() �Լ� ȣ��
        Move(isRightKey, isLeftKey);
    }

    //m_vecMoveDirection(�̵�����) �����Լ� -> ���� �̵��� FixedUpdate���� �̵�
    void Move(bool isRightKey, bool isLeftKey)
    {
        if (isRightKey)
        {
            m_vecMoveDirection.x = 1;
        }
        else if (isLeftKey)
        {
            m_vecMoveDirection.x = -1;
            
        }
        else
        {
            m_vecMoveDirection.x = 0;
        }


    }

    // �ִϸ��̼� ���� �Լ� -> ����� �ִϸ��̼��� ���� �¿� ������ �־����
    void SetAnimation()
    {
        //�÷��̾� �̵� �ִϸ��̼�
        if(m_PlayerAnimator != null)
        {
            //m_vecMoveDirection.x(x�� �̵�����)�� 0�� �ƴϸ� �̵���
            if(m_vecMoveDirection.x != 0)
            {
                m_PlayerAnimator.SetBool("isWalk", true); //�ִϸ����� �Ķ���� ����
            }
            else
            {
                m_PlayerAnimator.SetBool("isWalk", false);
            }
        }
        else
        {
            Debug.LogError("m_PlayerAnimator�� �����ϴ�.");
        }

        // �¿� ��������Ʈ ����
        if(m_spriteRenderer != null)
        {
            //m_vecDirectoion.x�� ����� ������ �̵�, ������ �����̵�
            if (m_vecMoveDirection.x > 0)
            {
                m_spriteRenderer.flipX = true; 
            }
            else if(m_vecMoveDirection.x < 0)
            {
                m_spriteRenderer.flipX = false; 
            }
            else
            {
                //�ӵ��� 0 �� ������ ���� ���� ����
            }
        }
        else
        {
            Debug.LogError("m_spriteRenderer�� �����ϴ�.");
        }
    }
}
