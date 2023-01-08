using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodigoCarretera : MonoBehaviour
{
    float movimientoCarretera = 0.01f; //Movimiento de carretera cada fotograma (1 pixel)
    public float velocidad = 1; //Factor de multiplicación para el movimiento
    public GameObject prefabEnemigo; //Variable con referencia al objeto enemigo
    float contadorTiempoEnemigos; //Variable para ir sumando el tiempo
    float aparicionEnemigos;
    int record;
    float contadorTiempo;
    public TextMeshProUGUI recordTexto;
    public TextMeshProUGUI tiempoTexto;
    public TextMeshProUGUI tituloTexto;
    public GameObject botonJugar;
    //float contadorTiempoDificultad;

    // Start is called before the first frame update
    void Start()
    {
        //Damos valor a las variables
        aparicionEnemigos = 10000000; //Valor muy alto para que no genere enemigos antes de dar al boton de pulsar
        record = 0;
        contadorTiempo = 0;

    }

    // Update is called once per frame
    void Update()
    {
        MoverCarretera(); //Llama al método MoverCarretera
        CrearCoches();
        ActualizarTiempo();
        ActualizarTextos();
        //ActualizarDificultad();
        
    }

    //Método que permite mover la carretera
    void MoverCarretera()
    {
        Vector3 posicionActual = gameObject.transform.position; //Obtengo la posición íntegra (X, Y, Z)
        posicionActual.y = posicionActual.y - movimientoCarretera * velocidad; //La modifico dependiendo del  movimiento en Y
        posicionActual.y = posicionActual.y % 6.5f; //Devuelve el resto (tamaño de pixeles de la imagen de la carretera 6.5)
        gameObject.transform.position = posicionActual; //Devuelvo el valor a la variable original

    }

    //Método que permite crear coches enemigos y situarlos en la escena
    void CrearCoches()
    {
        // Actualizamos contador de tiempo
        contadorTiempoEnemigos = contadorTiempoEnemigos + Time.deltaTime; //Se le suma al contador la fración de tiempo
        
        // Cuando pasa 1 segundo instanciamos enemigo
        if (contadorTiempoEnemigos >= aparicionEnemigos)
        {
            //Posición X carriles: -1.90 ,-0.6, 0.6, 1.90
            //Posición Y: 7f
            Vector3 posicionEnemigo = Vector3.zero; //Vector por defecto que vale 0
            int valorRandom;
            valorRandom = Random.Range(0, 4); //Rango que variará entre las 4 posiciones
            switch (valorRandom)
            {
                case 0:
                    posicionEnemigo = new Vector3(-1.90f, 7f, -0.5f);
                    break;
                case 1:
                    posicionEnemigo = new Vector3(-0.6f, 7f, -0.5f);
                    break;
                case 2:
                    posicionEnemigo = new Vector3(0.6f, 7f, -0.5f);
                    break;
                case 3:
                    posicionEnemigo = new Vector3(1.90f, 7f, -0.5f);
                    break;
            }
            GameObject enemigo = Instantiate(prefabEnemigo, posicionEnemigo, Quaternion.identity); //Instanciamos el objeto prefabEnemigo
            CodigoEnemigo codigoEnemigo = enemigo.GetComponent<CodigoEnemigo>(); //Cogemos el componente CodigoEnemigo de la instancia
            codigoEnemigo.velocidad = velocidad; //Damos valor a la velocidad del componente de la instancia
            contadorTiempoEnemigos = 0;
        }

    }

    public void FinJuego()
    {
        tituloTexto.text = "HAS PERDIDO";
        velocidad = 0;
        aparicionEnemigos = 10000000; //Valor muy alto para que no genere enemigos tras finalizar el juego
        botonJugar.SetActive(true);

    }

    public void InicioJuego()
    {
        velocidad = 1;
        tituloTexto.text = "";
        aparicionEnemigos = 1;
        contadorTiempo = 0;
        botonJugar.SetActive(false);

    }


    void ActualizarTextos()
    {
        recordTexto.text = "Record: " + record;
        tiempoTexto.text = "Tiempo: " + (int) contadorTiempo; //Lo cambia a tipo entero al imprimir en pantalla

    }

    void ActualizarTiempo()
    {
        if(velocidad>0)
        {
            contadorTiempo = contadorTiempo + Time.deltaTime; //A la variable se le asigna el valor del tiempo transcurrido

            //Condición para actualizar el record cada vez que se supere el anterior
            if ((int)contadorTiempo > record)
            {
                record = (int)contadorTiempo;
            }

        } 

    }

    /*
    void ActualizarDificultad()
    {

        // Actualizamos contador de tiempo
        contadorTiempoDificultad = contadorTiempoDificultad + Time.deltaTime; //Se le suma al contador la fración de tiempo

        // Cuando pasan 5 segundos
        if (contadorTiempoDificultad >= 5)
        {
            contadorTiempoDificultad = 0;
            velocidad = velocidad + 0.5f;
        }
    }

    */
}
