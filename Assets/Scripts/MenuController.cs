using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static float _gameSessionTime = 60;

    public static float _enemySpawnRate = 5;

    public Text _gameSessionText;
    public Text _enemySpawnText;
    
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void SetSpawnValue(float value)
    {
        _enemySpawnRate = value;
    }
    public void SetGameSessionValue(float value)
    {
        _gameSessionTime = value;
    }
}
