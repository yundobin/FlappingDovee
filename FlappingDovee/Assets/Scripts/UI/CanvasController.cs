using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasController : MonoBehaviour
{
    public List<GameObject> CanvasList;
    public UnityEvent OnInitialize;
    public UnityEvent OnPlaying;
    public UnityEvent OnNotPlaying;

    public void Initialize()
    {
        OnInitialize.Invoke();
    }
    public void ChangeCanvas()
    {
        int index = (int)GameManager.gameManager.state;
        for (int i = 0;i<CanvasList.Count; i++)
        {
            if(i == index)
            {
                CanvasList[i].SetActive(true);
            }
            else
            {
                CanvasList[i].SetActive(false);
            }
        }
        if (index >= 1)
        {
            OnPlaying.Invoke();
        }
        else
        {
            OnNotPlaying.Invoke();
        }
    }

    
}
