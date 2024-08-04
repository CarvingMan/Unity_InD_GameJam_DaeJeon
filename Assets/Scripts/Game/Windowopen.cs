using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindowOpen : MonoBehaviour
{
    [SerializeField]
    private ScreenTransition screenTransition; // ScreenTransition ��ũ��Ʈ�� ����

    private void Start()
    {
        // FadeIn�� ȣ���Ͽ� ������ 0���� 1�� ����
        // �ʱ� ���¿��� FadeIn ȣ�� �� �⺻������ ���� ���� 0�̹Ƿ� FadeIn �޼��尡 ȣ��Ǹ� ���� ���� 1�� ������
        screenTransition.FadeOut(3f); // 1�� ���� �ִϸ��̼�
    }
}

