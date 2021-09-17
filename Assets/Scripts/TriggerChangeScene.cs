using UnityEngine;

public class TriggerChangeScene : MonoBehaviour
{
    private BoxCollider2D boxCollider = null;

    [SerializeField] private int changeToScene;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneController.LoadScene(changeToScene,1,2);
        }
    }
}
