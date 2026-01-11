using UnityEngine;

public class Shock : MonoBehaviour {

    [SerializeField]
    private float shockSpeed;
    [SerializeField]
    private int pinkShocklife = 5;
    
    private bool isPinkShock;
    private Rigidbody rb;
    private GameController gameController;
    private AudioSource shockSound;
    
    
    private void Start ()
    {
        gameController = FindObjectOfType<GameController>();
        shockSound = GetComponent<AudioSource>();

        int randomAngle = Random.Range(-45, 45);
        transform.Rotate(0f, (transform.localRotation.y + randomAngle) , 0f);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shockSpeed, ForceMode.Impulse);
    }

	// Update is called once per frame
	private void Update ()
    {
        //this.transform.position += transform.forward * Time.deltaTime * shockSpeed;
        //Vector3 relativePos = transform.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        //transform.rotation = rotation;

        //Moves shocks according with the direction they are facing
        Vector3 facingDirection = rb.linearVelocity;
        transform.rotation = Quaternion.LookRotation(facingDirection);

    }

    /**Check if it hit the player or an eletric wall*/
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            // Trigger a hit on player
            other.gameObject.GetComponent<PlayerHealth>().Hit();
            gameController.EndGame = true;
            
            Destroy(this.gameObject);
        }
        
        if (other.gameObject.CompareTag("ElectricWall"))
        {
            shockSound.Play();
            
            if (isPinkShock)
            {
                // Decrease pink shock life after hit the wall
                pinkShocklife--;
                
                if (pinkShocklife == 0)
                {
                    // Destroy pink shock
                    Destroy(this.gameObject);
                }
            }
            else
            {
                // Destroy blue shock
                Destroy(this.gameObject);
            }
        }
    }
    
    public void SetShockAsPinkShock()
    {
        isPinkShock = true;
    }
}