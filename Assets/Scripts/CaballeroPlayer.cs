using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaballeroPlayer : MonoBehaviour{

    Rigidbody2D caballeroRB;
    public float maxVelocidad;
    Animator caballeroAnim;

    bool puedeMover = true;

    //Saltar
    bool enSuelo = false;
    float checkearRadioSuelo = 0.2f;
    public LayerMask capaSuelo;
    public Transform checkearSuelo;
    public float poderSalto;

    //Voltear caballero
    bool voltearCaballero = true;
    SpriteRenderer caballeroRender;

    // Start is called before the first frame update
    void Start()
    {
        caballeroRB = GetComponent<Rigidbody2D>();
        caballeroRender = GetComponent<SpriteRenderer>();
        caballeroAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (puedeMover && enSuelo && Input.GetAxis("Jump") > 0)
        {
            caballeroAnim.SetBool("estaEnSuelo", false);
        }

        float mover = Input.GetAxis("Horizontal");

        if(mover > 0 && !voltearCaballero)
        {
            Voltear();
        }else if(mover <0 && voltearCaballero)
        {
            Voltear();
        }


        caballeroRB.velocity = new Vector2(mover * maxVelocidad, caballeroRB.velocity.y);

        //Hacer que caballero corra
        caballeroAnim.SetFloat("VelMovimiento", Mathf.Abs(mover));
    }

    void Voltear()
    {
        voltearCaballero = !voltearCaballero;
           caballeroRender.flipX = !caballeroRender.flipX;
    }


}
