using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task1Control : MonoBehaviour
{
    public GameObject playerObject;
    private playerControl player;

    public GameObject pongball;
    private float ballCameraDistance = 1f;
    public float ballThrowingForce = 120f;

    int hits;

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
        Debug.Log("Task 1: Beerpong");
        yield return new WaitForSeconds(1);
        Debug.Log("Throw!");
        hits = 0;
        while (hits < 6)
        {
            Debug.Log("Try " + (hits + 1));
            yield return StartCoroutine("GameRound");
            yield return new WaitForSeconds(0.4f);
        }
        EndTask();
    }

    IEnumerator GameRound()
    {
        pongball.GetComponent<Rigidbody>().useGravity = false;
        pongball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pongball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //move ball to player and hold it there for some time
        for (int i = 0; i < 20; i++)
        {
            pongball.transform.position = playerObject.GetComponentInChildren<OVRCameraRig>().transform.position + (playerObject.transform.forward * ballCameraDistance);
            yield return null;
        }

        //wait till ball is thrown
        while (!Input.GetKey(KeyCode.B))
        {
            pongball.transform.position = playerObject.GetComponentInChildren<OVRCameraRig>().transform.position + (playerObject.transform.forward * ballCameraDistance);
            yield return null;
        }

        pongball.GetComponent<Rigidbody>().useGravity = true;
        pongball.GetComponent<Rigidbody>().AddForce(playerObject.transform.forward * ballThrowingForce);
        yield return new WaitForSeconds(0.8f);
        //Instantiate(pongball, playerObject.GetComponentInChildren<OVRCameraRig>().transform.position + (playerObject.transform.forward * ballCameraDistance), playerObject.transform.rotation);

        hits++;
    }
}
