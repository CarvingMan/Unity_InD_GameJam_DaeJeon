using System;
using UnityEngine;

// This is just hard coded script for general game purposes
public class GeneralGameController: MonoBehaviour
{
    private InteractiveObject _currInteractiveObj = null;
    
    private void Start()
    {
        PlayerInputManager.Instance.mouseController.OnMouseClick += OnMouseClick;
        PlayerInputManager.Instance.mouseController.OnMouseHover += OnMouseHover;
    }

    private void OnMouseClick(RaycastHit2D hit)
    {
        if (!hit)
        {
            return;
        }
    }

    private void OnMouseHover(RaycastHit2D hit)
    {
        if (!hit)
        {
            OnMouseHoverExit();
            _currInteractiveObj = null;
            return;
        }

        var interactiveObject = hit.collider.GetComponent<InteractiveObject>();

        if (interactiveObject == _currInteractiveObj) return;
        
        if (interactiveObject != _currInteractiveObj)
        {
            OnMouseHoverExit();
        }

        _currInteractiveObj = interactiveObject;
        OnMouseHoverEnter();
    }

    private void OnMouseHoverEnter()
    {
        if (_currInteractiveObj == null) return;
        
        _currInteractiveObj.OnMouseHoverEnter();
    }

    private void OnMouseHoverExit()
    {
        if (_currInteractiveObj == null) return;
        
        _currInteractiveObj.OnMouseHoverExit();
    }
}