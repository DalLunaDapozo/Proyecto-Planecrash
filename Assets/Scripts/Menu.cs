using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OnStartGameSelected()
    {
        SceneController.LoadScene(1,1,.5f);
    }

    public void OnPressExit()
    {
        Application.Quit();
    }

}
