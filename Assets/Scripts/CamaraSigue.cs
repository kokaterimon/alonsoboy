using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSigue : MonoBehaviour{

    public Transform Objetivo;
    public float suavizado = 5f;

    Vector3 desface;

    // Start is called before the first frame update
    void Start()
    {
        desface = transform.position - Objetivo.position;
    }

    void FixedUpdate()
    {
        Vector3 posicionObjetivo = Objetivo.position + desface;
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavizado * Time.deltaTime);
    }
}
