using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform Mace;
    public Rigidbody2D rb;
    public Vector2 velocidade;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
      
        if (Mace.position.y > -0.5){
            rb.velocity = -velocidade;
        }
        else if (Mace.position.y <= -6.5){
            rb.velocity = velocidade;
        }
    }
}
