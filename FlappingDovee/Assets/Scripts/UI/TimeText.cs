using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    public Text Timetext;
    public float LeftTime;
    // Start is called before the first frame update
    public void Start()
    {
        this.gameObject.SetActive(true);
        LeftTime = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(LeftTime < 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            Timetext.text = LeftTime.ToString("N0") + "초 후 시작";
            if (LeftTime < 1)
            {
                Timetext.text = "Start!!!";
            }
            LeftTime -= Time.deltaTime;
        }
    }
}
