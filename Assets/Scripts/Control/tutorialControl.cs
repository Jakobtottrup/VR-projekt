using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialControl : MonoBehaviour
{
    public GameObject playerObject;
    private playerControl player;

    private bool tutorialInProgress;

    void Start()
    {
        player = playerObject.GetComponent<playerControl>();
        tutorialInProgress = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (player.canDoTutorial && !tutorialInProgress)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                tutorialInProgress = true;
                StartCoroutine("BeginTutorial");
            }
        }
    }

    IEnumerator BeginTutorial()
    {
        Debug.Log("Tutorial has begun");
        yield return new WaitForSeconds(4);
        Debug.Log("Tutorial has ended");
        player.canDoTutorial = false;
    }
}
