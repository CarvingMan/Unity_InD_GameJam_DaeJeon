using UnityEngine;

public class WIndow : MonoBehaviour
{
    [SerializeField]
    private GameObject catWindow; // Ŭ���� ����� â�� ������Ʈ

    [SerializeField]
    private GameObject diaryPrefab; // ����߸� �ϱ��� ������
    [SerializeField]
    private Transform fallPosition; // �ϱ����� ������ ��ġ

    private void Start()
    {
        // FadeIn�� ȣ���Ͽ� ������ 0���� 1�� ����
        FadeIn(1f); // 1�� ���� �ִϸ��̼�
    }

    private void Update()
    {
        // catWindow Ŭ�� �� �ϱ��� ����߸���
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == catWindow) // catWindow Ŭ�� Ȯ��
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
            // �ʿ��� �߰� �ʱ�ȭ �۾��� ���⿡ �߰��� �� �ֽ��ϴ�.
        }
        else
        {
            Debug.LogError("diaryPrefab �Ǵ� fallPosition�� �������� �ʾҽ��ϴ�.");
        }
    }

    private void FadeIn(float duration)
    {
        // FadeIn ������ ���⿡ �߰��մϴ�.
    }
}
