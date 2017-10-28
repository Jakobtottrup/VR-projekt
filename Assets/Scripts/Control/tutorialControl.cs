using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialControl : MonoBehaviour
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
            if (player.tutorialInProgress)
            {
                player.tutorialInProgress = false;
            }
        }
    }
}
