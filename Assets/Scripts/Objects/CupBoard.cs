using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupBoard : InteractiveObject
{
    public AudioClip dropSound;
    //����� ������ ������ 5�� �̻� �ε帱 �� ���� ������ �ȿ��� �ϱ����� �������� �ش� �ϱ����� ���� �� �ܼ��� ���� �� �ִ�.

    //���콺 enter�� ���� props ����
    [SerializeField]
    GameObject m_objTextBox = null;

    [SerializeField]
    Sprite m_spOpenDoor = null;

    [SerializeField]
    GameObject m_objDiary = null;
    [SerializeField]
    Transform m_trFallPos = null; //�ٴڿ� �������� position


    //�� ���� ������
    bool m_isOpen = false;
    const int m_nOpenCount = 5; // �ټ��� �̻� �ε帱 �� ���� ������.
    int m_nCurrentCount = 0; //�����ؼ� �ε帰 �� 1.5 �� �Ŀ� �ʱ�ȭ.


    //�ڷ�ƾ ���� ���������
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
            Debug.LogError("m_objTextBox�� �����ϴ�.");
        }

        if(m_objDiary != null)
        {
            m_objDiary.SetActive(false);
        }
        else
        {
            Debug.LogError("m_Diary�� �����ϴ�.");
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


  


    //�ڷ�ƾ��

    //��ũ�ϴ� ȿ��
    IEnumerator CorKnocking()
    {
        if (m_isKnocking)
        {
            yield break; //�ڷ�ƾ �ߺ� ȣ�� ����
        }
        else
        {
            m_isKnocking = true;
            Vector2 vecScale = transform.localScale;
            // �ε帱�� �����Ϲ� ���� ��ȭ�� ��鸮�� ���ͷ��� ����
            transform.localScale = new Vector2(vecScale.x + 0.1f, vecScale.y + 0.1f);
            yield return new WaitForSeconds(0.05f);
            Vector3 vecRotation = transform.rotation.eulerAngles;
            transform.Rotate(vecRotation.x, vecRotation.y, vecRotation.z + 5f);
            yield return new WaitForSeconds(0.05f);
            // �ٽ� ����
            transform.localScale = vecScale;
            yield return new WaitForSeconds(0.05f);
            transform.rotation = Quaternion.Euler(vecRotation);
            
            m_isKnocking=false;
            m_nCurrentCount++; // ���ͷ����� ������ �ε帰 Ƚ�� ����
            yield break;
        }
    }

    //���� �ð� ���� 5�� �̻� �ε�ȴ��� �˻��ϴ� �ڷ�ƾ
    IEnumerator CorCheckKnockCount() 
    {
        if (m_isCounting)
        {
            yield break; // �̹� ȣ�� ���̸� break; �ڷ�ƾ �ߺ� ȣ�� ����
        }
        else
        {
            m_isCounting = true;

            yield return new WaitForSeconds(2.8f);
            //2�� �Ŀ� �ε帰 Ƚ���� nOpenCount �̻��϶�
            if(m_nCurrentCount > m_nOpenCount)
            {
                m_isOpen = true; // ������
                m_nCurrentCount = 0;
                if(m_spOpenDoor != null)
                {
                    GetComponent<SpriteRenderer>().sprite = m_spOpenDoor;
                }
                else
                {
                    Debug.LogError("m_spOpenDoor�� �����ϴ�.");

                }
                StartCoroutine(CorFallDiary());
                m_isCounting = false;
                yield break;
            }
            else
            {
                //Ư�� ������ ���� �� �ٽ� 0���� �ʱ�ȭ
                m_nCurrentCount = 0;
                m_isCounting = false;
                yield break;
            }
        }
    }

    //�ϱ����� �������� �Լ�
    IEnumerator CorFallDiary()
    {
        SoundManager.Instance.PlayEffect(dropSound);
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
