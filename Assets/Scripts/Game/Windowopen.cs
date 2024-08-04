using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindowOpen : MonoBehaviour
{
    [SerializeField]
    private ScreenTransition screenTransition; // ScreenTransition 스크립트를 참조

    private void Start()
    {
        // FadeIn을 호출하여 투명도를 0에서 1로 변경
        // 초기 상태에서 FadeIn 호출 시 기본적으로 알파 값이 0이므로 FadeIn 메서드가 호출되면 알파 값이 1로 설정됨
        screenTransition.FadeOut(3f); // 1초 동안 애니메이션
    }
}

