using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransition: MonoBehaviour
{
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
        var color = _image.color;
        color.a = 0;
        _image.color = color;
        var tween = _image.DOFade(1f, duration);
        return tween;
    }

    public Tween FadeIn(float duration)
    {
        var color = _image.color;
        color.a = 1;
        _image.color = color;
        var tween = _image.DOFade(0, duration);
        return tween;
    }
}