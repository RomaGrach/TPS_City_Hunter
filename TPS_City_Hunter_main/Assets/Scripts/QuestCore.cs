using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCore : MonoBehaviour
{
    public bool Continue = true;
    public List<quest> Quests;
    
    void Start()
    {
    }
    private void NextQuest(int removeQuestId)
    {
        if (Continue)
        {
            if (Quests.Count <= 0) Continue = false;
            else Quests.RemoveAt(removeQuestId);
        }
        else
        {
            Debug.LogError("No QuestObject Found");
        }
    }
    public void CompleteCond(int QuestInd, int ConditionInd)
    {
        try { Debug.Log($"Removed cond {ConditionInd}!"); Quests[QuestInd].conditions.RemoveAt(ConditionInd); }
        catch { Debug.Log("Couldn't remove condition!"); }
        if (Quests[QuestInd].conditions.Count <= 0) NextQuest(QuestInd);
    }

    [System.Serializable]
    public class quest
    {
        public string name = "Unnamed";
        public string description = "probably nothing";
        public List<string> conditions;
    }
}

