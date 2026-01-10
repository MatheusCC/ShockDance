using UnityEngine;

[CreateAssetMenu(fileName = "GameModeData", menuName = "Scriptable Objects/GameModeData")]
public class GameModeData : ScriptableObject
{
    [System.Serializable]
    private enum GameModeEnum
    {
        NONE = 0,
        EASY_MODE = 1,
        NORMAL_MODE = 2,
        HARD_MODE = 3,
    }

    [System.Serializable]
    private struct GameModeConfig
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
}
