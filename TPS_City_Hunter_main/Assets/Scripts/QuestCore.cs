using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestCore : MonoBehaviour
{
    public int score;
    private GameObject QuestObject;
    private bool Continue;
    void Start()
    {
        Check();
    }

    public void Check()
    {
        QuestObject = GameObject.FindGameObjectWithTag("QuestCore");
        if (QuestObject != null) Continue = true;
        else Continue = false;
    }

    public void NextQuest()
    {
        if (Continue)
        {
            score = 0;
        }
        else
        {
            Debug.LogError("No QuestObject Found");
        }
    }
}
