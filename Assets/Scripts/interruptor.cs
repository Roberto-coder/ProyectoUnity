using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private Light[] pointLights;
    [SerializeField] private KeyCode switchKey = KeyCode.E;
    [SerializeField] private AudioSource switchSound; // ← Referencia al AudioSource

    private bool isInRange = false;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(switchKey))
        {
            ToggleLights();
        }
    }

    private void ToggleLights()
    {
        foreach (Light light in pointLights)
        {
            if (light != null)
            {
                light.enabled = !light.enabled;
            }
        }

        // Reproducir el sonido
        if (switchSound != null)
        {
            switchSound.Play();
        }
    }

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
