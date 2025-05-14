using UnityEngine;

public class JellyfishMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float changeDirectionTime = 3f;

    private Vector3 randomDirection;
    private float timer;

    void Start()
    {
        ChooseRandomDirection();
    }

    void Update()
    {
        transform.Translate(randomDirection * speed * Time.deltaTime, Space.World);

        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChooseRandomDirection();
            timer = 0f;
        }
    }

    void ChooseRandomDirection()
    {
        randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-0.5f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ContadorVidas vidas = FindObjectOfType<ContadorVidas>();
            if (vidas != null)
            {
                vidas.PerderVida();
            }
        }
    }
}
