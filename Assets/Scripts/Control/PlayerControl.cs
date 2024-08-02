using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //PlayerControl 기준



    //이동관련//
    Vector2 m_vecMoveDirection = Vector2.zero;
    
    [SerializeField, Range(0.01f, 0.1f)]
    float m_fMoveSpeed = 0.01f; //이동 속도

    //애니메이션 관련
    Animator m_PlayerAnimator = null; // 아직 없음 
    SpriteRenderer m_spriteRenderer = null; //좌우 반전용


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

    //입력관련 메소드
    void InputProcess()
    {
        //좌우 이동 키
        bool isRightKey = Input.GetKey(KeyCode.D);
        bool isLeftKey = Input.GetKey(KeyCode.A);
        // 입력받은 키로 Move() 함수 호출
        Move(isRightKey, isLeftKey);
    }

    //m_vecMoveDirection(이동방향) 결정함수 -> 실제 이동은 FixedUpdate에서 이동
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

    // 애니메이션 관련 함수 -> 현재는 애니메이션이 없어 좌우 반전만 넣어놓음
    void SetAnimation()
    {
        //플레이어 이동 애니매이션
        if(m_PlayerAnimator != null)
        {
            //m_vecMoveDirection.x(x축 이동방향)이 0이 아니면 이동중
            if(m_vecMoveDirection.x != 0)
            {
                m_PlayerAnimator.SetBool("isWalk", true); //애니메이터 파라미터 설정
            }
            else
            {
                m_PlayerAnimator.SetBool("isWalk", false);
            }
        }
        else
        {
            Debug.LogError("m_PlayerAnimator가 없습니다.");
        }

        // 좌우 스프라이트 반전
        if(m_spriteRenderer != null)
        {
            //m_vecDirectoion.x가 양수면 오른쪽 이동, 음수면 왼쪽이동
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
                //속도가 0 일 때에는 이전 상태 유지
            }
        }
        else
        {
            Debug.LogError("m_spriteRenderer이 없습니다.");
        }
    }
}
