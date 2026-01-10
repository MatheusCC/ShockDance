using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBehaviour : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    private GameObject thunderVFX;
    [SerializeField]
    private GameObject thunderAreaTargetVFX;
    [SerializeField]
    private GameObject stunArea;
    [SerializeField]
    private float thunderTimer;
    [SerializeField]
    private float stunAreaTimer;

    /**variables to control the thunder behaviour*/
    bool activateAreaTarget;
    bool activateThunder;
    bool activateStun;

    /**References*/
    Transform player;
    Transform thunderPosition;
    CameraShake cameraRef;

    void Start()
    {       
        activateAreaTarget = true;
        activateThunder = false;
        activateStun = false;

        //Finds player current position
        player = GameObject.FindGameObjectWithTag("Player").transform;

        cameraRef = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        /**Thunder is separated in 3 parts and it as order to it behaviour, 
        first - area target
        second - thunder effect
        third - stun effect*/

        /**First behaviour*/
        #region
        if (activateAreaTarget)
        {
            CreateThunderAreaTarget();
        }
        #endregion

        /**Second behaviour*/
        #region
        if (activateThunder)
        {
            thunderTimer -= Time.deltaTime;
            if(thunderTimer <= 0)
            {
                CreateThunder();
            }       
        }
        #endregion

        /**Third behaviour*/
        #region
        if (activateStun)
        {
            stunAreaTimer -= Time.deltaTime;
            if (stunAreaTimer <= 0)
            {
                StunAreaCollision();
            }     
        }
        #endregion
    }

    /**First behaviour
    Creates a target area using at the player position, save the position and activate second behaviuor*/
    void CreateThunderAreaTarget()
    {
        activateAreaTarget = false;
        GameObject AreaTargetPrefab = Instantiate(thunderAreaTargetVFX, player.transform.position, Quaternion.identity) as GameObject;
        thunderPosition = AreaTargetPrefab.transform;
        activateThunder = true;
        Destroy(AreaTargetPrefab, 3.5f);
    }

    /**Second behaviour
    Create the thunder effect and activate third behaviour */
    void CreateThunder()
    {
        activateThunder = false;
        GameObject thunderVFXprefab = Instantiate(thunderVFX, new Vector3(thunderPosition.position.x, thunderVFX.transform.position.y, thunderPosition.position.z + 6.5f), thunderVFX.transform.rotation) as GameObject;
        activateStun = true;
        Destroy(thunderVFXprefab, 3f);
    }

    /**Third behaviour
    Create a stun area when thunder hits the floor*/
    void StunAreaCollision()
    {
        
        cameraRef.ShakeCamera = true;
        GameObject stunAreaPrefab = Instantiate(stunArea, thunderPosition.position, stunArea.transform.rotation) as GameObject;
        stunAreaPrefab.GetComponent<StunAreaBehaviour>().Center = thunderPosition;
        activateStun = false;
        Destroy(this.gameObject,1f);
    }
}
