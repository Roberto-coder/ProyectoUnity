using UnityEngine;

public class VentanaTrigger : MonoBehaviour
{
    [SerializeField] public Animator ventanaAnimator;
    private bool isPlayerNearby = false;
    private bool ventanaOpen = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (!ventanaOpen)
            {
                ventanaAnimator.SetTrigger("Abrir");

            }
            else
            {
                ventanaAnimator.SetTrigger("Cerrar");
                
            }
            ventanaOpen = !ventanaOpen;
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
