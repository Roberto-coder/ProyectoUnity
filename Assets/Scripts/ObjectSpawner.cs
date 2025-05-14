using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // El prefab a instanciar
    public Transform spawnPoint;     // El punto donde aparecerá el objeto
    public KeyCode spawnKey = KeyCode.R; // Tecla para instanciar
    public float launchForce = 5f;  // Fuerza con la que se lanzará el objeto

    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            // Instanciamos el objeto
            GameObject newObj = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Obtenemos su Rigidbody y aplicamos fuerza hacia adelante
            Rigidbody rb = newObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(spawnPoint.forward * launchForce, ForceMode.Impulse);
            }
        }
    }
}
