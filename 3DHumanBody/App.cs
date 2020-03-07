
Combine Meshes 2.0
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public Mesh Mesh1;
    public Mesh Mesh2;
    public Mesh Mesh3;
    public Mesh Mesh4;
    public Mesh Mesh5;
    public Mesh Mesh6;
    public Mesh Mesh7;
    public Mesh Mesh8;
    public Mesh Mesh9;
    public Mesh Mesh10;
    public Mesh Mesh11;
    public Mesh Mesh12;
    public Mesh Mesh13;
    public Mesh Mesh14;


    private void Start()
    {
        //neues Feld
        var mesh = CombineMeshes(new List<Mesh> { Mesh1, Mesh2, Mesh3, Mesh4, Mesh5, Mesh6, Mesh7, Mesh8, Mesh9, Mesh10, Mesh11, Mesh12, Mesh13,Mesh14 });
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private Mesh CombineMeshes(List<Mesh> meshes)
    {
        //fügt alle Meshes in ein Feld
        var combine = new CombineInstance[meshes.Count];
        for (int i = 0; i < meshes.Count; i++)
        {
            combine[i].mesh = meshes[i];
            combine[i].transform = transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combine);
        return mesh;
    }
	}
