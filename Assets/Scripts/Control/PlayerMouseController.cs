using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMouseController : MonoBehaviour
{
    [SerializeField] private float refreshRate;
    [SerializeField] private Camera camera;
    
    private float _timer = 0;
    private bool isActive = true;

    public Action<RaycastHit2D> OnMouseHover;
    public Action<RaycastHit2D> OnMouseClick;
    
    private void FixedUpdate()
    {
        HandleHover();
    }

    private void Update()
    {
        HandleClick();
    }

    private void HandleHover()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer < refreshRate) return;
        
        var mousePosition = Input.mousePosition;
        var ray = camera.ScreenPointToRay(mousePosition);
        // bool isOverUI = EventSystem.current.IsPointerOverGameObject();
        //
        // if (isOverUI)
        // {
        //     Debug.Log(EventSystem.current.gameObject.name);
        //     return;
        // }

        int nLayerMask = 1 << LayerMask.NameToLayer("Props");
        
        var raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction,20f,nLayerMask);
        
        OnMouseHover?.Invoke(raycastHit2D);
        _timer = 0;
    }

    private void HandleClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var mousePosition = Input.mousePosition;
            
            // bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            // if (isOverUI) return;
            var ray = camera.ScreenPointToRay(mousePosition);
            int nLayerMask = 1 << LayerMask.NameToLayer("Props");
            var raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction,20f, nLayerMask);
            OnMouseClick?.Invoke(raycastHit2D);
        }
    }

    
}
