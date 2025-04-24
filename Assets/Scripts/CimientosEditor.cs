using UnityEngine;

public class CimientosEditor : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        gameObject.AddComponent<MeshRenderer>();

        CrearCimientos();
    }

    void CrearCimientos()
    {
        // Definir vértices del cubo base
        vertices = new Vector3[]
        {
            new Vector3(-5, 0, -5), // 0
            new Vector3(5, 0, -5),  // 1
            new Vector3(5, 0, 5),   // 2
            new Vector3(-5, 0, 5),  // 3

            new Vector3(-5, 0.5f, -5), // 4 (arriba)
            new Vector3(5, 0.5f, -5),  // 5
            new Vector3(5, 0.5f, 5),   // 6
            new Vector3(-5, 0.5f, 5),  // 7
        };

        // Definir triángulos (caras)
        triangles = new int[]
        {
            0, 1, 2,  0, 2, 3,  // Base
            4, 5, 6,  4, 6, 7,  // Techo
            0, 1, 5,  0, 5, 4,  // Lado 1
            1, 2, 6,  1, 6, 5,  // Lado 2
            2, 3, 7,  2, 7, 6,  // Lado 3
            3, 0, 4,  3, 4, 7   // Lado 4
        };

        // Asignar la geometría a la malla
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    // Método para escalar los cimientos
    public void Escalar(float factor)
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] *= factor;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
