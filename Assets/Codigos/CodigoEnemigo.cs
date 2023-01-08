using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CodigoEnemigo : MonoBehaviour
{
    public float velocidad;
    public Sprite[] graficosCoches;
    float movimientoVertical;

    // Start is called before the first frame update
    void Start()
    {
        movimientoVertical = (-1 / 100.0f) * velocidad; //Movimiento fijo en el eje Y para que los coches se muevan verticalmente hacia el jugador

        // Rotar el coche
        gameObject.transform.eulerAngles = new Vector3(0, 0, 180);

        //Elegir un gr�fico aleatorio
        int totalColores = graficosCoches.Length; //Variable con valor del tama�o del array (n�mero gr�ficos coches)
        int valorRandom; //Variable para el m�todo aleatorio
        valorRandom = Random.Range(0, totalColores); //Funci�n aleatoria entre 0 y la variable del tama�o del array
        gameObject.GetComponent<SpriteRenderer>().sprite = graficosCoches[valorRandom]; //Asignaci�n del gr�fico aleatorio al sprite del enemigo

    }

    // Update is called once per frame
    void Update()
    {
        //Hacer que el enemigo se mueva usando la velocidad
        Vector3 posicionActual = gameObject.transform.position; //Obtengo la posici�n �ntegra del objeto (X, Y, Z)
        posicionActual.y = posicionActual.y + movimientoVertical; //La modifico dependiendo del  movimiento vertical
        gameObject.transform.position = posicionActual; //Devuelvo el valor a la variable original

    }
}
