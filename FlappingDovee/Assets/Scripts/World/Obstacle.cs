using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 3;
        this.gameObject.transform.position = new Vector3(3.5f, Random.Range(-1.75f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
        if(this.transform.position.x < -3.5)
        {
            this.transform.parent.GetComponent<ObstacleController>().push(gameObject);
        }
    }
}
