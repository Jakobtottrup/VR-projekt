﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task2Control : MonoBehaviour
{
    public GameObject playerObject;
    private playerControl player;

    void Start()
    {
        player = playerObject.GetComponent<playerControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.canDoTasks && player.lookingForTask)
            {
                player.lookingForTask = false;
                StartCoroutine("BeginTask");
            }
        }
    }

    void EndTask()
    {
        player.tasksFinished++;
        player.lookingForTask = true;
        Debug.Log(player.tasksFinished);
    }

    IEnumerator BeginTask()
    {
        Debug.Log("Task 2 begun");
        yield return new WaitForSeconds(4);
        EndTask();
    }
}
