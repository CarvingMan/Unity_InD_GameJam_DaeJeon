using UnityEngine;
using DG.Tweening; // DoTween 네임스페이스 추가

public class WindowObject : MonoBehaviour
{
    [SerializeField]
    private GameObject wallPrefab; // 벽 프리팹
    [SerializeField]
    private Vector3 startPosition; // 벽의 시작 위치 (아래쪽)
    [SerializeField]
    private Vector3 endPosition; // 벽의 최종 위치 (위쪽)
    [SerializeField]
    private float moveDuration = 1f; // 이동 시간
    [SerializeField]
    private float fadeDuration = 1f; // 페이드 시간

    private void Start()
    {
        // 벽 생성
        GameObject wall = Instantiate(wallPrefab, startPosition, Quaternion.identity);
        Renderer wallRenderer = wall.GetComponent<Renderer>();

        // 초기 알파 값 설정 (완전 투명)
        Color wallColor = wallRenderer.material.color;
        wallColor.a = 0; // 초기 알파 값을 0으로 설정
        wallRenderer.material.color = wallColor;

        // DoTween을 이용한 애니메이션
        MoveAndFadeInWall(wall.transform, wallRenderer);
    }

    private void MoveAndFadeInWall(Transform wallTransform, Renderer wallRenderer)
    {
        // 벽을 위로 이동하면서 알파 값을 변경
        wallTransform.DOMove(endPosition, moveDuration).SetEase(Ease.OutSine);

        // 알파 값을 변경하여 벽을 서서히 나타나게 함
        wallRenderer.material.DOFade(1, fadeDuration).SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                // 애니메이션 완료 후 추가 작업이 필요하면 여기에 작성
                Debug.Log("벽이 완전히 나타났습니다.");
            });
    }
}
