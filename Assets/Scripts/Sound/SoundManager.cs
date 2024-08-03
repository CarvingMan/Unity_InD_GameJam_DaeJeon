using System;
using System.Collections;
using System.Collections.Generic;
using Eshikivo.DesignPatterns;
using UnityEngine;

public enum SoundEffectEnum
{
    Tick = 0,
    Open_Diary = 1,
    UI_Popup = 2,
    UI_Popout = 3,
    Cat_Cry = 4,
    
}

public class SoundManager: Singleton<SoundManager>
{
    [SerializeField] private int maxEffectSourceCount;
    [SerializeField] private int startEffectSourceCount;
    
    [SerializeField] private AudioSource effectPrefab;
    [SerializeField] private AudioSource bgmSource;

    [SerializeField] private AudioClip[] audioClips;

    private Queue<AudioSource> _effectSourcePool = new Queue<AudioSource>();
    private int _effectSourceCount = 0;

    private void Start()
    {
        Initialize();
    }

    public void PlayEffect(SoundEffectEnum soundEffectEnum)
    {
        int soundEffectIndex = (int)soundEffectEnum;

        if (soundEffectIndex >= audioClips.Length)
        {
            Debug.LogError("Invalid Index");
            return;
        }

        var clip = audioClips[soundEffectIndex];
        StartCoroutine(PlayClip(clip));
    }
    
    public void PlayBGM()
    {
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Pause();
    }

    private void Initialize()
    {
        for (int i = 0; i < startEffectSourceCount; i++)
        {
            CreateAudioSource();
        }
    }

    private AudioSource CreateAudioSource()
    {
        if (_effectSourceCount > maxEffectSourceCount)
        {
            Debug.LogError("Cannot create anymore effect source");
            return null;
        }
        
        var obj = new GameObject("EffectSource");
        obj.transform.SetParent(this.transform);

        var effectSource = obj.AddComponent<AudioSource>();
        _effectSourceCount++;
        _effectSourcePool.Enqueue(effectSource);
        
        return effectSource;
    }

    private IEnumerator PlayClip(AudioClip clip)
    {
        AudioSource source = null;;
        if (_effectSourcePool.Count == 0)
        {
            source = CreateAudioSource();
        }
        else
        {
            source = _effectSourcePool.Dequeue();
        }

        if (source == null) yield break;

        source.clip = clip;
        source.Play();

        yield return new WaitWhile(() => source.isPlaying);

        _effectSourcePool.Enqueue(source);
    }
}