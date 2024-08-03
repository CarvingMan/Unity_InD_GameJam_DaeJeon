using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StageController: MonoBehaviour
{
    private const int MAX_DIARY_COUNT = 4;
    private Dictionary<string, object> _stateDict = new();
    
    private HashSet<string> _foundDiaries = new();
    private bool _stageClear = false;

    public Action OnStageClear;
    public Action<int> OnDiaryFound;

    public bool IsStageClear => _stageClear;

    private void Start()
    {
        StartStage();
        OnDiaryFound += (int index) =>
        {
            Debug.Log($"Found Diaries: {index}");
        };
    }

    public void StartStage()
    {
        StartCoroutine(StartStageCo());
    }

    // TODO: State 어디까지 관리가 필요할지?
    public void RegisterState(string id, object value)
    {
        var added = _stateDict.TryAdd(id, value);
        if (!added)
        {
            Debug.LogError("Duplicate id for state");
        }
    }

    public bool GetState<T>(string id, out T value)
    {
        var obj = GetState(id);
        if (obj == null)
        {
            Debug.LogError($"Failed to state for {id}");
            value = default(T);
            return false;
        }

        try
        {
            value = (T)obj;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            value = default(T);
            return false;
        }

        return true;
    }

    public void UpdateDiaryFound(string diaryName)
    {
        if (_foundDiaries.Contains(diaryName))
        {
            return;
        }

        _foundDiaries.Add(diaryName);
        OnDiaryFound?.Invoke(_foundDiaries.Count);

        var diaryCount = _foundDiaries.Count;
        if (diaryCount >= MAX_DIARY_COUNT)
        {
            _stageClear = true;
            OnStageClear?.Invoke();
        }
    }

    private object GetState(string id)
    {
        _stateDict.TryGetValue(id, out var value);

        return value;
    }


    private IEnumerator StartStageCo()
    {
        var playerController = FindObjectOfType<PlayerControl>();
        _foundDiaries.Clear();
        _stageClear = false;
        if (playerController == null)
        {
            Debug.LogError("DSLKFJDLKSF");
            yield break;
        }
        
        playerController.SetPlayerStop(true);

        var tween = UIManager.Instance.screenTransition.FadeIn(2);
        yield return new WaitWhile(tween.IsPlaying);
        
        playerController.SetPlayerStop(false);
    }

}