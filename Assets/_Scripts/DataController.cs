using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DataController : MonoBehaviour {

    // Use this for initialization

    private PlayerProgress playerModeProgress;

    public int gameMode;

    void Start () {

        StartCoroutine(LoadMenuScene());

        DontDestroyOnLoad(gameObject);

        LoadPlayerProgress();
    }
	
    IEnumerator LoadMenuScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameScene");
    }

    /** Save new record in case it is true and save progress for each mode*/
    public void SubmitNewHighestTime(float newMin, float newSec)
    {
        switch (gameMode)
        {
            case 1:
                if (newMin > playerModeProgress.easyTimeMin)
                {
                    playerModeProgress.easyTimeMin = newMin;
                    SavePlayerProgress();
                }
                if (newSec > playerModeProgress.easyTimeSec)
                {
                    playerModeProgress.easyTimeSec = newSec;
                    SavePlayerProgress();
                }
                break;

            case 2:
                if (newMin > playerModeProgress.mediumTimeMin)
                {
                    playerModeProgress.mediumTimeMin = newMin;
                    SavePlayerProgress();
                }
                if (newSec > playerModeProgress.mediumTimeSec)
                {
                    playerModeProgress.mediumTimeSec = newSec;
                    SavePlayerProgress();
                }
                break;

            case 3:
                if (newMin > playerModeProgress.hardTimeMin)
                {
                    playerModeProgress.hardTimeMin = newMin;
                    SavePlayerProgress();
                }
                if (newSec > playerModeProgress.hardTimeSec)
                {
                    playerModeProgress.hardTimeSec = newSec;
                    SavePlayerProgress();
                }
                break;
        }
        
    }


    public PlayerProgress GetHighestPlayerTimer()
    {
        return playerModeProgress;
    }

    /** Create a new player progress and if PlayerPrefs has the key called, 
    set the key value with the value already saved for each mode */
    private void LoadPlayerProgress()
    {
        playerModeProgress = new PlayerProgress();

        //EASY MODE
        if (PlayerPrefs.HasKey("easyTimeMin"))
        {
            playerModeProgress.easyTimeMin = PlayerPrefs.GetFloat("easyTimeMin");
        }
        if (PlayerPrefs.HasKey("easyTimeSec"))
        {
            playerModeProgress.easyTimeSec = PlayerPrefs.GetFloat("easyTimeSec");
        }

        //MEDIUM MODE
        if (PlayerPrefs.HasKey("mediumTimeMin"))
        {
            playerModeProgress.mediumTimeMin = PlayerPrefs.GetFloat("mediumTimeMin");
        }
        if (PlayerPrefs.HasKey("mediumTimeSec"))
        {
            playerModeProgress.mediumTimeSec = PlayerPrefs.GetFloat("mediumTimeSec");
        }

        //HARD MODE
        if (PlayerPrefs.HasKey("hardTimeMin"))
        {
            playerModeProgress.hardTimeMin = PlayerPrefs.GetFloat("hardTimeMin");
        }
        if (PlayerPrefs.HasKey("hardTimeSec"))
        {
            playerModeProgress.hardTimeSec = PlayerPrefs.GetFloat("hardTimeSec");
        }

    }

    /**save values for each PlayerPrefs key for each mode*/
    private void SavePlayerProgress()
    {
        switch(gameMode)
        {
            case 1:
                PlayerPrefs.SetFloat("easyTimeMin", playerModeProgress.easyTimeMin);
                PlayerPrefs.SetFloat("easyTimeSec", playerModeProgress.easyTimeSec);
                break;
            case 2:
                PlayerPrefs.SetFloat("mediumTimeMin", playerModeProgress.mediumTimeMin);
                PlayerPrefs.SetFloat("mediumTimeSec", playerModeProgress.mediumTimeSec);
                break;
            case 3:
                PlayerPrefs.SetFloat("hardTimeMin", playerModeProgress.hardTimeMin);
                PlayerPrefs.SetFloat("hardTimeSec", playerModeProgress.hardTimeSec);
                break;
        }

    }
}
