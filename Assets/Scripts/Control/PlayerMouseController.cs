using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
		
        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if (IsPointerOverUIElement(results))
        {
            return;
        }
        
        var ray = camera.ScreenPointToRay(mousePosition);

        int nLayerMask = 1 << LayerMask.NameToLayer("Props");
        
        var raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction,20f,nLayerMask);
        
        OnMouseHover?.Invoke(raycastHit2D);
        _timer = 0;
    }

    private void HandleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            
            PointerEventData pointerData = new PointerEventData (EventSystem.current)
            {
                pointerId = -1,
            };
		
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            if (IsPointerOverUIElement(results))
            {
                return;
            }
            
            var ray = camera.ScreenPointToRay(mousePosition);
            int nLayerMask = 1 << LayerMask.NameToLayer("Props");
            var raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction,20f, nLayerMask);
            OnMouseClick?.Invoke(raycastHit2D);
        }
    }
    
    public static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults )
    {
        for(int index = 0;  index < eventSystemRaysastResults.Count; index ++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults [index];

            if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                return true;
            }

            
        }

        return false;
    }

    
}
