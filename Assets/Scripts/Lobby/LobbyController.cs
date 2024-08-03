using System;
using System.Collections;
using System.Collections.Generic;
using Febucci.UI;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private TypewriterByCharacter tmp;
    [SerializeField] private TypewriterByCharacter tmp2;

    [SerializeField] private string[] introPlayer;
    [SerializeField] private string[] introButterfly;

    [SerializeField] private SpriteRenderer startIcon;
    [SerializeField] private SpriteRenderer butterfly;

    [SerializeField] private GameObject light;
    [SerializeField] private Light2D global;
    [SerializeField] private Camera cam;

    private bool _introStarted = false;
    
    private void Start()
    {
        global.gameObject.SetActive(false);
        var color = butterfly.color;
        color.a = 0;
        butterfly.color = color;
    }

    private void Update()
    {
        if (_introStarted) return;

        var mousePosition = Input.mousePosition;
        var worldPosition = cam.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        light.transform.position = worldPosition;

        if (Input.GetMouseButtonDown(0))
        {
            var collider = startIcon.GetComponent<Collider2D>();
            if (collider.OverlapPoint(worldPosition))
            {
                StartIntro();
            }
        }
    }

    private void StartIntro()
    {
        StartCoroutine(StartIntroCo());
        _introStarted = true;
    }

    private IEnumerator StartIntroCo()
    {
        var spotLight = light.GetComponent<Light2D>();

        while (spotLight.intensity > 0.01f)
        {
            spotLight.intensity -= Time.deltaTime * 0.25f;
            yield return null;
        }

        spotLight.intensity = 0;
        
        light.gameObject.SetActive(false);
        global.gameObject.SetActive(true);
        startIcon.gameObject.SetActive(false);
        
        foreach (var intro in introPlayer)
        {
            tmp.ShowText(intro);

            yield return new WaitWhile(() => tmp.isShowingText);
            yield return new WaitForSeconds(2);
            
            tmp.StartDisappearingText();
        
            // NOTE: 동작안함 
            // yield return new WaitWhile(() => tmp.isHidingText);
            yield return new WaitForSeconds(3.5f);
        }

        var tween = butterfly.DOFade(1, 3);
        yield return new WaitWhile(tween.IsPlaying);
        yield return new WaitForSeconds(2);

        // butterfly.DOFade(0.75f, 1.5f);

        foreach (var intro in introButterfly)
        {
            tmp2.ShowText(intro);

            yield return new WaitWhile(() => tmp2.isShowingText);
            yield return new WaitForSeconds(2);
            
            tmp2.StartDisappearingText();
        
            // NOTE: 동작안함 
            // yield return new WaitWhile(() => tmp.isHidingText);
            yield return new WaitForSeconds(3.5f);
        }
        
        tween = butterfly.DOFade(0, 2.5f);
        yield return new WaitWhile(tween.IsPlaying);

        if (SceneManager.sceneCount < 2)
        {
            Debug.LogError("Not enough scenes");
            yield break;
        }

        LoadMain();
    }

    private void LoadMain()
    {
        SceneManager.LoadScene(1);
    }
}
