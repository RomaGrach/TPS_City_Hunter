using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    
    public int QuestInd = -1;
    public int ConditionInd = -1;
    public bool Repeatable = false;
    public float Cooldown = 5f;
    private float prev = -1f;
    public QuestCore questCore;
    private bool Continue = true;

    public bool DebugCheck = false;

    private void Update()
    {
        if (Repeatable && !Continue)
        {
            if (Time.time - prev > Cooldown)
            {
                questCore.RestoreCond(QuestInd, ConditionInd);
                Continue = true;
            }
                
        }
    }
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
            if (DebugCheck) Debug.Log("Triggered Condition!");
            questCore.CompleteCond(QuestInd, ConditionInd, Repeatable);
            Continue = false;
            if (Repeatable) prev = Time.time;
        }
        
    }
    
}
