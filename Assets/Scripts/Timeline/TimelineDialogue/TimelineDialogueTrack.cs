using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.5564088f, 1f, 0f)]
[TrackClipType(typeof(TimelineDialogueClip))]
[TrackBindingType(typeof(ScenarioController))]
public class TimelineDialogueTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        foreach (var clip in GetClips())
        {
            var timelineDialogueClip = clip.asset as TimelineDialogueClip;
            if (timelineDialogueClip == null) continue;
            
            timelineDialogueClip.template.SetTime(clip.start, clip.end);
        }
        
        return ScriptPlayable<TimelineDialogueMixerBehaviour>.Create (graph, inputCount);
    }
    private List<TrackAsset> GetAllTracks(TimelineAsset asset)
    {
        List<TrackAsset> trackAssets = new();
        void GetTracksRecursively(List<TrackAsset> list, TrackAsset track)
        {
            list.Add(track);
            foreach (var childTrack in track.GetChildTracks())
            {
                GetTracksRecursively(list, childTrack);
            }
        }

        foreach (var track in asset.GetRootTracks())
        {
            GetTracksRecursively(trackAssets, track);
        }

        return trackAssets;
    }

    private List<TimelineClip> GetAllClips(List<TrackAsset> tracks, bool sorted=true)
    {
        List<TimelineClip> allClips = new();

        foreach (var track in tracks)
        {
            if (track.GetType() == typeof(TimelineDialogueTrack))
            {
                allClips.AddRange(track.GetClips());
            }
        }

        if (sorted)
        {
            allClips = allClips.OrderBy(x => x.start).ToList();
        }

        return allClips;
    }
}
