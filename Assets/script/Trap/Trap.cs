using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject playerPrefab; // Drag and drop the player prefab here
    public GameObject respawnPoint; // Drag and drop the respawn point here
    public float respawnDelay = 2f; // delay time in seconds

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Debug.Log("Player is dead");

            // Spawn a new player at the respawn point after a delay of "respawnDelay" seconds
            Invoke("SpawnPlayer", respawnDelay);
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, respawnPoint.transform.position, Quaternion.identity);
    }

}
