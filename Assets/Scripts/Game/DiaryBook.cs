using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaryBook : MonoBehaviour
{
    public TextMeshProUGUI diaryContent;

    public void OpenDiary(string content)
    {
        diaryContent.text = content;
    }
}
