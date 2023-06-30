using System.Collections;
using UnityEngine;


public class GamePlay : MonoBehaviour
{
    [SerializeField] GameObject _winWindow;
    [SerializeField] GameObject _looseWindow;

    private TaskInitializer _taskInitializer;
    private TimeBar _timeBar;
    private bool _isPaused = false;


    private void Start()
    {
        _taskInitializer = GetComponentInChildren<TaskInitializer>();
        _timeBar = GetComponentInChildren<TimeBar>();
    }

    private void Win() 
    {
        PauseTheGame();
        _winWindow.SetActive(true);
    }
    private void Loose() 
    {
        if(!_taskInitializer.IsMatch || _timeBar.IsNoTime)
        PauseTheGame(); 
        _looseWindow.SetActive(true);
    }

    private void PauseTheGame()
    {
        if (_isPaused == true) { 
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }

}
