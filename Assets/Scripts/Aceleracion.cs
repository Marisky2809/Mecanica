using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aceleracion : MonoBehaviour
{
    public float aceleracion = 3f;
    public float desacelereacion = -2f;
    public float maxVelocidad;
    public float constantSpeedTime;

    private float velocity = 0;
    private float timer = 0;
    public bool acelerando;
    public bool constante;
    private bool desacelerando;


    public float tiempoAcelerar;
    public float tiempoDesacelerar;

    public float metros = 5f;

    public float raiz;

    // Start is called before the first frame update
    void Start()
    {
        raiz = Mathf.Sqrt(metros / aceleracion);
        Debug.Log(raiz);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (acelerando)
        {
            velocity += aceleracion * Time.deltaTime;
            transform.position += Vector3.right * velocity * Time.deltaTime;
            if (timer >= tiempoAcelerar)
            {
                maxVelocidad = velocity;
                acelerando = false;
                constante = true;
                timer = 0;
                Debug.Log(transform.position.x);
            }
        }

        else if (constante)
        {
            transform.position += Vector3.right * maxVelocidad * Time.deltaTime;
            if (timer >= constantSpeedTime)
            {
                constante = false;
                desacelerando = true;
                timer = 0;
                Debug.Log(transform.position.x);
            }
        }

        else if (desacelerando)
        {
            velocity += desacelereacion * Time.deltaTime;
            velocity = Mathf.Max(velocity, 0);

            transform.position += Vector3.right * velocity * Time.deltaTime;

            if (velocity <= 0)
            {
                desacelerando = false;
                Debug.Log(transform.position.x);
            }
        }
    }
}
