using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PerlinSand))]
public class PerlinSandEditor : Editor{

    void OnEnable()
    {
    }

    void OnInspectorGUI(){
        if(GUILayout.Button("Update")){

        }
    }
}


public class PerlinSand : MonoBehaviour{

    void UpdateMesh(){

    }
}
