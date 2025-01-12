using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnInitialize;
    public UnityEvent OnGameReady;
    public UnityEvent OnGameStart;
    public void Start()
    {
        
    }
    public void Initialize()
    {
        OnInitialize.Invoke();
    }
    public void GameReady()
    {
        OnGameReady.Invoke();
    }
    public void GameStart()
    {
        OnGameStart.Invoke();
    }
}
