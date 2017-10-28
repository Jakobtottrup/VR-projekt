using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    //public float speed;
    //private Rigidbody rb;

    //to toggle by controllers
    public bool tutorialInProgress = false;
    [HideInInspector] public bool tasksInProgress = false;
    [HideInInspector] public bool leaveInProgress = false;
    [HideInInspector] public bool lookingForTask = true;
    [HideInInspector] public int tasksFinished;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    /*void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);

        rb.AddForce(movement * speed);
    }*/
}
