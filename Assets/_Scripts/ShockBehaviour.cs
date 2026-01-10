using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShockBehaviour : MonoBehaviour {

    // Use this for initialization
   
    [SerializeField]
    private float shockSpeed;

    int pinkShocklife;

    /**References*/
    Rigidbody rb;
    GameController gameController;
    PlayerMovement player;
    CameraShake cameraRef;
    AudioSource shockSound;

    void Start ()
    {
        gameController = FindObjectOfType<GameController>();
        player = FindObjectOfType<PlayerMovement>();
        cameraRef = FindObjectOfType<CameraShake>();
        shockSound = GetComponent<AudioSource>();

        int randomAngle = Random.Range(-45, 45);
        transform.Rotate(0f, (transform.localRotation.y + randomAngle) , 0f);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shockSpeed, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //this.transform.position += transform.forward * Time.deltaTime * shockSpeed;
        //Vector3 relativePos = transform.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        //transform.rotation = rotation;

        /**Moves shocks according with the direction they are facing*/
        Vector3 facingDirection = rb.linearVelocity;
        transform.rotation = Quaternion.LookRotation(facingDirection);

    }

    /**Check if it hit the player or an eletric wall*/
    void OnCollisionEnter(Collision other)
    {
        /**active camera shake, destroy and instantiate game objects,
        ends the game*/
        if (other.gameObject.tag == "Player")
        {
            cameraRef.ShakeCamera = true;
            gameController.EndGame = true;
            GameObject prefabDeadFVX = Instantiate(player.DeadVFX, other.transform.position, Quaternion.identity) as GameObject;
            Destroy(prefabDeadFVX, 2);         
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        
        /**if a blueshock hits the wall it is destroyed
        if a pinkshock hits the wall it bounces 5 time and is destroyed*/
        if (other.gameObject.tag == "EletricWall" && this.gameObject.tag == "BlueShock")
        {
            shockSound.Play();
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "EletricWall" && this.gameObject.tag == "PinkShock")
        {
            pinkShocklife++;
            shockSound.Play();
            if (pinkShocklife == 5)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
