using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricBallBehaviour : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    private Transform spawnShock;
    [SerializeField]
    private GameObject shock;

    public GameObject Shock { get { return shock; } set { shock = value; } }

    /**Creates a shock prefab using the spawn shock position*/
    public void InstantiateShock()
    {
        GameObject prefabShock = Instantiate(shock, spawnShock.position, spawnShock.rotation) as GameObject;
    }
}
