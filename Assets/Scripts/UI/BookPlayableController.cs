using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// TODO: Add Book State: Opened, Closed
public class BookPlayableController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;

    [Header("Clips")] 
    [SerializeField] private PlayableAsset bookOpenAsset;
    [SerializeField] private PlayableAsset bookCloseAsset;
    [SerializeField] private PlayableAsset bookNextPageAsset;
    [SerializeField] private PlayableAsset bookPrevPageAsset;

    private BookUIState m_state = BookUIState.Closed;
    public BookUIState State => m_state;
    
    public IEnumerator OpenBookCoroutine(bool force = true)
    {
        if (m_state == BookUIState.Opened) yield break;
        
        yield return PrepareDirector(bookOpenAsset, force);
        yield return PlayDirector();

        m_state = BookUIState.Opened;
    }

    public IEnumerator CloseBookCoroutine(bool force = true)
    {
        if (m_state == BookUIState.Closed) yield break;
        
        yield return PrepareDirector(bookCloseAsset, force);
        yield return PlayDirector();

        m_state = BookUIState.Closed;
    }

    public IEnumerator NextPageCoroutine(bool force = true)
    {
        if (m_state == BookUIState.Closed) yield break;
        
        yield return PrepareDirector(bookNextPageAsset, force);
        yield return PlayDirector();
    }
    
    public IEnumerator PrevPageCoroutine(bool force = true)
    {
        if (m_state == BookUIState.Closed) yield break;
        
        yield return PrepareDirector(bookPrevPageAsset, force);
        yield return PlayDirector();
    }

    private IEnumerator PrepareDirector(PlayableAsset asset, bool force)
    {
        if (director.state == PlayState.Playing)
        {
            if (force)
            {
                director.Stop();
            }

            yield return new WaitWhile(() => director.state == PlayState.Playing);
        }

        director.playableAsset = asset;
    }

    private IEnumerator PlayDirector()
    {
        director.Play();

        yield return new WaitWhile(() => director.state == PlayState.Playing);
    }
}

public enum BookUIState {
    Opened,
    Closed
}
