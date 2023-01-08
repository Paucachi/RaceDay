using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodigoCarretera : MonoBehaviour
{
    float movimientoCarretera = 0.01f; //Movimiento de carretera cada fotograma (1 pixel)
    public float velocidad = 1; //Factor de multiplicación para el movimiento
    public GameObject prefabEnemigo; //Variable con referencia al objeto enemigo
    float contadorTiempoEnemigos; //Variable para ir sumando el tiempo de aparición de enemigos
    float aparicionEnemigos; //Variable para la aparición de enemigos
    int record; //Variable del record
    float contadorTiempo; //Variable del contador del tiempo de juego
    public TextMeshProUGUI recordTexto; //Variable pública para el texto del record
    public TextMeshProUGUI tiempoTexto; //Variable pública para el texto del tiempo
    public TextMeshProUGUI tituloTexto; //Variable pública para el texto del título
    public GameObject botonJugar; //Variable del objeto botón


    // Start is called before the first frame update
    void Start()
    {
        aparicionEnemigos = 10000000; //Valor muy alto para que no genere enemigos antes de pulsar el boton de jugar
        record = 0; //Se inicia a 0
        contadorTiempo = 0; //Se inicia a 0

    }

    // Update is called once per frame
    void Update()
    {
        MoverCarretera(); //Llama al método que mueve la carretera
        CrearCoches(); //Llama al método para crear coches enemigos
        ActualizarTiempo(); //Llama al método que actualiza los tiempos de record y tiempo
        ActualizarTextos(); //Llama al método que actualiza los textos de record y tiempo
        
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
            int valorRandom; //Varialbe para el valor aleatorio
            valorRandom = Random.Range(0, 4); //Función aleatoria que variará entre los 4 casos correspondientes a la posición donde aparecerá el coche enmigo

            //Los cuatro casos posibles donde aparecerán los conches enemigos (corresponden a las posiciones de los carriles)
            switch (valorRandom)
            {
                case 0:
                    posicionEnemigo = new Vector3(-1.90f, 7f, -0.5f); //Carril 1 (izquierdo)
                    break;
                case 1:
                    posicionEnemigo = new Vector3(-0.6f, 7f, -0.5f); //Carril 2
                    break;
                case 2:
                    posicionEnemigo = new Vector3(0.6f, 7f, -0.5f); //Carril 3
                    break;
                case 3:
                    posicionEnemigo = new Vector3(1.90f, 7f, -0.5f); //Carril 4 (derecho)
                    break;
            }

            GameObject enemigo = Instantiate(prefabEnemigo, posicionEnemigo, Quaternion.identity); //Instanciamos el objeto prefabEnemigo
            CodigoEnemigo codigoEnemigo = enemigo.GetComponent<CodigoEnemigo>(); //Cogemos el componente CodigoEnemigo de la instancia
            codigoEnemigo.velocidad = velocidad; //Damos valor a la velocidad del componente de la instancia
            contadorTiempoEnemigos = 0; //Damos valor 0 al contador de los enemigos
        }

    }

    //Método que realizará determinadas acciones al inicio del juego (Función añadida directamente en Unity)
    public void InicioJuego()
    {
        velocidad = 1;
        tituloTexto.text = "";
        aparicionEnemigos = 1;
        contadorTiempo = 0;
        botonJugar.SetActive(false);

    }

    //Método que realizará determinadas acciones al finalizar el juego (función añadida directamente en Unity)
    public void FinJuego()
    {
        tituloTexto.text = "HAS PERDIDO"; //Actualizará el texto de la variable "Titulo" y lo imprimirá
        velocidad = 0; //Parará el juego, poniendo la velocidad a 0
        aparicionEnemigos = 10000000; //Valor muy alto para que no genere enemigos tras finalizar el juego
        botonJugar.SetActive(true); //Aparecerá de nuevo el botón de "Jugar"

    }

    //Método que actualiza los textos de los contadores
    void ActualizarTextos()
    {
        recordTexto.text = "Record: " + record;
        tiempoTexto.text = "Tiempo: " + (int) contadorTiempo; //Lo cambia a tipo entero al imprimir en pantalla

    }

    //Método que actualiza el tiempo del juego y el record
    void ActualizarTiempo()
    {
        if(velocidad>0)
        {
            contadorTiempo = contadorTiempo + Time.deltaTime; //A la variable se le asigna el valor del tiempo de juego transcurrido

            //Condición para actualizar el record cada vez que se supere el anterior
            if ((int)contadorTiempo > record)
            {
                record = (int)contadorTiempo;
            }

        }

    }


}
