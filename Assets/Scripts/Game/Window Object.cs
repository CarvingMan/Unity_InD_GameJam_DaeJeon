using UnityEngine;
using DG.Tweening; // DoTween ���ӽ����̽� �߰�

public class WindowObject : MonoBehaviour
{
    [SerializeField]
    private GameObject wallPrefab; // �� ������
    [SerializeField]
    private Vector3 startPosition; // ���� ���� ��ġ (�Ʒ���)
    [SerializeField]
    private Vector3 endPosition; // ���� ���� ��ġ (����)
    [SerializeField]
    private float moveDuration = 1f; // �̵� �ð�
    [SerializeField]
    private float fadeDuration = 1f; // ���̵� �ð�

    private void Start()
    {
        // �� ����
        GameObject wall = Instantiate(wallPrefab, startPosition, Quaternion.identity);
        Renderer wallRenderer = wall.GetComponent<Renderer>();

        // �ʱ� ���� �� ���� (���� ����)
        Color wallColor = wallRenderer.material.color;
        wallColor.a = 0; // �ʱ� ���� ���� 0���� ����
        wallRenderer.material.color = wallColor;

        // DoTween�� �̿��� �ִϸ��̼�
        MoveAndFadeInWall(wall.transform, wallRenderer);
    }

    private void MoveAndFadeInWall(Transform wallTransform, Renderer wallRenderer)
    {
        // ���� ���� �̵��ϸ鼭 ���� ���� ����
        wallTransform.DOMove(endPosition, moveDuration).SetEase(Ease.OutSine);

        // ���� ���� �����Ͽ� ���� ������ ��Ÿ���� ��
        wallRenderer.material.DOFade(1, fadeDuration).SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                // �ִϸ��̼� �Ϸ� �� �߰� �۾��� �ʿ��ϸ� ���⿡ �ۼ�
                Debug.Log("���� ������ ��Ÿ�����ϴ�.");
            });
    }
}
