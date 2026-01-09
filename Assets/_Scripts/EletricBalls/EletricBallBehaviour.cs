using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricBallBehaviour : MonoBehaviour {

    // Use this for initialization

    /**Public variables*/
    public Transform spawnShock;
    public GameObject shock;

    /**Creates a shock prefab using the spawn shock position*/
    public void InstantiateShock()
    {
        GameObject prefabShock = Instantiate(shock, spawnShock.position, spawnShock.rotation) as GameObject;
    }
}
