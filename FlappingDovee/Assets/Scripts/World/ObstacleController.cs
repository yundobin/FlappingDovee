using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleController : MonoBehaviour
{
    public UnityEvent OnInitialize;
    public float NextSpawnTime = 5.0f;
    public GameObject Obstacle;
    public int ObsCount;
    private Queue<GameObject> Obstacles;
    // Start is called before the first frame update
    public void Start()
    {
        NextSpawnTime = 5.0f;
        Obstacles = new Queue<GameObject>();
        for(int i = 0;i < 10;i++)
        {
            GameObject obstacle = Instantiate(Obstacle, transform.position, Quaternion.identity);
            obstacle.transform.parent = this.transform;
            obstacle.SetActive(false);
            Obstacles.Enqueue(obstacle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(NextSpawnTime>0)
        {
            NextSpawnTime -= Time.deltaTime;
        }
        else
        {
            if ((int)GameManager.gameManager.state == 1)
            {
                GameObject obs = Pop();
                obs.SetActive(true);
                NextSpawnTime = 3;
            }
        }
    }
    public GameObject Pop()
    {
        return Obstacles.Dequeue();
    }
    public void push(GameObject obs)
    {
        obs.SetActive(false);
        obs.transform.position = this.transform.position;
        Obstacles.Enqueue(obs);
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

    }
}
