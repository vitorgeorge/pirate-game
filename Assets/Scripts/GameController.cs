using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float Timer = 0f;
    public GameObject EndGameScreen;
    public Text _points;
    public Text _timeValue;

    public static int _killCount = 0;
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
        _points.text = _killCount.ToString();        
        Timer += Time.deltaTime;
        float seconds = Mathf.FloorToInt(Timer % 60);
        _timeValue.text = seconds.ToString();
        if (seconds > MenuController._gameSessionTime)
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
        _killCount = 0;
        SceneManager.LoadScene(scene);
    }
}
