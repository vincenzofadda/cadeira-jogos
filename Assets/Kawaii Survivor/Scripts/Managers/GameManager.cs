using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private WaveManager waveManager;
    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }
    
    void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        Application.targetFrameRate = 60;
        SetGameState(GameState.MENU);
    }

    public void StartGame()
    {
        SetGameState(GameState.GAME);
    }
    // Update is called once per frame

    public void SetGameState(GameState gameState)
    {
        IEnumerable<IGameStateListener> gameStateListeners = 
        FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
        .OfType<IGameStateListener>();
    
        foreach(IGameStateListener gameStateListener in gameStateListeners)
            gameStateListener.GameStateChangedCallback(gameState);
    }

    public void WaveCompleteCallback()
    {
        waveManager.StartNextWave();
    }
}

public interface IGameStateListener
{
    void GameStateChangedCallback(GameState gameState);
}
