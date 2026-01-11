using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {

    // Use this for initialization

    /**References*/
    private DataController dataController;

    /*
    [SerializeField]
    private TextMeshProUGUI gameModeText;
    [SerializeField]
    private TextMeshProUGUI bestModeTime;
    [SerializeField]
    private TextMeshProUGUI timeEndGame;
    [SerializeField]
    private TextMeshProUGUI timeText;
    */
     
    [SerializeField]
    private ArenaController arenaController = null;
    

    [SerializeField]
    private GameObject endGamePainel;
    [SerializeField]
    private bool endGame;

    public bool EndGame { get => endGame; set => endGame = value; }

    /**variables */
    private float minutes;
    private float seconds;
    private float endGameDelay;
    
    private GameModeData.GameModeConfig cachedGameModeConfig;

    public void Initialize(GameModeData.GameModeConfig gameModeConfigParam)
    {
        cachedGameModeConfig = gameModeConfigParam;
        
        arenaController.Initialize(gameModeConfigParam);

        this.enabled = true;
        arenaController.enabled = true;
        
        Debug.Log("Starting Game!! GameMode: " + gameModeConfigParam.GameModeID);
    }
    
    void Start () {

        dataController = FindObjectOfType<DataController>();

        minutes = 0;
        seconds = 0;

        endGame = false;
        endGameDelay = 2;
    }
	
	// Update is called once per frame
	void Update () {

        /**Runs game timer*/
        if (!endGame)
        {
            seconds += Time.deltaTime;
            GameTimer();
        }

        /**If TRUE, stops to spawn shocks and thunder*/
        if (endGame)
        {
            GetComponent<ArenaController>().enabled = false;
            endGameDelay -= Time.deltaTime;
            if(endGameDelay < 0)
            {
                EndGamePainel();
                endGame = false;
            }
        }
    }

    /**Converts the timers in minutes and seconds format*/
    void GameTimer()
    {
        if(seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }
        //timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /**Call function to check if there is a new record,
    enables a painel showing the record according to the mode selected and your time*/
    public void EndGamePainel()
    {

        dataController.SubmitNewHighestTime(minutes, seconds);
        PlayerProgress playerHighestRecord = dataController.GetHighestPlayerTimer();

        endGamePainel.SetActive(true);

        /*
        switch (dataController.gameMode)
        {
            case 1:
                gameModeText.text = "Easy Mode Record";
                bestModeTime.text = string.Format("{0:00}:{1:00}", playerHighestRecord.easyTimeMin, playerHighestRecord.easyTimeSec);
                timeEndGame.text = timeText.text;
                break;
            case 2:
                gameModeText.text = "Medium Mode Record";
                bestModeTime.text = string.Format("{0:00}:{1:00}", playerHighestRecord.mediumTimeMin, playerHighestRecord.mediumTimeSec);
                timeEndGame.text = timeText.text;
                break;
            case 3:
                gameModeText.text = "Hard Mode Record";
                bestModeTime.text = string.Format("{0:00}:{1:00}", playerHighestRecord.hardTimeMin, playerHighestRecord.hardTimeSec);
                timeEndGame.text = timeText.text;
                break;
        }
        */
        gameObject.SetActive(false);
    }
}
