using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoard : InteractiveObject
{

    //빈약한 벽장을 빠르게 5번 이상 두드릴 시 문이 열리며 안에서 일기장이 떨어지고 해당 일기장을 누를 시 단서를 얻을 수 있다.

    //마우스 enter시 보일 props 설명
    [SerializeField]
    GameObject m_objTextBox = null;

    [SerializeField]
    Sprite m_spOpenDoor = null;

    [SerializeField]
    GameObject m_objDiary = null;
    [SerializeField]
    Transform m_trFallPos = null; //바닥에 떨어지는 position


    //문 열림 변수들
    bool m_isOpen = false;
    const int m_nOpenCount = 5; // 다섯번 이상 두드릴 시 문이 열린다.
    int m_nCurrentCount = 0; //연속해서 두드린 수 1.5 초 후에 초기화.


    //코루틴 관련 멤버변수들
    bool m_isKnocking = false;
    bool m_isCounting = false;


    private void Start()
    {
        if(m_objTextBox != null)
        {
            m_objTextBox.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objTextBox가 없습니다.");
        }

        if(m_objDiary != null)
        {
            m_objDiary.SetActive(false);
        }
        else
        {
            Debug.LogError("m_Diary가 없습니다.");
        }

    }


    protected override void DoInteract()
    {
        if(m_isOpen == false)
        {
            StartCoroutine(CorKnocking());
            StartCoroutine(CorCheckKnockCount());
        }
    }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        if(m_isOpen == false)
        {
            m_objTextBox.SetActive(true);
        }
    }

    public override void OnMouseHoverExit()
    {
        base.OnMouseHoverExit();
        m_objTextBox.SetActive(false);
    }


  


    //코루틴들

    //노크하는 효과
    IEnumerator CorKnocking()
    {
        if (m_isKnocking)
        {
            yield break; //코루틴 중복 호출 방지
        }
        else
        {
            m_isKnocking = true;
            Vector2 vecScale = transform.localScale;
            // 두드릴때 스케일및 각도 변화로 흔들리는 인터렉션 구현
            transform.localScale = new Vector2(vecScale.x + 0.1f, vecScale.y + 0.1f);
            yield return new WaitForSeconds(0.05f);
            Vector3 vecRotation = transform.rotation.eulerAngles;
            transform.Rotate(vecRotation.x, vecRotation.y, vecRotation.z + 5f);
            yield return new WaitForSeconds(0.05f);
            // 다시 복구
            transform.localScale = vecScale;
            yield return new WaitForSeconds(0.05f);
            transform.rotation = Quaternion.Euler(vecRotation);
            
            m_isKnocking=false;
            m_nCurrentCount++; // 인터렉션이 끝나고 두드린 횟수 증가
            yield break;
        }
    }

    //제한 시간 내에 5번 이상 두드렸는지 검사하는 코루틴
    IEnumerator CorCheckKnockCount() 
    {
        if (m_isCounting)
        {
            yield break; // 이미 호출 중이면 break; 코루틴 중복 호출 금지
        }
        else
        {
            m_isCounting = true;

            yield return new WaitForSeconds(2.8f);
            //2초 후에 두드린 횟수가 nOpenCount 이상일때
            if(m_nCurrentCount > m_nOpenCount)
            {
                m_isOpen = true; // 문열림
                m_nCurrentCount = 0;
                if(m_spOpenDoor != null)
                {
                    GetComponent<SpriteRenderer>().sprite = m_spOpenDoor;
                }
                else
                {
                    Debug.LogError("m_spOpenDoor가 없습니다.");

                }
                StartCoroutine(CorFallDiary());
                m_isCounting = false;
                yield break;
            }
            else
            {
                //특정 수보다 적을 시 다시 0으로 초기화
                m_nCurrentCount = 0;
                m_isCounting = false;
                yield break;
            }
        }
    }

    //일기장이 떨어지는 함수
    IEnumerator CorFallDiary()
    {
        m_objDiary.GetComponent<ADiary>().SetDiaryRedy(false);
        m_objDiary.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            m_objDiary.transform.position = Vector2.Lerp(m_objDiary.transform.position, m_trFallPos.position, 0.1f);
            yield return new WaitForSeconds(0.05f);
            float fDistance = Vector2.Distance(m_objDiary.transform.position, m_trFallPos.position);
            if (fDistance < 0.1f)
            {
                m_objDiary.GetComponent<ADiary>().SetDiaryRedy(true);
                yield break;
            }
            

        }


    }
}
