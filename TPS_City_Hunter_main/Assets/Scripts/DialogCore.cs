using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogCore : MonoBehaviour
{

    private bool Continue = true;
    public shownDialog[] Characters;
    private Dictionary<string, dialog[]> characters;

    void Start()
    {
        for (int i = 0; i < Characters.Length; i++) characters[Characters[i].name] = Characters[i].dialogs;
    }
    public void ChangeDialog(int DialogId, string name)
    {
        if (Continue)
        {
            string text = characters[name][DialogId].text;
        }
        else
        {
            Debug.LogError("No QuestObject Found");
        }
    }
    [System.Serializable]
    public class shownDialog
    {
        public string name;
        public dialog[] dialogs;
    }
    [System.Serializable]
    public class dialog
    {
        public string name = "Unnamed";
        public string text = "probably nothing";
        public AudioSource voiceLine;
    }
}


