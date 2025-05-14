using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ContadorVidas : MonoBehaviour
{
    [SerializeField] private int vidas = 3;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject liveImage;

    private List<GameObject> RealLives;

    void Start()
    {
        RealLives = new List<GameObject>();
        for (int i = 0; i < vidas; i++)
        {
            RealLives.Add(Instantiate(liveImage, container.transform));
            RealLives[^1].transform.Translate(new Vector3(72 * i + 15, 10));
        }
    }

    public void PerderVida()
    {
        if (vidas <= 0) return;

        vidas--;
        Destroy(RealLives[^1]);
        RealLives.RemoveAt(RealLives.Count - 1);

        if (vidas == 0)
        {
            Debug.Log("¡Game Over!");
            SceneManager.LoadScene("GameOver");
        }
    }
}
