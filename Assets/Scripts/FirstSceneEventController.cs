using UnityEngine;

public class FirstSceneEventController : MonoBehaviour
{

    public DialogueTrigger alanDialogue;
    public DialogueTrigger johnDialogue;

    public bool talkedToJohn;
    public bool talkedToAlan;
    public bool talkedToTerrence;

    private void Update()
    {
       
    }

    public void UnlockNewDialogue(DialogueTrigger dialogueTrigger, int endAtLine)
    {
        dialogueTrigger.endAtLine = endAtLine;
    }

}
