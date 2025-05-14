using UnityEngine;

public class MostrarInstruccion : MonoBehaviour
{
    [SerializeField] private GameObject canvasInstruccion; // Asigna el Canvas desde el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasInstruccion.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasInstruccion.SetActive(false);
        }
    }
}
