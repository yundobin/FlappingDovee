using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class Dovee : MonoBehaviour
{
    public float upForce;
    private bool is_Dead;
    public UnityEvent OnGameOver;
    private Rigidbody2D rb;
    private Animator ani;
    private AudioSource Audio;
    public AudioClip Jump;
    public AudioClip Dead;
    public int PlayTime;
    public GameObject score_txt;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
    }
    public void Start()
    {
        PlayTime = 0;
        is_Dead = false;
        this.transform.position = new Vector2(-2, 0);
    }
    public void Update()
    {
        if (is_Dead == false)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(0, upForce));
                    Audio.clip = Jump;
                    Audio.Play();
                }
            }
        }
    }
    public void Initialize()
    {
        
    }
    public void GameReady()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void GameStart()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        rb.AddForce(new Vector2(0,0));
    }
    public void GameOver()
    {
        OnGameOver.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            is_Dead = true;
            if (PlayTime == 0)
            {
                Audio.clip = Dead;
                Audio.Play();
            }
            PlayTime++;
            ani.SetTrigger("Dead");
            GameOver();
        }
        else if(collision.gameObject.CompareTag("Score"))
        {
            score_txt.GetComponent<Score>().score++;
        }
    }
}
