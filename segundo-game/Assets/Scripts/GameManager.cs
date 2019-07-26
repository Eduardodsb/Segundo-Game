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
    GameObject audioEffect_chest;
    GameObject audioEffect_boss;
    GameObject player;
    GameObject ZombieBoss;


    int coins = 0;
    bool gameover = false;
    bool checkpoint = false;
    Vector2 checkpoint_position;

    // Start is called before the first frame update
    void Start(){
        audioEffect_jump = GameObject.Find("JumpSound");
        audioEffect_coin = GameObject.Find("CoinSound");
        audioEffect_gameover = GameObject.Find("GameOverSound");
        audioEffect_background = GameObject.Find("BackgroundSound");
        audioEffect_chest = GameObject.Find("ChestSound");
        audioEffect_boss = GameObject.Find("BossSound");
        player = GameObject.Find("Player");
        ZombieBoss = GameObject.Find("ZombieBoss");
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

    public void sound_chest(){
        audioEffect_chest.GetComponent<AudioSource>().Play();
    }

    public void sound_boss(){
        audioEffect_background.GetComponent<AudioSource>().Stop();
        audioEffect_boss.GetComponent<AudioSource>().Play();
    }

    public void GameOver(){
        if (gameover == false) {
            gameover = true;
            Debug.Log("GameOver");
            player.GetComponent<Animator>().SetBool("GameOver", true);
            audioEffect_background.GetComponent<AudioSource>().Stop();
            audioEffect_boss.GetComponent<AudioSource>().Stop();
            audioEffect_gameover.GetComponent<AudioSource>().Play();
            player.GetComponent<CircleCollider2D>().enabled = false;
            if (checkpoint){
                Invoke("Restart_Checkpoint", restartdelay);
            }else{
                Invoke("Restart", restartdelay);
            }
        }
    }

    public void AddCoins(){
        coins++;
    }

    void Restart(){
        Debug.Log("Restar");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public void CheckpointSave(Vector2 position){
        checkpoint = true;
        checkpoint_position = position;
    }

   void Restart_Checkpoint(){
        Debug.Log("Restar_CheckPoint");
        gameover = false;
        FindObjectOfType<GrassMovement>().Set_bossSound(false);
        player.GetComponent<Animator>().SetBool("GameOver", false);
        player.GetComponent<CircleCollider2D>().enabled = true;
        audioEffect_background.GetComponent<AudioSource>().Play();
        player.GetComponent<Transform>().position = checkpoint_position;

        //Restart ZombieBoss

    }

}
