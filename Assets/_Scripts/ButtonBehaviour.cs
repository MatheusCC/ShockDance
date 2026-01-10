using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour {

    // Use this for initialization

    /**References*/
    private EletricBallsController eletricBallController;
    private ThunderController thunderBehaviourController;
    private DataController dataController;

    void Start ()
    {
        eletricBallController = FindObjectOfType<EletricBallsController>();
        thunderBehaviourController = FindObjectOfType<ThunderController>();
        dataController = FindObjectOfType<DataController>();

        
    }
	
    //**Loads record panel with the records for each mode*/
    public void LoadRecordPainel()
    {
        /*
        Text easyModeRecord = GameObject.Find("EasyModeTimeTxt").GetComponent<Text>();
        Text mediumModeRecord = GameObject.Find("MediumModeTimeTxt").GetComponent<Text>();
        Text hardModeRecord = GameObject.Find("HardModeTimeTxt").GetComponent<Text>();

        PlayerProgress playerRecord = dataController.GetHighestPlayerTimer();

        easyModeRecord.text = string.Format("{0:00}:{1:00}", playerRecord.easyTimeMin, playerRecord.easyTimeSec);
        mediumModeRecord.text = string.Format("{0:00}:{1:00}", playerRecord.mediumTimeMin, playerRecord.mediumTimeSec);
        hardModeRecord.text = string.Format("{0:00}:{1:00}", playerRecord.hardTimeMin, playerRecord.hardTimeSec);
        */
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  
    }
    
    /**Set values for each mode when pressing the button*/
    public void LoadGameMode(string mode)
    {
        switch (mode)
        {
            case "Easy":
                dataController.GameMode = 1;
                eletricBallController.BlueShockRate = 2;
                eletricBallController.PinkShockRate = 5;
                thunderBehaviourController.ThunderRate = 8;
                break;

            case "Medium":
                dataController.GameMode = 2;
                eletricBallController.BlueShockRate = 1;
                eletricBallController.PinkShockRate = 3;
                thunderBehaviourController.ThunderRate = 6;
                break;

            case "Hard":
                dataController.GameMode = 3;
                eletricBallController.BlueShockRate = 0.5f;
                eletricBallController.PinkShockRate = 2;
                thunderBehaviourController.ThunderRate = 4;
                break;
        }
    }

}

