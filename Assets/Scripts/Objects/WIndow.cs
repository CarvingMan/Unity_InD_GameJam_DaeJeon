using UnityEngine;

public class WIndow : MonoBehaviour
{
    [SerializeField]
    private GameObject catWindow; // 클릭할 고양이 창문 오브젝트

    [SerializeField]
    private GameObject diaryPrefab; // 떨어뜨릴 일기장 프리팹
    [SerializeField]
    private Transform fallPosition; // 일기장이 떨어질 위치

    private void Start()
    {
        // FadeIn을 호출하여 투명도를 0에서 1로 변경
        FadeIn(1f); // 1초 동안 애니메이션
    }

    private void Update()
    {
        // catWindow 클릭 시 일기장 떨어뜨리기
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == catWindow) // catWindow 클릭 확인
            {
                DropDiary();
            }
        }
    }

    private void DropDiary()
    {
        if (diaryPrefab != null && fallPosition != null)
        {
            GameObject diary = Instantiate(diaryPrefab, fallPosition.position, Quaternion.identity);
            // 필요한 추가 초기화 작업을 여기에 추가할 수 있습니다.
        }
        else
        {
            Debug.LogError("diaryPrefab 또는 fallPosition이 설정되지 않았습니다.");
        }
    }

    private void FadeIn(float duration)
    {
        // FadeIn 로직을 여기에 추가합니다.
    }
}
