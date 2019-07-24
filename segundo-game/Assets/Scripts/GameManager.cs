using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public GameObject audioEffect_jump;
    public GameObject audioEffect_coin;

    int coins = 0;

    // Start is called before the first frame update
    void Start(){
        audioEffect_jump = GameObject.Find("JumpSound");
        audioEffect_coin = GameObject.Find("CoinSound");
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void sound_jump(){
        audioEffect_jump.GetComponent<AudioSource>().Play();
    }

    public void sound_coin(){
        audioEffect_coin.GetComponent<AudioSource>().Play();
    }

    public void addCoins(){
        coins++;
    }
}
