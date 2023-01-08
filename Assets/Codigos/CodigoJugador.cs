using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoJugador : MonoBehaviour
{
    public Vector3 posicionInicial; //Inicia el coche en la posición indicada
    public float velocidadMovimiento; //Variable para dar valor a la velocidad
    public GameObject carretera; //Variable de tipo objeto para la carretera

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pixelesPorUnidad = 100; //Variable que haga que para fotograma el coche se mueva 1 pixel porque 1 unidad = 100 pixeles;
        float movimientoLateral = Input.GetAxis("Horizontal") / pixelesPorUnidad * velocidadMovimiento; //Movimiento en el eje horizontal en el joystick, dividido entre 100 y por la velocidad que le asignemmos

        Vector3 posicionActual = gameObject.transform.position; //Obtengo la posición íntegra del objeto (X, Y, Z)
        posicionActual.x = posicionActual.x + movimientoLateral; //La modifico dependiendo del  movimiento lateral (joystick)
        gameObject.transform.position = posicionActual; //Devuelvo el valor a la variable original
    }

    //Método para finalizar juego al colisionar con un coche enemigo y que desaparezcan todos los coches que haya en la pantalla
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Todos los coches enemigos que hay en la pantalla desaparecerán
        GameObject [] enemigos = GameObject.FindGameObjectsWithTag("Enemigo"); 

        foreach (GameObject coche in enemigos)
        {
            Destroy(coche);

        }

        //Accedemos al método de finalizar el juego que está en el "CodigoCarretera"
        carretera.GetComponent<CodigoCarretera>().FinJuego();

        

    }

}



