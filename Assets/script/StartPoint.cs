using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public GameObject playerPrefab; // Drag and drop the player prefab here

    void Start()
    {
        GameObject player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
