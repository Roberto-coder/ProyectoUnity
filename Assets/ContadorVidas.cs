using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ContadorVidas : MonoBehaviour
{
    [SerializeField] private int vidas = 3; // Variable para almacenar el número de vidas
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject liveImage;

    private List<GameObject> RealLives ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RealLives = new List<GameObject>();
        for (int i = 0; i < vidas; i++)
        {
            RealLives.Add(Instantiate(liveImage, container.transform));
            RealLives[^1].transform.Translate(new Vector3(72*i+15,10));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
