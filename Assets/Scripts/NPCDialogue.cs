using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isInteracting;

    private void Start()
    {
        isInteracting = false;
    }

    public void Update()
    {
        if (isInteracting == true)
        {
            isInteracting = false;
            TriggerDialogue();
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        
    }
}
