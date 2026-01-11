using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    
    public static GameManager Instance { get { return instance; } }

    [SerializeField] 
    private GameModeData gameModeData = null;
    [SerializeField]
    private GameController gameController = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartGameMode(int gameModeIndex)
    {
        GameModeData.GameModeConfig gameModeConfig = gameModeData.GetGameModeConfig((GameModeData.GameModeEnum)gameModeIndex);
        if (gameModeConfig.GameModeID != GameModeData.GameModeEnum.NONE)
        {
            gameController.Initialize(gameModeConfig);
        }
    }
    
    private void Start()
    {

    }

    private void Update()
    {

    }
}