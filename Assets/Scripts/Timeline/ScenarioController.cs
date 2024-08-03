using System;
using UnityEngine;
using UnityEngine.Playables;

public class ScenarioController: MonoBehaviour
{
    public DialogueUIController dialogueUIController;
        
    private PlayableDirector _director = null;
    private Action OnScenarioEnd;
        
    public Action<string, string> OnDialogueShowed { get; protected set; }

    public bool Initialized => _director != null;

    private void Awake()
    {
        var director = this.GetComponent<PlayableDirector>();
        this.Initialize(director);
    }

    public virtual void Initialize(PlayableDirector director)
    {
        _director = director;
    }

    public virtual void StartScenario(Action onScenarioEnd)
    {
        if (Initialized == false)
        {
            Debug.LogError("Scenario not initialized");
            return;
        }

        this.OnScenarioEnd += onScenarioEnd;

        this._director.Play();
    }

    public virtual void EndScenario(bool invokeOnScenarioEnd=true)
    {
        if (this._director.state == PlayState.Playing)
        {
            this._director.Pause();
        }
            
        dialogueUIController.CloseDialogue();
        
        if (invokeOnScenarioEnd)
        {
            OnScenarioEnd?.Invoke();
        }       

        OnScenarioEnd = null;
    }

    public virtual string GetDialogueLocalizationKey(int dialogueID)
    {
        return null;
    }
}