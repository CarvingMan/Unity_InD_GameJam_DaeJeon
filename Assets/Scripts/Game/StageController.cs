using System;
using System.Collections.Generic;
using UnityEngine;

public class StageController: MonoBehaviour
{
    private Dictionary<string, object> _stateDict = new();
    
    public void StartStage()
    {
        // TODO: Timer 설정, 게임 세팅, 기타 등등
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

    private object GetState(string id)
    {
        _stateDict.TryGetValue(id, out var value);

        return value;
    }
}