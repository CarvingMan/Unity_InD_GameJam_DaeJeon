using System;
using System.Collections;
using System.Collections.Generic;
using Febucci.UI;
using UnityEngine;
using DG.Tweening;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private TypewriterByCharacter tmp;
    [SerializeField] private TypewriterByCharacter tmp2;

    [SerializeField] private string[] introPlayer;
    [SerializeField] private string[] introButterfly;

    [SerializeField] private SpriteRenderer butterfly;
    
    private void Start()
    {
        StartCoroutine(StartIntro());
    }

    private IEnumerator StartIntro()
    {
        var color = butterfly.color;
        color.a = 0;
        butterfly.color = color;
        
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

        butterfly.DOFade(0.75f, 1.5f);

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

        Debug.Log("Done");

        yield return null;
    }
}
