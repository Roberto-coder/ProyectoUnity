using UnityEngine;

public class JellyfishMovement : MonoBehaviour
{
    public float speed = 0.5f;           // Velocidad lenta
    public float changeDirectionTime = 3f; // Tiempo entre cambios de dirección

    private Vector3 randomDirection;
    private float timer;

    void Start()
    {
        ChooseRandomDirection();
    }

    void Update()
    {
        // Mover en la dirección aleatoria
        transform.Translate(randomDirection * speed * Time.deltaTime, Space.World);

        // Contar tiempo para cambiar de dirección
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChooseRandomDirection();
            timer = 0f;
        }
    }

    void ChooseRandomDirection()
    {
        // Elegir un vector aleatorio
        randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-0.5f, 1f), // un poco más hacia arriba
            Random.Range(-1f, 1f)
        ).normalized; // Normaliza para que siempre sea una dirección válida
    }
}
