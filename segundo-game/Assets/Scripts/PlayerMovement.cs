using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    public Rigidbody2D rb;
    GameManager gameManager;

    bool  collision = false;
    float horizontalMove = 0;
  
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")){
            gameManager.sound_jump();
            jump = true;
        }

        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        }else if(Input.GetButtonUp("Crouch")){
            crouch = false;
        }

        if (rb.position.y < -9.0){
            gameManager.GameOver();
        }

    }
    
    void FixedUpdate(){
        if (rb.velocity.y > 0.0 && !collision){
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
        }

        if (rb.velocity.y < 0.0 && !collision){
            animator.SetBool("Down", true);
            animator.SetBool("Up", false);
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.collider.tag == "Ground"){
            this.collision = true;
            animator.SetBool("Down", false);
            animator.SetBool("Up", false);
        }

        if (collision.collider.tag == "Enemy"){
            gameManager.GameOver();
        }

    }

    private void OnCollisionExit2D(Collision2D collision){
        if (collision.collider.tag == "Ground"){
            this.collision = false;
        }

    }


    private void OnTriggerStay2D(Collider2D collision){
        if (Input.GetKey("e")){
            GameObject.Find("Chest").GetComponent<Animator>().enabled = true;
            GameObject.Find("Chest").GetComponent<Animator>().Play("Chest");
            gameManager.sound_chest();

            gameManager.CheckpointSave(gameObject.GetComponent<Transform>().position);
        }
    }

}
