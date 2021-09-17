using UnityEngine;
using System.Collections;
using TMPro;

public class DialogueText : MonoBehaviour
{
    private TextMeshPro text;
    private FirstSceneEventController dialogueController;

   

    public string line;

    public bool isLoop;

    public bool unlocksDialogue;
 
    public DialogueTrigger dialogueTrigger;
    
    private void Awake()
    {

        text = GetComponent<TextMeshPro>();
        dialogueController = FindObjectOfType<FirstSceneEventController>();
    }

    private void Start()
    {
        WriteText();
    }
 
    public void WriteText()
    {
        text.text = line;
    }

    private void OnDisable()
    {
        if (unlocksDialogue && dialogueTrigger.isLooping)
        {
            UnlockNewDialogue(dialogueTrigger);
        }
    }

    public void UnlockNewDialogue(DialogueTrigger dialogueTrigger)
    {
        dialogueTrigger.isLooping = false;
        dialogueTrigger.currentLine += 1;
        dialogueTrigger.minIndex += 1;
    }
}
