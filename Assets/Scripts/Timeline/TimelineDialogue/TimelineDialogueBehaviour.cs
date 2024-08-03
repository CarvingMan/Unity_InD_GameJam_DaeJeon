using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TimelineDialogueBehaviour : PlayableBehaviour
{
    public int dialogueIndex;
    public bool closeDialogue;
    
    private PlayableDirector _director;
    private ScenarioController _scenarioController;
    private double _startTime;
    private double _endTime;

    private bool _isPlaying = false;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (Application.isPlaying == false) return;
        if (_isPlaying) return;
        
        InitializeDialogue(playable, info);

        var dialogue = _scenarioController.scenario.dialogues[dialogueIndex];
        
        _scenarioController.dialogueUIController.ShowDialogue(new [] {dialogue}, true, () => { EndDialogue();});
        _scenarioController.OnDialogueShowed?.Invoke(dialogue.name, dialogue.dialogue);
        _isPlaying = true;
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        base.OnBehaviourPause(playable, info);

        if (_isPlaying == false || _director == null || _director.state != PlayState.Playing) return;
        
        // return to start of the dialogue
        _director.time = _startTime;
    }

    public void SetTime(double startTime, double endTime)
    {
        if (endTime < startTime)
        {
            Debug.LogError($"End time is earlier than start time: Start-{startTime} End-{endTime}");
        }

        _startTime = startTime;
        _endTime = endTime;
    }

    public void EndDialogue()
    {
        _isPlaying = false;
        _director.time = _endTime;

        if (closeDialogue)
        {
            _scenarioController.dialogueUIController.CloseDialogue();
        }
    }

    private void InitializeDialogue(Playable playable, FrameData info)
    {
        if (_scenarioController == null)
        {
            _scenarioController = GetScenarioController(info);
        }

        if (_director == null)
        {
            _director = GetPlayableDirector(playable);
        }
    }

    private ScenarioController GetScenarioController(FrameData info)
    {
        _scenarioController = info.output.GetUserData() as ScenarioController;

        if (_scenarioController == null)
        {
            Debug.LogError($"Missing Track Binding {typeof(ScenarioController)}");
        }

        return _scenarioController;
    }

    private PlayableDirector GetPlayableDirector(Playable playable)
    {
        return playable.GetGraph().GetResolver() as PlayableDirector;
    }
}
