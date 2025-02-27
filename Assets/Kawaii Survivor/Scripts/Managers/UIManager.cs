using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IGameStateListener
{

    [Header("Panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStateChangedCallback(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.GAME:
                menuPanel.SetActive(false);
                gamePanel.SetActive(true);
                break;
            case GameState.MENU:
                menuPanel.SetActive(true);
                gamePanel.SetActive(false);
                break;
            
        }

    }
}
