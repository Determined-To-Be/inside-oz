using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class PerlinSand : MonoBehaviour{

    public bool update = false;
    public float offset = 0;
    public float magnitude = 1;

    private bool calcPreview = false;


    Vector3[] originalVerts;

    MeshFilter filter;
    Mesh mesh;

    void Start(){
        filter = this.GetComponent<MeshFilter>();
        originalVerts = filter.sharedMesh.vertices;
    }

    void Update(){
        if(update == true){
            UpdateMesh();
        }
    }

    void UpdateMesh(){
        mesh = filter.mesh;
        Vector3[] verts = new Vector3[originalVerts.Length];
        
        for(int i = 0; i < verts.Length; i++){
            verts[i] = originalVerts[i] + magnitude * new Vector3(0,Mathf.PerlinNoise(transform.TransformPoint(originalVerts[i]).x + offset, transform.TransformPoint(originalVerts[i]).z + offset), 0);
        }

        mesh.vertices = verts;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        filter.mesh = mesh;
        //update = false;
    }
    
    Vector3[] verts;
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        
        if(calcPreview){
            verts = new Vector3[originalVerts.Length];
            for(int i = 0; i < verts.Length; i++){
                verts[i] = originalVerts[i] + magnitude * new Vector3(0,Mathf.PerlinNoise(transform.TransformPoint(originalVerts[i]).x + offset, transform.TransformPoint(originalVerts[i]).z + offset), 0);
            }

            calcPreview = false;
        }

        if(verts == null){
            return;
        }

        for(int i = 0; i < verts.Length; i++){
            Gizmos.DrawSphere(transform.TransformPoint(verts[i]), .1f);
        }        
    }
}
