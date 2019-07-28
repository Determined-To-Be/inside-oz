using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PerlinSand : MonoBehaviour{
 
    public bool update = false;

    void Start(){
        
    }

    void Update(){
        if(update == true){
            UpdateMesh();
        }
    }

    void UpdateMesh(){

    }
}
