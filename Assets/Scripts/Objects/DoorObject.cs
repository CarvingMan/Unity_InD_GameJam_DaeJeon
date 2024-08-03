using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorObject : InteractiveObject
{
    [SerializeField] private StageController stageController;
    
    private void Start()
    {
        stageController.OnStageClear += OnStageClear;
    }

    protected override void DoInteract()
    {
        if (IsInteractable == false) return;
        
        StartCoroutine(MoveToNextStageCo());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interact();
    }

    private IEnumerator MoveToNextStageCo()
    {
        var tween = UIManager.Instance.screenTransition.FadeOut(2);
        yield return new WaitWhile(() => tween.IsPlaying());

        SceneManager.LoadScene(2);
    }

    private void OnStageClear()
    {
        isInteractable = true;
    }
}
