using UnityEngine;
using UnityEngine.Serialization;

public class ArenaController : MonoBehaviour {

    [System.Serializable]
    private enum ShockEnum
    {
        BLUE = 0,
        PINK = 1,
    }

    [System.Serializable]
    private struct ShockType
    {
        [SerializeField]
        private ShockEnum shockEnum;
        [SerializeField]
        private GameObject shockPrefab;
        
        public ShockEnum ShockEnum  { get { return shockEnum; } }
        public GameObject ShockPrefab  { get { return shockPrefab; } }
    }
    
    // Use this for initialization
    [FormerlySerializedAs("eletricBalls")] [SerializeField]
    private GameObject[] electricBalls;
    [SerializeField]
    private ShockType[] shocks;
    [SerializeField]
    private float blueShockRate;
    [SerializeField]
    private float pinkShockRate;

    [Header("Thunder")]
    [SerializeField]
    private GameObject thunder;
    [SerializeField]
    private float thunderRate;

    /**Variables*/
    private float blueCurrentTime;
    private float pinkCurrentTime;
    private float thunderCurrentTime;

    public void Initialize(GameModeData.GameModeConfig gameModeConfigParam)
    {
        blueShockRate = gameModeConfigParam.BlueShockRate;
        pinkShockRate = gameModeConfigParam.PinkShockRate;
        thunderRate = gameModeConfigParam.ThunderRate;
    }
    
	// Update is called once per frame
	void Update ()
    {
        /*Checks if is time to create a new blue shock
        if YES call CreateShock function*/
        blueCurrentTime += Time.deltaTime;
        if (blueCurrentTime > blueShockRate)
        {
            CreateShock(ShockEnum.BLUE);
            blueCurrentTime = 0;
        }

        /*Checks if is time to create a new pink shock
        if YES call CreateShock function*/
        pinkCurrentTime += Time.deltaTime;
        if (pinkCurrentTime > pinkShockRate)
        {
            CreateShock(ShockEnum.PINK);
            pinkCurrentTime = 0;
        }

        //Control with a rate variable when the GameObject "thunder" should be instantiated
        thunderCurrentTime += Time.deltaTime;
        if (thunderCurrentTime > thunderRate)
        {
            GameObject thunderPrefab = Instantiate(thunder, thunder.transform.position, thunder.transform.rotation) as GameObject;
            thunderCurrentTime = 0;
        }
    }
    //Choose randomly one of the eletricballs and creates a shock from that ball
    private void CreateShock(ShockEnum shockEnum)
    {
        GameObject shockPrefab = GetShockPrefabForType(shockEnum);

        if (shockEnum == ShockEnum.PINK)
        {
            shockPrefab.GetComponent<Shock>().SetShockAsPinkShock();
        }
        
        int randomBall = Random.Range(0, electricBalls.Length);
        
        ElectricBallBehaviour electricBallBehaviour = electricBalls[randomBall].GetComponent<ElectricBallBehaviour>();
        
        electricBallBehaviour.Shock = GetShockPrefabForType(shockEnum);
    
        electricBalls[randomBall].GetComponent<ElectricBallBehaviour>().InstantiateShock();
    }

    private GameObject GetShockPrefabForType(ShockEnum shockEnumParam)
    {
        GameObject shockPrefab = null;

        for (int i = 0; i < shocks.Length; i++)
        {
            if (shocks[i].ShockEnum == shockEnumParam)
            {
                shockPrefab = shocks[i].ShockPrefab;
                break;
            }
        }

        if (shockPrefab == null)
        {
            Debug.LogError("[ArenaController] Couldn't find shock prefab for type enum " + shockEnumParam.ToString());
        }
        
        return shockPrefab;
    }
}