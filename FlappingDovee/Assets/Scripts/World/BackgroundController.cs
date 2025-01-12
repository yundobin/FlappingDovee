using UnityEngine;
using UnityEngine.Events;

public class BackgroundController : MonoBehaviour
{
    public UnityEvent OnInitialize;
    public UnityEvent OnGameReady;
    public UnityEvent OnGameStart;
    private float WaitTime;
    public void Start()
    {
        GameReady();
    }
    public void Initialize()
    {
        OnInitialize.Invoke();
    }
    public void GameReady()
    {
        
    }
    public void GameStart()
    {
        OnGameStart.Invoke();
    }
}
