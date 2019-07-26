using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour{

    public float velocity;

    GameManager gameManager;
    GameObject player;

    public int life = 100;
    public bool gameover = false;

    // Start is called before the first frame update
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){

        if(life <= 0 && !gameover){
            gameover = true;
            gameObject.GetComponent<Animator>().SetBool("Attack", false);
            gameObject.GetComponent<Animator>().SetBool("Die", true);
            gameManager.sound_zombieBoss();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameManager.Win();
        }

        if(Mathf.Abs( DistanceX() ) <= 0.7  && player.GetComponent<Transform>().position.y <= -4.0 && !gameover){
            gameManager.Set_bossZone(false);
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
            gameManager.sound_zombieBoss();
            gameover = true;
            gameManager.GameOver();
        }

        if (gameManager.Get_bossZone() && !gameover){
           if(DistanceX() > 0){
                Flip("left");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocity, 0);
                gameObject.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(velocity));
            }else{
                Flip("right");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0);
                gameObject.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(velocity));
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision){
    
        if (collision.CompareTag("GroundCheck")){
            gameManager.sound_zombieBoss();
            life -= 10;
        }
    }

    void Flip(string direction){
        if(direction == "left" && gameObject.transform.localScale.x == -1)
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        if (direction == "right" && gameObject.transform.localScale.x == 1)
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
    }

    float DistanceX(){ // Distância do player e monstro (Com Sinal) - X
        return (gameObject.transform.position.x - player.GetComponent<Transform>().position.x);
    }
    float DistanceY(){ // Distância do player e monstro (Com Sinal) - Y
        return (gameObject.transform.position.y - player.GetComponent<Transform>().position.y);
    }

}
