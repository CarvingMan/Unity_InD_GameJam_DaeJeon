using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class TimelineDialogueClip : PlayableAsset, ITimelineClipAsset
{
    public TimelineDialogueBehaviour template = new TimelineDialogueBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TimelineDialogueBehaviour>.Create (graph, template);
        TimelineDialogueBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
