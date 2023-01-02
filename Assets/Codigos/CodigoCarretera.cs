using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoCarretera : MonoBehaviour
{
    float movimientoCarretera = 0.01f; //Movimiento de carretera cada fotograma (1 pixel)
    public float velocidad = 1; //Factor de multiplicación para el movimiento
    //float a = 0;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // Ejemplo de funcionamiento del Modulo (resto)
        /*
        a = a + 1;
        float modulo = a % 6.5f;
        if (a < 20)
        {
            Debug.Log(a + " --> modulo 10 -->" + modulo);
        }
        */
        Vector3 posicionActual = gameObject.transform.position; //Obtengo la posición íntegra (X, Y, Z)
        posicionActual.y = posicionActual.y - movimientoCarretera * velocidad; //La modifico dependiendo del  movimiento en Y
        posicionActual.y = posicionActual.y % 6.5f;
        gameObject.transform.position = posicionActual; //Devuelvo el valor a la variable original
    }
}
