using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글턴 인스턴스
    public int diaryReadCount = 0; // 일기장 읽은 횟수

    private void Awake()
    {
        // 싱글턴 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
