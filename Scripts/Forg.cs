using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forg : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    //
    // private bool dirRight = true;
    // private float timer;
    // public float moveTime;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector3(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
        //
        // if(dirRight)
        // {
        //     //se verdadeiro vai pra direita
        //     transform.Translate(Vector2.right * speed * Time.deltaTime);
        // }
        // else
        // {
        //     //se falso vai pra esquerda
        //     transform.Translate(Vector2.left * speed * Time.deltaTime);
        // }

        // timer += Time.deltaTime;
        // if(timer >= moveTime)
        // {
        //     dirRight = !dirRight;
        //     timer = 0f;
        // }
    }

    bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;
            Debug.Log(height);
            if(height > 0 && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0f;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;

                Destroy(gameObject, 0.33f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
    }
}
