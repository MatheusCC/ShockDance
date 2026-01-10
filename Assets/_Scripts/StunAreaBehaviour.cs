using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAreaBehaviour : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    private GameObject stunCanvas;
    [SerializeField]
    private Transform center;
    [SerializeField]
    private float stunEffectTime;

    public Transform Center { get { return center; } set { center = value; } }

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
                hitColliders[i].gameObject.GetComponent<PlayerMovement>().ActiveStunEffect(stunEffectTime);
                GameObject prefStunCanvas = Instantiate(stunCanvas, hitColliders[i].transform.position, stunCanvas.transform.rotation) as GameObject;
                Destroy(prefStunCanvas, 2f);
                break;
            }
        }
        Destroy(this.gameObject);
    }
}
