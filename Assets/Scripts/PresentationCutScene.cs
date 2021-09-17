using UnityEngine;
using System.Collections;
using TMPro;

public class PresentationCutScene : MonoBehaviour
{
 
    [SerializeField] private string text;

    [SerializeField] private TextMeshProUGUI textholder;
    [SerializeField] private float delay;
 

    void Start()
    {
        StartCoroutine(WriteText(text, textholder, delay));
    }

    private IEnumerator WriteText(string input, TextMeshProUGUI textholder, float delay)
    {

        for (int i = 0; i < input.Length; i++)
        {
            textholder.text += input[i];
            yield return new WaitForSeconds(delay);
        }

        SceneController.LoadScene(2,1,2);
    }
}
