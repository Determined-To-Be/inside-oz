using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;

    Transform[] screenPositions;
    int currScreen = 0;

    void Start(){
        instance = this.GetComponent<CameraController>();
    }


    public void NextScreen(){
        currScreen++;
        this.transform.position = screenPositions[currScreen].position;
    }

    public void PreviousScreen(){
        currScreen--;
        this.transform.position = screenPositions[currScreen].position;
    }

}
