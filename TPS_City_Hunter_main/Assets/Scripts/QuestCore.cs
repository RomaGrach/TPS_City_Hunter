using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestCore : MonoBehaviour
{
    public GameObject NameTextObject, QuestTextObject;
    private TMP_Text NameText, QuestText;
    private bool Continue = true;

    private bool Fade = false;
    public float FadeTime = 3f;
    private float prev = 0f;
    private string clearedConditions = "";

    public List<quest> Quests;
    private Dictionary<int, quest> res_quests = new Dictionary<int, quest>();
    private Dictionary<string, string> RemovedConditions = new Dictionary<string, string>();

    public bool DebugCheck = false;

    private void Update()
    {
        if (Fade)
        {
            if (Time.time - prev > FadeTime)
            {
                Fade = false;
                //QuestText.SetText(clearedConditions);
                UpdateUI();
            }
        }
    }

    void Start()
    {
        for (int i = 0; i < Quests.Count; i++) 
        {
            for (int j = 0; j < Quests[i].conditions.Count; j++)
                Quests[i].res_conditions[j] = Quests[i].conditions[j];
            Quests[i].setHighestInd();
            res_quests[i] = Quests[i];
        }
        try { NameText = NameTextObject.GetComponent<TMP_Text>(); QuestText = QuestTextObject.GetComponent<TMP_Text>(); }
        catch { Continue = false; }
        UpdateUI();
    }
    private void NextQuest(int removeQuestId)
    {
        if (Continue)
        {
            if (Quests.Count <= 0) Continue = false;
            else
            {
                res_quests.Remove(removeQuestId);
                Quests.RemoveAt(removeQuestId);
            }
        }
        else
        {
            Debug.LogError("No QuestObject Found");
        }
    }
    public void CompleteCond(int QuestInd, int ConditionInd, bool SaveRemoved)
    {
        if (Continue) 
        { 
            try 
            {
                RemovedConditions[$"{QuestInd}:{ConditionInd}"] = Quests[QuestInd].conditions[ConditionInd];
                if (DebugCheck) Debug.Log($"Removed cond {ConditionInd}!");
                res_quests[QuestInd].res_conditions.Remove(ConditionInd);
                UpdateUI();
                if (res_quests[QuestInd].conditions.Count <= 1) NextQuest(QuestInd);
            }
            catch { if (DebugCheck) Debug.Log("Couldn't remove condition!"); }
            
        }
    }

    public void RestoreCond(int QuestInd, int ConditionInd)
    {
        if (Continue)
        {
            if (res_quests.ContainsKey(QuestInd))
            {
                res_quests[QuestInd].res_conditions[ConditionInd] = RemovedConditions[$"{QuestInd}:{ConditionInd}"];
                UpdateUI();
            }
        }
    }
    public void UpdateUI(int QuestInd = 0)
    {
        NameText.SetText(Quests[QuestInd].name);
        string cond = "";
        
        bool check = false;
        if (DebugCheck) Debug.Log($"Printing Conditions:{Quests[QuestInd].res_conditions.Count}!");
        for (int i = 0; i < Quests[QuestInd].retHighestInd(); i++) 
        {
            if (!Quests[QuestInd].res_conditions.ContainsKey(i))
            {
                if (DebugCheck) Debug.Log($"Missing Condition:{i}!");
                if (!check)
                {
                    clearedConditions = cond;
                    check = true;
                }
                cond += "<s>" + RemovedConditions[$"{QuestInd}:{i}"] + "</s>" + "\n";
            }
            else
            {
                if (DebugCheck) Debug.Log($"Found Condition:{i}!");
                if (check) clearedConditions += Quests[QuestInd].res_conditions[i] + "\n";
                cond += Quests[QuestInd].res_conditions[i] + "\n";
            }
        }
        if (check)
        {
            Fade = true;
            prev = Time.time;
        }
        QuestText.SetText(cond);
    }

    [System.Serializable]
    public class quest
    {
        public string name = "Unnamed";
        public string description = "probably nothing";
        public List<string> conditions;
        public Dictionary<int, string> res_conditions = new Dictionary<int, string>();
        private int highestInd = 0;
        public void setHighestInd()
        {
            highestInd = conditions.Count;
        }
        public int retHighestInd()
        {
            return highestInd;
        }
    }
    
}

