using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public float restartdelay = 3f;

    GameObject audioEffect_jump;
    GameObject audioEffect_coin;
    GameObject audioEffect_gameover;
    GameObject audioEffect_background;

    int coins = 0;
    bool gameover = false;


    // Start is called before the first frame update
    void Start(){
        audioEffect_jump = GameObject.Find("JumpSound");
        audioEffect_coin = GameObject.Find("CoinSound");
        audioEffect_gameover = GameObject.Find("GameOverSound");
        audioEffect_background = GameObject.Find("BackgroundSound");
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
    public void gameOver(){
        if (gameover == false){
            gameover = true;
            Debug.Log("GameOver");
            audioEffect_background.GetComponent<AudioSource>().Stop();
            audioEffect_gameover.GetComponent<AudioSource>().Play();
            Invoke("Restart", restartdelay);
        }
    }

    public void addCoins(){
        coins++;
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
