using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CodigoEnemigo : MonoBehaviour
{
    public float velocidad; //Variable para la velocidad del enemigo
    public Sprite[] graficosCoches; //Array donde se guaradrán los gráficos de los coches enemigos
    float movimientoVertical; //Variable para el movimiento de los coches enemigos

    // Start is called before the first frame update
    void Start()
    {
        movimientoVertical = (-1 / 100.0f) * velocidad; //Movimiento fijo en el eje Y para que los coches se muevan verticalmente hacia el jugador

        gameObject.transform.eulerAngles = new Vector3(0, 0, 180); //Función para rotar el coche y se queden invertidos

        //Elegir un gráfico aleatorio
        int totalColores = graficosCoches.Length; //Variable con valor del tamaño del array (número gráficos coches)
        int valorRandom; //Variable para el valor aleatorio
        valorRandom = Random.Range(0, totalColores); //Función aleatoria entre 0 y la variable con valor del tamaño del array
        gameObject.GetComponent<SpriteRenderer>().sprite = graficosCoches[valorRandom]; //Asignación del gráfico aleatorio al sprite del enemigo

    }

    // Update is called once per frame
    void Update()
    {
        //Hacer que el enemigo se mueva usando la velocidad
        Vector3 posicionActual = gameObject.transform.position; //Obtengo la posición íntegra del objeto (X, Y, Z)
        posicionActual.y = posicionActual.y + movimientoVertical; //La modifico dependiendo del  movimiento vertical
        gameObject.transform.position = posicionActual; //Devuelvo el valor a la variable original

    }
}
