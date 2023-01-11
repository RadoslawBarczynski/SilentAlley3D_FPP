using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Note", menuName = "Inventory/Note")]
public class NoteValue : Item
{
    [SerializeField]
    private string texto;
    public static bool isNoteActive = false;
    
    

    public string NoteDisplay()
    {
        string path = "E:/UnityProjekty/SilentAlley/Assets/Scripts/Items/Notes" + texto;

        string newNote = File.ReadAllText(path);
        isNoteActive = true;
        return newNote;
        //NoteTMP.text = newNote;
    }

    public void NoteHide()
    {
        isNoteActive = false;
    }



}
