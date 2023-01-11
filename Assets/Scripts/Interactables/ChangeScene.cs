using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : Interactable
{
    [SerializeField]
    private int sceneNumber;
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);

        SceneManager.LoadScene(sceneNumber);

    }
}
