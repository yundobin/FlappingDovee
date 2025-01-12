using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Title = 0,
    GamePlay = 1,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager = null;
    
    public UnityEvent OnStateChange;
    public UnityEvent OnInitalize;
    public UnityEvent OnOtherControllerActivation;
    public UnityEvent OnOtherControllerDeactivation;
    public UnityEvent OnGameReady;
    public UnityEvent OnGameStart;
    private float Time_Start;
    private float Time_Current;
    private float WaitTime;
    private bool is_Ended;

    public GameState state;
    private void Awake() // 무조건 한번만 실행
    {
        if(gameManager == null)
        {
            gameManager = this;
            Debug.Log("GameManger : Object Creation Complete.");
        }
        else if(gameManager != this)
        {
            Destroy(gameObject);
        }
    }
    public void Start() // SetActive가 true가 될때마다 실행
    {
        WaitTime = 3f;
        is_Ended = true;
        Initialize();
    }
    public void Update()
    {
        if (is_Ended)
            return;

        Check_Timer();
    }
    public void Initialize()
    {
        OnInitalize.Invoke();
    }
    public void ChangeGameState(int st)
    {
        if(state != (GameState)st)
        {
            state = (GameState)st;
            OnStateChange.Invoke();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void resume()
    {
        Time.timeScale = 1f;
    }
    public void OtherControllerActivation()
    {
        OnOtherControllerActivation.Invoke();
        OnGameReady.Invoke();
        Reset_Timer();
    }
    public void OtherControllerDeactivation()
    {
        OnOtherControllerDeactivation.Invoke();
    }
    private void Reset_Timer()
    {
        Time_Start = Time.time;
        Time_Current = 0;
        is_Ended = false;
    }
        private void Check_Timer()
    {
        Time_Current = Time.time - Time_Start;
        if(Time_Current < WaitTime)
        {
            
        }
        else if(!is_Ended)
        {
            GameReady();
        }
    }
    public void GameReady()
    {
        Time_Current = WaitTime;
        is_Ended = true;
        GameStart();
    }
    public void GameStart()
    {
        OnGameStart.Invoke();
    }
    public void GameOver()
    {
        
    }
}
