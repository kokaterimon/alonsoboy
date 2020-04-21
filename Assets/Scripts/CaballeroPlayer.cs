﻿using System.Collections;
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
            caballeroRB.velocity = new Vector2(caballeroRB.velocity.x, 0f);
            caballeroRB.AddForce(new Vector2(0, poderSalto), ForceMode2D.Impulse);
            enSuelo = false;
        }

        enSuelo = Physics2D.OverlapCircle(checkearSuelo.position, checkearRadioSuelo, capaSuelo);
        caballeroAnim.SetBool("estaEnSuelo", enSuelo);

        float mover = Input.GetAxis("Horizontal");

        if (puedeMover)
        {
            if (mover > 0 && !voltearCaballero)
            {
                Voltear();
            }
            else if (mover < 0 && voltearCaballero)
            {
                Voltear();
            }

            caballeroRB.velocity = new Vector2(mover * maxVelocidad, caballeroRB.velocity.y);

            //Hacer que caballero corra
            caballeroAnim.SetFloat("VelMovimiento", Mathf.Abs(mover));
        }
        else
        {
            caballeroRB.velocity = new Vector2(0, caballeroRB.velocity.y);

            caballeroAnim.SetFloat("VelMovimiento", 0);
        }    

    }

    void Voltear()
    {
        voltearCaballero = !voltearCaballero;
           caballeroRender.flipX = !caballeroRender.flipX;
    }

    public void togglePuedeMover()
    {
        puedeMover = !puedeMover;
    }

}
