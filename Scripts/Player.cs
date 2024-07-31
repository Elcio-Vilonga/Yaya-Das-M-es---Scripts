using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    bool isBlowing;
    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    // controla a movimentação do Player (esquerda e direita)
    void Move()
    {
        // Vector3 moviment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //move o personagem para uma posição
        // transform.position += moviment * Time.deltaTime * Speed;

        // --------------------para bumbar no mobile------------------------
        // float moviment = 0;

        // if(Input.GetMouseButton(0))
        // {
        //     var center = Screen.width / 2;
        //     var mousePosition = Input.mousePosition;
        //     if(mousePosition.x > center)
        //     {
        //         moviment = 1;
        //         rig.velocity = new Vector2(moviment * Speed, rig.velocity.y);
        //     }
        //     else if(mousePosition.x < center)
        //     {
        //         moviment = -1;
        //         rig.velocity = new Vector2(moviment * Speed, rig.velocity.y);
        //     }
        // }
        // else
        // {
        //     moviment = Input.GetAxis("Horizontal");
        //     rig.velocity = new Vector2(moviment * Speed, rig.velocity.y);      
        // }
        // -----------------------------------------------------


        float moviment = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(moviment * Speed, rig.velocity.y); 

        if(moviment < 0f)
        {
            //para mudar a direcção do player (olhar para a direita)
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        //para mudar a direcção do player (olhar para a esquerda)
        if(moviment > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(moviment == 0f)
        {
            anim.SetBool("walk", false);
        }
    }


    // controla o pulo do player (pulo e duplo pulo)
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isBlowing)
        {
            if(!isJumping){
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else{
                if(doubleJump){
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }

            anim.SetBool("jump", true);
        }
    }

    // serve para detectar se o player está tocando algo
    void OnCollisionEnter2D(Collision2D colisao)
    {
        // no caso, está detectando se o player está "tocando" na layer 3(Blocos)
        if(colisao.gameObject.layer == 3)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        
        if(colisao.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
        
        if(colisao.gameObject.tag == "Saw")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
        //next level
        // if(colisao.gameObject.tag == "Next Level")
        // {
        //     GameController.instance.ShowNextLevel();
        // }
    }

    // serve para detectar se o player parou de tocar algo
    void OnCollisionExit2D(Collision2D colisao)
    {
        // no caso, está detectando se o player parou de "tocar" na layer 3(Blocos)
        if(colisao.gameObject.layer == 3){
            isJumping = true;
            anim.SetBool("jump", true);
        }
    }

    void OnTriggerStay2D(Collider2D colisao)
    {
        if(colisao.gameObject.layer == 8)
        {
            isBlowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D colisao)
    {
        if(colisao.gameObject.layer == 8)
        {
            isBlowing = false;
        }
    }
}
