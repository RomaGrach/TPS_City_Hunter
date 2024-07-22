using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestCore : MonoBehaviour
{
    private GameObject QuestObject;
    private bool Continue = true;
    public List<quest> Quests;
    
    void Start()
    {
    }
    private void NextQuest(int QuestId)
    {
        if (Continue)
        {
            if (Quests.Count <= 0) Continue = false;
            else Quests.RemoveAt(QuestId);
        }
        else
        {
            Debug.LogError("No QuestObject Found");
        }
    }
    public void CompleteCond(int QuestInd, int ConditionInd)
    {
        try { Quests[QuestInd].conditions.RemoveAt(ConditionInd); }
        catch { }
        if (Quests.Count <= 0) NextQuest(QuestInd);
    }
}
[System.Serializable]
public class quest
{
    public string name = "Unnamed";
    public string description = "probably nothing";
    public List<string> conditions;
}
