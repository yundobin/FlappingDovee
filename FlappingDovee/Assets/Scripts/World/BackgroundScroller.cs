using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float ScrollSpeed = 0;
    public float Accelation;
    public float Arrive;
    float TargetOffset;
    bool is_Start;
    bool is_Over;
    Renderer rd;
    private void Awake()
    {
        rd = GetComponent<Renderer>();
    }
    public void Start()
    {
        is_Start = true;
        is_Over = false;
    }
    void Update()
    {
        if ((int)GameManager.gameManager.state == 1)
        {
            ScrollSpeed -= Accelation;
            if (ScrollSpeed <= -Arrive)
            {
                ScrollSpeed = -Arrive;
            }
            TargetOffset += Time.deltaTime * ScrollSpeed;
        }
        if((int)GameManager.gameManager.state == 2)
        {
            ScrollSpeed = 0;
            if (ScrollSpeed >= 0)
            {
                ScrollSpeed = 0;
            }
            TargetOffset -= Time.deltaTime * ScrollSpeed;
        }
        rd.material.mainTextureOffset = new Vector2(TargetOffset, 0);
    }
    public void Initialize()
    {

    }
    public void GameStart()
    {
        
    }
    public void GamePlay()
    {
        //속도 유지
    }
    public void GamePause()
    {

    }
    public void GameEnd()
    {
        is_Start = false;
        is_Over = true;
    }

}
