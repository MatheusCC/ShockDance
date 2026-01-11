using UnityEngine;

[CreateAssetMenu(fileName = "GameModeData", menuName = "Scriptable Objects/GameModeData")]
public class GameModeData : ScriptableObject
{
    [System.Serializable]
    public enum GameModeEnum
    {
        NONE = 0,
        EASY_MODE = 1,
        NORMAL_MODE = 2,
        HARD_MODE = 3,
    }

    [System.Serializable]
    public struct GameModeConfig
    {
        [SerializeField]
        private GameModeEnum gameModeID;
        [SerializeField]
        private float blueShockRate;
        [SerializeField]
        private float pinkShockRate;
        [SerializeField]
        private float thunderRate;
        
        public GameModeEnum GameModeID { get { return gameModeID; } }
        public float BlueShockRate { get { return blueShockRate; } }
        public float PinkShockRate { get { return pinkShockRate; } }
        public float ThunderRate { get { return thunderRate; } }
    }
    
    [SerializeField]
    private GameModeConfig[] gameModeConfigs;

    public GameModeConfig GetGameModeConfig(GameModeEnum gameModeIDParam)
    {
        GameModeConfig gameModeConfig = default;
        
        for (int i = 0; i < gameModeConfigs.Length; i++)
        {
            if (gameModeConfigs[i].GameModeID == gameModeIDParam)
            {
                gameModeConfig = gameModeConfigs[i];
                break;
            }
        }

        if (gameModeConfig.GameModeID == GameModeEnum.NONE)
        {
            Debug.LogError("[GameModeData] GameModeConfig not found for game mode enum " + gameModeIDParam.ToString());
        }

        return gameModeConfig;
    }
}
