using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class DynamicQuadricSurface : MonoBehaviour
{
    public float A = 1f;
    public float B = 1f;
    public float C = 1f;
    public float D = 0f;
    public float E = 0f;
    public float F = 0f;
    public float G = 0f;
    public float H = 0f;
    public float I = 0f;
    public float J = 0f;

    public int resolution = 15; 
    public float size = 5f;    

    private Mesh mesh;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        StartCoroutine(UpdateSurface());
    }

    private IEnumerator UpdateSurface()
    {
        while (true)
        {
            GenerateQuadricSurface();
            yield return new WaitForSeconds(1f); 
        }
    }

   private void GenerateQuadricSurface()
    {
        int vertexCount = resolution * resolution;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];

        float step = size / (resolution - 1);
        int triIndex = 0;

        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                float x = -size / 2 + i * step;
                float y = -size / 2 + j * step;

                // Вычисляем Z из уравнения второго порядка:
                float z = (-A * x * x - B * y * y - D * x * y - G * x - H * y - J) / (C + E * x + F * y + 0.001f); // избегаем деления на 0

                vertices[i * resolution + j] = new Vector3(x, z, y);

                if (i < resolution - 1 && j < resolution - 1)
                {
                    int a = i * resolution + j;
                    int b = i * resolution + j + 1;
                    int c = (i + 1) * resolution + j;
                    int d = (i + 1) * resolution + j + 1;

                    triangles[triIndex++] = a;
                    triangles[triIndex++] = c;
                    triangles[triIndex++] = b;
                    triangles[triIndex++] = b;
                    triangles[triIndex++] = c;
                    triangles[triIndex++] = d;
                }
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
