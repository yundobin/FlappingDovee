using UnityEngine;
using UnityEngine.Events;

public class Canvas : MonoBehaviour
{
    public UnityEvent OnInitialize;
    public void Initialize()
    {
        OnInitialize.Invoke();
    }
}
