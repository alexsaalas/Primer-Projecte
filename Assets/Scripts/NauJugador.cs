using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;
    private Vector2 minPantalla;
    private Vector2 maxPantalla;
    
    [SerializeField] private GameObject prefabProjectil;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float midaMeitatImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float midaMeitatImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;
        //* minPantalla.x = minPantalla.x + 0.75f;
        //* �s sinomin a linea arriba minPantalla.x += 0.75f

        minPantalla.x += midaMeitatImatgeX;
        maxPantalla.x -= midaMeitatImatgeX;
        minPantalla.y += midaMeitatImatgeY;
        maxPantalla.y -= midaMeitatImatgeY;
    }
    void Update()
    {
        MovimentNau();
        DispararProjectil();
    }

    private void MovimentNau()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");

        // Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);

        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;
        Vector2 novaPos = transform.position;

        // Mueve el objeto en la direcci�n indicada por el usuario
        novaPos += direccioIndicada * _vel * Time.deltaTime;

        // Limita la posici�n dentro de los l�mites de la pantalla
        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        // Actualiza la posici�n del objeto
        transform.position = novaPos;
    }
    private void DispararProjectil()
    {
        if (Input.GetKey("space"))
        {
            GameObject projectil = Instantiate(prefabProjectil);
            projectil.transform.position = transform.position;
        }
    }
}



