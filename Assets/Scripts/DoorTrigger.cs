using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] public Animator doorAnimator;
    private bool isPlayerNearby = false;
    private bool doorOpen = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!doorOpen)
            {
                doorAnimator.SetTrigger("Abrir");

            }
            else
            {
                doorAnimator.SetTrigger("Cerrar");

            }
            doorOpen = !doorOpen;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
