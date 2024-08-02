using System;
using UnityEngine;

public abstract class InteractiveObject: MonoBehaviour
{
    protected StageController stageController;
    protected bool isInteractable;
    protected bool isInteracted;

    protected bool initialized = false;
    
    public bool IsInteractable => isInteractable;

    public Action<bool> OnInteractiveStateChange;

    public virtual void Interact()
    {
        if (initialized == false)
        {
            Debug.LogError($"{this.gameObject.name} not initialized");
            return;
        }

        DoInteract();
    }

    public virtual void Initialize(StageController stageController)
    {
        this.stageController = stageController;

        initialized = true;
    }
    
    protected abstract void DoInteract();
}