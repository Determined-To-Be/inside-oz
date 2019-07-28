using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransition : MonoBehaviour
{

    public bool next, prev;

    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "Player"){
            if(next)
                CameraController.instance.NextScreen();
            if(prev)
                CameraController.instance.PreviousScreen();
        }
    }

}
