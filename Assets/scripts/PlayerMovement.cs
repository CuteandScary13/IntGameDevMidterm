﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    CharacterController cController;
    float jumpTimer;
    public float jumpDist = 5f;

    // Use this for initialization
    void Start()
    {
        cController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");


        cController.SimpleMove(transform.forward * inputY * 5f);
        cController.SimpleMove(transform.right * inputX * 5f);

        transform.Rotate(0f, mouseX * 5f, 0f);
      

       
        

        if (this.transform.position.y < -5)
        {
            SceneManager.LoadScene(0);
        }
    }
    
}
