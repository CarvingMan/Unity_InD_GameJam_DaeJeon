using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    [SerializeField] private float refreshRate;
    [SerializeField] private Camera camera;
    
    private float _timer = 0;

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
        //레이어 마스크로 props 레이어만 맞추도록 설정
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
            var ray = camera.ScreenPointToRay(mousePosition);
            //레이어 마스크로 props 레이어만 맞추도록 설정
            int nLayerMask = 1 << LayerMask.NameToLayer("Props");
            var raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction,20f, nLayerMask);
            OnMouseClick?.Invoke(raycastHit2D);
        }
    }
}
