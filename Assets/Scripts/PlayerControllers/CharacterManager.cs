using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public int curr = 0;

    public int health = 1;

    public bool switchChars = false;

    // Start is called before the first frame update
    void Start()
    {
        health = PlayerPrefs.GetInt("maxHP");
        HUDController.instance.setHP(health);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = characters[curr].transform.position;

        if(switchChars){
            Switch();
            switchChars = false;
        }

        if(health <= 0){
            Die();
        }
    }

    void Switch(){
        characters[curr].SetActive(false);
        curr = (curr+1) % characters.Length;
        
        characters[curr].transform.position = this.transform.position;
        characters[curr].SetActive(true);
    }
    
    void Die(){
        // Activate GAmeover
    }

    bool isInvincible = false;

    public void invincibility(float duration){
        isInvincible = true;
    }

    IEnumerator invincibilityTimer(float duration){
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }

    public void TakeDamage(int amount){
        if(isInvincible){
            return;
        }

        health -= amount;
        HUDController.instance.setHP(health);
        invincibility(1);
    }
}
