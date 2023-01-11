using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ReadNote : Interactable
{
    //public Item item;
    public NoteValue value;
    public GameObject PageBackground;
    public TextMeshProUGUI NoteTMP;
    protected override void Interact()
    {
        if (NoteValue.isNoteActive == false)
        {
        Debug.Log("Interacted with " + value.name);
        PageBackground.SetActive(!PageBackground.activeSelf);
        UpdateNoteTMP(value.NoteDisplay());
        value.NoteDisplay();
        }
        else if(NoteValue.isNoteActive == true)
        {
            value.NoteHide();
            PageBackground.SetActive(!PageBackground.activeSelf);
        }
    }

    public void UpdateNoteTMP(string newNotes)
    {
        NoteTMP.text = newNotes;
    }

}
