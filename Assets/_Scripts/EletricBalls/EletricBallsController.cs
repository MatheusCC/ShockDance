using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricBallsController : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    private GameObject[] eletricBalls;
    [SerializeField]
    private GameObject[] shocks;
    [SerializeField]
    private float blueShockRate;
    [SerializeField]
    private float pinkShockRate;

    public float BlueShockRate { get { return blueShockRate; } set { blueShockRate = value; } }
    public float PinkShockRate { get { return pinkShockRate; } set { pinkShockRate = value; } }


    /**Variables*/
    float blueCurrentTime;
    float pinkCurrentTime;
    int ID;

    void Start ()
    {
        //Find and stock all eletricballs in an array
        eletricBalls = GameObject.FindGameObjectsWithTag("EletricBall");
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*Checks if is time to create a new blue shock
        if YES call CreateShock function*/
        blueCurrentTime += Time.deltaTime;
        if (blueCurrentTime > blueShockRate)
        {
            ID = 0;
            CreateShock(ID);
            blueCurrentTime = 0;
        }

        /*Checks if is time to create a new pink shock
        if YES call CreateShock function*/
        pinkCurrentTime += Time.deltaTime;
        if (pinkCurrentTime > pinkShockRate)
        {
            ID = 1;
            CreateShock(ID);
            pinkCurrentTime = 0;
        }
    }
    /**Choose randomly one of the eletricballs and creates a shock from that ball */
    void CreateShock(int ID)
    {
        int randomBall = Random.Range(0, eletricBalls.Length);
        eletricBalls[randomBall].GetComponent<EletricBallBehaviour>().Shock = shocks[ID];
        eletricBalls[randomBall].GetComponent<EletricBallBehaviour>().InstantiateShock();
    }

}
