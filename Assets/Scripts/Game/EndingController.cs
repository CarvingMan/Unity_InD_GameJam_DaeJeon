using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    private void Start()
    {
        StartEnding();
    }

    public void StartEnding()
    {
        StartCoroutine(EndingCo());
    }

    private IEnumerator EndingCo()
    {
        var tween = UIManager.Instance.screenTransition.FadeIn(3);
        yield return new WaitWhile(tween.IsPlaying);
        yield return new WaitForSeconds(5);
        
        MoveToLobby();
    }

    public void MoveToLobby()
    {
        SceneManager.LoadScene(0);
    }
}
