using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization

    /** References*/
    Rigidbody playerRigidbody;
    CameraShake cameraRef;

    /**Public variables*/
    public float speed;

    public GameObject deadVFX;

    //public Image touchWallFeedback;
    public float flashSpeed = 5f;
    public Color flashColor;

    /**Variables*/
    float moveHorizontal;
    float moveVertical;
    float originalSpeed;
    Vector3 movement;

    bool stunEffectON;
    float stunEffectTime;

    bool touchWall;

    /**TouchScreen variables*/
    //public VirtualJoyStick moveJoyStick;

    void Start () {


        stunEffectON = false;

        /** Getting references*/
        playerRigidbody = GetComponent<Rigidbody>();
        cameraRef = FindObjectOfType<CameraShake>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

#if UNITY_STANDALONE || UNITY_WEBPLAYER //KEYBOARD INPUTS

        /** Get inputs values, move and rotates player*/
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement = new Vector3(moveHorizontal, 0, moveVertical);


#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE //MOBILE INPUTS

        movement = moveJoyStick.InputDirection;

#endif //End of mobile platform dependendent compilation section started above with #elif

        movement.Normalize();
        playerRigidbody.MovePosition(transform.position + movement * Time.deltaTime * speed);

        /** rotates players according with World */
        //transform.Rotate(moveVertical * 25, 0, -moveHorizontal * 25, Space.World);
        transform.Rotate(movement.z * 25, 0, -movement.x * 25, Space.World);

        //transform.Translate(movement * Time.deltaTime * speed);
        //playerRigidbody.AddForce(movement * speed);
        //playerRigidbody.velocity = movement *speed;

        /**If player is under stun effect, after "stunEffectTime" reaches 0 
        call function to disactivate it*/
        #region
        if (stunEffectON)
        {
            stunEffectTime -= Time.deltaTime;
            if (stunEffectTime <= 0)
            {
                DeactivateStunEffect();
            }
        }
#endregion

        /**Fashes the screen and return it to normal after player touchs a wall */
#region
        if (touchWall)
        {
            //touchWallFeedback.color = flashColor;
            touchWall = false;
        }
        else
        {
            //touchWallFeedback.color = Color.Lerp(touchWallFeedback.color, Color.clear, flashSpeed * Time.deltaTime);
        }
#endregion
    }

    /**Check if the players is touching a wall, if TRUE
    screen flashes and camera shakes*/
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "EletricWall")
        {
            touchWall = true;

            cameraRef.shakeCamera = true;
        }
    }

    /** Activates stun effect and changes player movement speed*/
    public void ActiveStunEffect(float time)
    {
        stunEffectON = true;
        stunEffectTime = 3;
        originalSpeed = speed;
        speed = 3;
    }

    /** Disactivate stun effect and return players speed to normal */
    void DeactivateStunEffect()
    {
        stunEffectON = false;
        speed = originalSpeed;
    }
}
