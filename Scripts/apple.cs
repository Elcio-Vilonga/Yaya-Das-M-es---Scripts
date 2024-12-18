using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    private AudioSource sound;

    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();

        sound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            sound.Play();
            
            sr.enabled = false;
            circle.enabled = false;

            collected.SetActive(true);

            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.5f);
        }
    }
}
