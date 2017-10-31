using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainControl : MonoBehaviour
{
    public GameObject playerObject;
    private playerControl player;

    //private int tasksFinished;
    public int tasksToFinish = 5;

    void Start()
    {
        StartCoroutine("MainRoutine");
        player = playerObject.GetComponent<playerControl>();
    }

    IEnumerator MainRoutine()
    {
        Debug.Log("Main Controller Started");
        yield return new WaitForSeconds(1);
        yield return StartCoroutine("Welcome");
        yield return StartCoroutine("Tutorial");
        yield return StartCoroutine("Tasks");
        yield return StartCoroutine("Leave");
        Debug.Log("End scene");
    }

    IEnumerator Welcome()
    {
        Debug.Log("Welcome Start");
        yield return new WaitForSeconds(1.2f);
        Debug.Log("Welcome end");
    }

    IEnumerator Tutorial()
    {
        Debug.Log("Tutorial Start");
        //start 'tutorial' section
        player.canDoTutorial = true;
        //wait till player has finished the tutorial
        while (player.canDoTutorial)
        {
            yield return null;
        }
        Debug.Log("Tutorial End");
    }

    IEnumerator Tasks()
    {
        Debug.Log("Task Start");
        //start 'task' section
        player.canDoTasks = true;
        player.tasksFinished = 0;
        //wait till player has finished some tasks
        while (player.tasksFinished < tasksToFinish)
        {
            yield return null;
        }
        //stop 'task' section
        player.canDoTasks = false;
        Debug.Log("Task End");
    }

    IEnumerator Leave()
    {
        Debug.Log("Leave Start");
        //start 'leave' section
        player.canDoLeave = true;
        //wait till player has left
        while (player.canDoLeave)
        {
            yield return null;
        }
        Debug.Log("Leave End");
    }
}
