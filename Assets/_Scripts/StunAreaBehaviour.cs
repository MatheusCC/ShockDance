using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAreaBehaviour : MonoBehaviour {

    // Use this for initialization

    /**Public variables*/
    public GameObject stunCanvas;

    public Transform center;

    public float StunEffectTime;

    void Start () {
        StunEffect();
    }
    /** Creates a Physics sphere and save all colliders hitten by the sphere in a Array
    runs throw the array, looking for the player, if YES call the function "StunEffectTime" located in the "PlayerMovement" script,
    creates a canvas wiht a message*/
    void StunEffect()
    {
    
       Collider[] hitColliders = Physics.OverlapSphere(center.position, 1.8f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if(hitColliders[i].gameObject.tag == "Player")
            {
                hitColliders[i].gameObject.GetComponent<PlayerMovement>().ActiveStunEffect(StunEffectTime);
                GameObject prefStunCanvas = Instantiate(stunCanvas, hitColliders[i].transform.position, stunCanvas.transform.rotation) as GameObject;
                Destroy(prefStunCanvas, 2f);
                break;
            }
        }
        Destroy(this.gameObject);
    }
}
