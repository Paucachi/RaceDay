using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoCarretera : MonoBehaviour
{
    float movimientoCarretera = 0.01f; //Movimiento de carretera cada fotograma (1 pixel)
    public float velocidad = 1; //Factor de multiplicación para el movimiento
    public GameObject prefabEnemigo; //Variable con referencia al objeto enemigo
    float contadorTiempo;
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

        MoverCarretera(); //Llama al método MoverCarretera
        CrearCoches();

    }

    void MoverCarretera()
    {
        Vector3 posicionActual = gameObject.transform.position; //Obtengo la posición íntegra (X, Y, Z)
        posicionActual.y = posicionActual.y - movimientoCarretera * velocidad; //La modifico dependiendo del  movimiento en Y
        posicionActual.y = posicionActual.y % 6.5f;
        gameObject.transform.position = posicionActual; //Devuelvo el valor a la variable original

    }

    void CrearCoches()
    {
        // Actualizamos contador de tiempo
        contadorTiempo = contadorTiempo + Time.deltaTime;
        
        // Cuando pasa 1 segundo instanciamos enemigo
        if (contadorTiempo >= 1)
        {
            //Posición X carriles: -1.90 ,-0.6, 0.6, 1.90
            //Posición Y: 3.96
            Vector3 posicionEnemigo = Vector3.zero; //Vector por defecto que vale 0
            int valorRandom;
            valorRandom = Random.Range(0, 4);
            switch (valorRandom)
            {
                case 0:
                    posicionEnemigo = new Vector3(-1.90f, 3.96f, -0.5f);
                    break;
                case 1:
                    posicionEnemigo = new Vector3(-0.6f, 3.96f, -0.5f);
                    break;
                case 2:
                    posicionEnemigo = new Vector3(0.6f, 3.96f, -0.5f);
                    break;
                case 3:
                    posicionEnemigo = new Vector3(1.90f, 3.96f, -0.5f);
                    break;
            }
            GameObject enemigo = Instantiate(prefabEnemigo, posicionEnemigo, Quaternion.identity); //Instanciamos el objeto prefabEnemigo
            CodigoEnemigo codigoEnemigo = enemigo.GetComponent<CodigoEnemigo>(); //Cogemos el componente CodigoEnemigo de la instancia
            codigoEnemigo.velocidad = velocidad; //Damos valor a la velocidad del componente de la instancia
            contadorTiempo = 0;
        }

    }
}
