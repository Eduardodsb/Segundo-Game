using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

    public Transform trans;
   public GameObject player;
   Vector3 positionCam;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        positionCam.x = player.GetComponent<Transform>().position.x;
        positionCam.y = transform.position.y;
        positionCam.z = -10;
        trans.position = positionCam;
    }
}
