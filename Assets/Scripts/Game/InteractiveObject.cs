using System;
using UnityEngine;

public abstract class InteractiveObject: MonoBehaviour
{
    public AudioClip soundEffect;
    
    protected StageController stageController;
    protected bool isInteractable;
    protected bool isInteracted;

    protected bool initialized = false;
    
    public bool IsInteractable => isInteractable;

    public Action<bool> OnInteractiveStateChange;

    public virtual void Interact()
    {
        //Ŭ���Ҷ� ������ ���� �켱�� �ּ�ó�� �� �ξ����ϴ�!

        //if (initialized == false)
        //{
        //    Debug.LogError($"{this.gameObject.name} not initialized");
        //    return;
        //}
        
        DoInteract();

        if (soundEffect != null)
        {
            SoundManager.Instance.PlayEffect(soundEffect);
        }
    }

    public virtual void Initialize(StageController stageController)
    {
        this.stageController = stageController;

        initialized = true;
    }
    
    protected abstract void DoInteract();

    public virtual void OnMouseHoverEnter()
    {
    }

    public virtual void OnMouseHoverExit()
    {
    }
}