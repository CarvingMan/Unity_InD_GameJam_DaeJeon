using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;


public class password : MonoBehaviour
{
    [SerializeField]
    private Image[] objects; // ������Ʈ �迭
    private int[] passwordArray; // �н����� �迭
    private int[] correctPassword = { 1, 0, 1, 0, 1, 0, 1, 0 }; // ���� �迭 �ʱ�ȭ
    [SerializeField]
    private Lock lockObject; // Lock ��ũ��Ʈ�� ���� ������Ʈ
    
    [SerializeField]
    private GameObject lockCloset; // LockCloset ������Ʈ ����

    [SerializeField]
    GameObject lockClosetobject;

    [SerializeField] private Sprite openedClosetSprite;

    private void Start()
    {
        // �н����� �迭 �ʱ�ȭ
        passwordArray = new int[objects.Length];

        if (lockClosetobject != null)
        {
            lockClosetobject.SetActive(false);
        }
        else
        {
            Debug.LogError("lockClosetobject�� �����ϴ�.");
        }
    }

    // Ŭ�� �� ȣ��� �޼ҵ� - ���� ���
    public void ToggleColor(int index)
    {
        var image = objects[index];
        var color = image.color;

        if (color.a == 0.25f)
        {
            color.a = 0;
            UpdatePasswordArray(index, 0);
        }
        else
        {
            color.a = 0.25f;
            UpdatePasswordArray(index, 1);
        }
        
        image.color = color;
    }
    
    private void UpdatePasswordArray(int index, int value)
    {
        if (index >= 0 && index < passwordArray.Length)
        {
            passwordArray[index] = value; // �ε����� ���� ����
        }

        // ���� �迭�� ��
        CompareWithCorrectPassword();
    }

    // ���� �迭�� ���ϴ� �޼ҵ�
    private void CompareWithCorrectPassword()
    {
        bool isCorrect = true;

        // ���̰� ������ Ȯ��
        if (passwordArray.Length != correctPassword.Length)
        {
            isCorrect = false;
        }
        else
        {
            // �� ��Ҹ� ��
            for (int i = 0; i < passwordArray.Length; i++)
            {
                if (passwordArray[i] != correctPassword[i])
                {
                    isCorrect = false;
                    break;
                }
            }
        }

        // ��� ��� (����� �޽����� Ȯ��)
        if (isCorrect)
        {
            Debug.Log("�н����尡 ��ġ�մϴ�!");
            lockObject.Unlock(); // �н����尡 ��ġ�ϸ� Unlock �޼ҵ� ȣ��

            // LockCloset�� �̹��� ����
            ChangeLockClosetImage();
            lockClosetobject.SetActive(true);
        }
        else
        {
            Debug.Log("�н����尡 ��ġ���� �ʽ��ϴ�.");
        }
    }

    private void ChangeLockClosetImage()
    {
        // LockCloset ������Ʈ�� Image ������Ʈ�� ����
        Image imageComponent = lockCloset.GetComponent<Image>();
        if (imageComponent != null)
        {
            // "��_0" �̹����� ����
            imageComponent.sprite = openedClosetSprite; // Resources ������ �̹����� �־�� ��
        }
        else
        {
            Debug.LogError("LockCloset�� Image ������Ʈ�� �����ϴ�.");
        }
    }
}

// Ŭ�� ó���� ���� ������ Ŭ����
public class ObjectClickHandler : MonoBehaviour
{
    private System.Action<GameObject> onClick; // Ŭ�� �̺�Ʈ ó����

    // �ʱ�ȭ �޼ҵ�
    public void Initialize(System.Action<GameObject> onClickAction)
    {
        onClick = onClickAction;
    }

    private void OnMouseDown() // Ŭ�� �� ȣ��Ǵ� �޼ҵ�
    {
        onClick?.Invoke(gameObject); // Ŭ���� ������Ʈ�� ����
    }
}
