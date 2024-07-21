using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestScript : MonoBehaviour
{
    public string New_quest_name;
    public string New_quest_description;
    public UnityEvent Quest_event;
    void Start()
    {
        Quest_event.AddListener(GameObject.FindGameObjectWithTag("QuestCore").GetComponent<QuestCore>().NextQuest);
    }

}
