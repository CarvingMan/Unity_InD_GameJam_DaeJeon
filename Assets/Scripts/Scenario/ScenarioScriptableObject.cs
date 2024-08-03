using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scenario")]
public class ScenarioScriptableObject : ScriptableObject
{
    public Dialogue[] dialogues;
}
