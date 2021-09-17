using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueText[] dialogueText;

    public bool waitForPress;
 
    public bool isDialogueOn;

    public int currentLine;
    public int endAtLine;
    public int minIndex;

    public bool isLooping;

    private void Start()
    {
        endAtLine = dialogueText.Length;
        minIndex = 0;
    }

    private void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.E))
        {     
            ActivateDialogue();
        }

        if (isDialogueOn && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    public void ActivateDialogue()
    {
        isDialogueOn = true;
        dialogueText[currentLine].gameObject.SetActive(true);
    }

    public void NextLine()
    {
        if (dialogueText[currentLine].isLoop)
        {
            minIndex = currentLine;
            endAtLine = minIndex;
            isLooping = true;
        }
        else
        {
            endAtLine = dialogueText.Length;
            isLooping = false;
        }       
        
        dialogueText[currentLine].gameObject.SetActive(false);
        
        currentLine += 1;

        if (currentLine >= endAtLine)
        {
            currentLine = minIndex;
            isDialogueOn = false;
            dialogueText[currentLine].gameObject.SetActive(false);
            return;
        }
        else
        {
            dialogueText[currentLine].gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            waitForPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            waitForPress = false;
        }
    }
}
