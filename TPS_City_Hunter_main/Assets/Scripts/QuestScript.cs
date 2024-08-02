using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    
    public int QuestInd = -1;
    public int ConditionInd = -1;
    public QuestCore questCore;
    private bool Continue = true;
    
    void Start()
    {
        Check();
    }
    public void Check()
    {
        try { questCore = GameObject.FindGameObjectWithTag("EventCore").GetComponent<QuestCore>(); Continue = true; }
        catch { Continue = false; }
    }
    public void trigger()
    {
        if (Continue) 
        {
            Debug.Log("Triggered Condition!");
            questCore.CompleteCond(QuestInd, ConditionInd);
            Continue = false;
        }
        
    }
    
}
