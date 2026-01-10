using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private static PlayerPersistence instance;

    public static PlayerPersistence Instance { get { return instance; } }

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

    public void SaveHighestTimeGameMode(int gameModeIndex, float time)
    {
        string key = GetKeyHighestTimeGameMode(gameModeIndex);
        PlayerPrefs.SetFloat(key, time);
        PlayerPrefs.Save();
    }

    public float LoadHighestTimeGameMode(int gameModeIndex)
    {
        float time;
        string key = GetKeyHighestTimeGameMode(gameModeIndex);
        if (PlayerPrefs.HasKey(key))
        {
            time = PlayerPrefs.GetFloat(key, 0f);
        }
        else
        {
            time = 0f;
        }

        return time;
    }

    private string GetKeyHighestTimeGameMode(int gameModeIndex)
    {
        return "GameMode_" + gameModeIndex;
    }
}