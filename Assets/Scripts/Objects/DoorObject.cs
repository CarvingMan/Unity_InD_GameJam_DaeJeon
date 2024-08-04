using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorObject : InteractiveObject
{
    [SerializeField] private StageController stageController;

    [SerializeField] GameObject m_objTextDoor = null;
    private void Start()
    {
        if (m_objTextDoor != null)
        {
            m_objTextDoor.SetActive(false);
        }
        else
        {
            Debug.LogError("m_objTextDoor가 지정되지 않음");
        }

        stageController.OnStageClear += OnStageClear;
        }

    public override void OnMouseHoverEnter()
    {
        base.OnMouseHoverEnter();
        m_objTextDoor.SetActive(true);
    }
    
    public override void OnMouseHoverExit()
    {
        base.OnMouseHoverExit();
        m_objTextDoor.SetActive(false);
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
