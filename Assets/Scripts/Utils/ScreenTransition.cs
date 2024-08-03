using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransition: MonoBehaviour
{
    [SerializeField] private float duration;

    private Image _image;

    private void Awake()
    {
        if (_image == null)
        {
            _image = GetComponent<Image>();
        }
    }

    public Tween FadeOut(float duration)
    {
        var tween = _image.DOFade(0f, duration);
        return tween;
    }

    public Tween FadeIn(float duration)
    {
        var tween = _image.DOFade(1f, duration);
        return tween;
    }
}