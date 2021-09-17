using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private bool followPlayer;
    [SerializeField] private PlayerController player = null;

    [SerializeField] private float cameraMove;

    private Vector3 viewPosition;

    [SerializeField] private float clampMin;
    [SerializeField] private float clampMax;


    private void Update()
    {
        FollowPlayer();
        DetectScreenBoundsOnPlayer();
    }
    
    private void FollowPlayer()
    {
        if (followPlayer)
        {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, clampMin, clampMax), transform.position.y, transform.position.z);
        }
    }

    private void DetectScreenBoundsOnPlayer()
    {
        viewPosition = Camera.main.WorldToViewportPoint(player.transform.position);

        //IZQUIERDA
        if (viewPosition.x < 0f)
        {
            MoveCamera(new Vector3(-cameraMove, 0f, 0f));
        }
        //DERECHA
        else if (viewPosition.x > 1.0f)
        {
            MoveCamera(new Vector3(cameraMove, 0f, 0f));
        }
    }

    public void MoveCamera(Vector3 newPosition)
    {
        transform.position += newPosition;
    }

}
