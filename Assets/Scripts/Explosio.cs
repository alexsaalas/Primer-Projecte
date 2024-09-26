using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosio : MonoBehaviour
{
    [SerializeField]
    private Vector2 maxpantalla;
    private float _vel;  // Declaración de la variable _vel

    // Start is called before the first frame update
    void Start()
    {
        _vel = 10f;
        maxpantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Calcula los límites de la pantalla una sola vez
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = transform.position;
        posActual += new Vector2(0, 1) * _vel * Time.deltaTime;  // Mueve el objeto hacia arriba

        transform.position = posActual;  // Actualiza la posición

        if (transform.position.y > maxpantalla.y)  // Si se sale de la pantalla
        {
            Destroy(gameObject);  // Destruye el objeto
        }
    }
}
