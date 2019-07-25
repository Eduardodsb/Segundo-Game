using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform Mace;
    public Rigidbody2D rb;
    public Vector2 velocidade;
    public float MaxHeight;
    public float MinHeight;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update(){
      
        if (Mace.position.y > MaxHeight)
        {
            rb.velocity = -velocidade;
        }
        else if (Mace.position.y <= MinHeight)
        {
            rb.velocity = velocidade;
        }
    }
}
