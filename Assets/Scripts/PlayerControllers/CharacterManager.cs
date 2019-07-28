using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public int curr = 0;

    public int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        health = PlayerPrefs.GetInt("maxHP");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = characters[curr].transform.position;
    }

    void Switch(){
        characters[curr].SetActive(false);
        curr = (curr+1) % characters.Length;
        
        characters[curr].transform.position = this.transform.position;
        characters[curr].SetActive(true);
    }

    void TakeDamage(int amount){
        
    }
}
