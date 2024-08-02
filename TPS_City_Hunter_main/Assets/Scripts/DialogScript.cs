using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript : MonoBehaviour
{
    public List<dialog> dialogs = new List<dialog>();
    public bool Multiple = false;
    public bool Repeatable = false;
    public DialogCore dialogCore;
    private bool Continue = true;

    void Start()
    {
        Check();
    }
    public void Check()
    {
        try { dialogCore = GameObject.FindGameObjectWithTag("EventCore").GetComponent<DialogCore>(); Continue = true; }
        catch { Continue = false; }
    }
    public void trigger()
    {
        if (Continue)
        {
            for (int i = 0; i < dialogs.Count; i++) 
            {
                dialogCore.ChangeDialog(dialogs[i].ID, dialogs[i].name, Multiple);
            }
            if (!Repeatable) Continue = false;
        }

    }
    [System.Serializable]
    public class dialog
    {
        public string name = "John Shooter";
        public int ID = -1;

    }
}
