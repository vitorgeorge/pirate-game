using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private float Timer = 0f;
    public GameObject EndGameScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        float seconds = Mathf.FloorToInt(Timer % 60);
        if(seconds > MenuController._gameSessionTime)
        {
            EndGame();
        }
    }
    public void EndGame() {
        EndGameScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnEndPlayerLoadScene(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }
}
