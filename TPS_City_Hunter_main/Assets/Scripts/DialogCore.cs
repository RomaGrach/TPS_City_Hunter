using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogCore : MonoBehaviour
{

    private bool Continue = false;
    public GameObject Canvas;
    private TMP_Text Text;
    public shownDialog[] Characters;
    private Dictionary<string, dialog[]> characters = new Dictionary<string, dialog[]>();
    public bool DebugCheck = false;
    private float fadeTime = 10f;
    private float prev = -1f;
    public List<dialogNamed> dialogLine = new List<dialogNamed>();

    private void Update()
    {
        if (Continue) 
        { 
            if (Time.time - prev > fadeTime)
            {
                Canvas.SetActive(false);
                dialogLine.RemoveAt(0);
                if (dialogLine.Count > 0) ShowDialog();
                else Continue = false;
            }
        }
    }
    void Start()
    {
        for (int i = 0; i < Characters.Length; i++) 
        {
            characters[Characters[i].name] = Characters[i].dialogs;
        }
        try { Text = Canvas.GetComponentInChildren<TMP_Text>(); }
        catch { }
    }
    public void ChangeDialog(int DialogId, string name)
    {
        dialogLine.Add(new dialogNamed(name, characters[name][DialogId].text, characters[name][DialogId].voiceLine));
        if (!Continue) ShowDialog();
    }
    private void ShowDialog()
    {
        if (dialogLine[0].voiceLine != null) 
        {
            AudioClip clip = dialogLine[0].voiceLine.clip;
            if (clip != null) fadeTime = clip.length;
            else fadeTime = 5f;
        }
        else fadeTime = 5f;
        string text = dialogLine[0].text;
        string name = dialogLine[0].name;
        if (DebugCheck) Debug.Log($"{name}: {text}");
        Text.SetText(name + ": " + text);
        Canvas.SetActive(true);
        prev = Time.time;
        Continue = true;
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
        public string text = "probably nothing";
        public AudioSource voiceLine;
        
    }
    public class dialogNamed : dialog
    {
        public string name;
        public dialogNamed(string name, string text, AudioSource voiceline)
        {
            this.name = name;
            this.text = text;
            this.voiceLine = voiceline;
        }
    }
}


