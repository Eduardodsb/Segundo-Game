using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour{

    GameManager gameManager;

    // Start is called before the first frame update
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")) {
            gameManager.sound_coin();
            gameObject.SetActive(false);
            gameManager.addCoins();
        }
    }

}
