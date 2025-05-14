using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ReproducirVideoGameOver : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }

    void Update()
    {
        // Detectar tecla Espacio o clic para saltar el video
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            SaltarVideo();
        }
    }

    void EndReached(VideoPlayer vp)
    {
        CargarEscena();
    }

    void SaltarVideo()
    {
        videoPlayer.Stop();
        CargarEscena();
    }

    void CargarEscena()
    {
        SceneManager.LoadScene("SampleScene"); // Cambia por tu escena
    }
}
