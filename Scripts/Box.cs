using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float jumpForce;
    public bool isUp;

    public int health = 5;

    public Animator anim;
    
    public GameObject effect;

    void Update()
    {
        if(health <= 0)
        {
            // destroi a caixa
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            if(isUp)
            {
                anim.SetTrigger("hit");
                health--;
                colisao.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                anim.SetTrigger("hit");
                health--;
                colisao.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
