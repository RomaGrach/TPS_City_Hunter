using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public int QuestInd = -1;
    public int ConditionInd = -1;
    private QuestCore questCore;
    private bool Continue;
    void Start()
    {
        Check();
    }
    public void Check()
    {
        try { questCore = GameObject.FindGameObjectWithTag("QuestCore").GetComponent<QuestCore>(); Continue = true; }
        catch { Continue = false; }
    }

    public void _PickUp()
    {
        questCore.CompleteCond(QuestInd, ConditionInd);
    }
    private void OnDestroy()
    {
        _PickUp();
    }
}
