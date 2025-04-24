using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private Light pointLight; // Asigna la luz en el Inspector
    [SerializeField] private KeyCode switchKey = KeyCode.E; // Tecla para activar

    private bool isInRange = false;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(switchKey))
        {
            pointLight.enabled = !pointLight.enabled; // Cambia el estado de la luz
        }
    }

    // Detectar si el jugador está cerca
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
