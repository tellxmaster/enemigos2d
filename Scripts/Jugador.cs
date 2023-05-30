using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public GameManager gameManager;
    public float fuerzaSalto = 250;
    private Rigidbody2D rigidbody2;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetBool("estaSaltando",true);
            rigidbody2.AddForce(new Vector2(0,fuerzaSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.vidas--;
        }

        if (collision.gameObject.tag == "Suelo") {
            animator.SetBool("estaSaltando",false);
        }

    }


}
