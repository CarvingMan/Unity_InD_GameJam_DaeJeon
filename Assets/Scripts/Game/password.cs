using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;


public class password : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects; // 오브젝트 배열
    private int[] passwordArray; // 패스워드 배열
    private int[] correctPassword = { 1, 0, 1, 0, 1, 0, 1, 0 }; // 정답 배열 초기화
    [SerializeField]
    private Lock lockObject; // Lock 스크립트를 가진 오브젝트
    
    [SerializeField]
    private GameObject lockCloset; // LockCloset 오브젝트 참조

    [SerializeField]
    GameObject lockClosetobject;

    private void Start()
    {
        // 패스워드 배열 초기화
        passwordArray = new int[objects.Length];

        if (lockClosetobject != null)
        {
            lockClosetobject.SetActive(false);
        }
        else
        {
            Debug.LogError("lockClosetobject가 없습니다.");
        }

        // 배열에 있는 각 오브젝트에 클릭 이벤트를 등록합니다.
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                ObjectClickHandler clickHandler = obj.AddComponent<ObjectClickHandler>();
                clickHandler.Initialize(ToggleColor);
            }
        }
    }

    // 클릭 시 호출될 메소드 - 색상 토글
    private void ToggleColor(GameObject clickedObject)
    {
        SpriteRenderer spriteRenderer = clickedObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // 현재 알파 값을 확인하여 토글합니다.
            if (spriteRenderer.color.a == 0.25f)
            {
                spriteRenderer.color = new Color(0, 0, 0, 0.0f); // 알파 값을 0.0으로 변경
                UpdatePasswordArray(clickedObject, 0); // 패스워드 배열에 0 저장
            }
            else
            {
                spriteRenderer.color = new Color(0, 0, 0, 0.25f); // 알파 값을 0.25로 변경
                UpdatePasswordArray(clickedObject, 1); // 패스워드 배열에 1 저장
            }
        }
    }

    // 패스워드 배열 업데이트 메소드
    private void UpdatePasswordArray(GameObject obj, int value)
    {
        int index = System.Array.IndexOf(objects, obj);
        if (index >= 0 && index < passwordArray.Length)
        {
            passwordArray[index] = value; // 인덱스에 값을 저장
        }

        // 정답 배열과 비교
        CompareWithCorrectPassword();
    }

    // 정답 배열과 비교하는 메소드
    private void CompareWithCorrectPassword()
    {
        bool isCorrect = true;

        // 길이가 같은지 확인
        if (passwordArray.Length != correctPassword.Length)
        {
            isCorrect = false;
        }
        else
        {
            // 각 요소를 비교
            for (int i = 0; i < passwordArray.Length; i++)
            {
                if (passwordArray[i] != correctPassword[i])
                {
                    isCorrect = false;
                    break;
                }
            }
        }

        // 결과 출력 (디버그 메시지로 확인)
        if (isCorrect)
        {
            Debug.Log("패스워드가 일치합니다!");
            lockObject.Unlock(); // 패스워드가 일치하면 Unlock 메소드 호출

            // LockCloset의 이미지 변경
            ChangeLockClosetImage();
            lockClosetobject.SetActive(true);
        }
        else
        {
            Debug.Log("패스워드가 일치하지 않습니다.");
        }
    }

    private void ChangeLockClosetImage()
    {
        // LockCloset 오브젝트의 Image 컴포넌트를 얻음
        Image imageComponent = lockCloset.GetComponent<Image>();
        if (imageComponent != null)
        {
            // "옷_0" 이미지로 변경
            imageComponent.sprite = Resources.Load<Sprite>("옷"); // Resources 폴더에 이미지가 있어야 함
        }
        else
        {
            Debug.LogError("LockCloset에 Image 컴포넌트가 없습니다.");
        }
    }
}

// 클릭 처리를 위한 별도의 클래스
public class ObjectClickHandler : MonoBehaviour
{
    private System.Action<GameObject> onClick; // 클릭 이벤트 처리기

    // 초기화 메소드
    public void Initialize(System.Action<GameObject> onClickAction)
    {
        onClick = onClickAction;
    }

    private void OnMouseDown() // 클릭 시 호출되는 메소드
    {
        onClick?.Invoke(gameObject); // 클릭된 오브젝트를 전달
    }
}
