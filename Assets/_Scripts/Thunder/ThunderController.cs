using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    private GameObject thunder;
    [SerializeField]
    private float thunderRate;

    public float ThunderRate { get => thunderRate; set => thunderRate = value; }

    /**variables*/
    private float currentTime;

    // Update is called once per frame
    void Update()
    {
        /**Control with a rate variable when the GameObject "thunder" should be Instantiate*/
        currentTime += Time.deltaTime;
        if (currentTime > thunderRate)
        {
            GameObject thunderPrefab = Instantiate(thunder, thunder.transform.position, thunder.transform.rotation) as GameObject;
            currentTime = 0;
        }
    }
}
