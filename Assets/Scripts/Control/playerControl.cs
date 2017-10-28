using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float drunkness;

    //to toggle by controllers
    [HideInInspector] public bool canDoTutorial = false;
    [HideInInspector] public bool canDoTasks = false;
    [HideInInspector] public bool canDoLeave = false;
    [HideInInspector] public bool lookingForTask = true;
    [HideInInspector] public int tasksFinished;

    void Start()
    {
        drunkness = 0;
    }

    void Update()
    {

    }

    public void AddDrunk(float drink)
    {
        drunkness += drink;
    }
}
