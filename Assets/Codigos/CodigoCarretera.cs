using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodigoCarretera : MonoBehaviour
{
    float movimientoCarretera = 0.01f; //Movimiento de carretera cada fotograma (1 pixel)
    public float velocidad = 1; //Factor de multiplicaci�n para el movimiento
    public GameObject prefabEnemigo; //Variable con referencia al objeto enemigo
    float contadorTiempoEnemigos; //Variable para ir sumando el tiempo de aparici�n de enemigos
    float aparicionEnemigos; //Variable para la aparici�n de enemigos
    int record; //Variable del record
    float contadorTiempo; //Variable del contador del tiempo de juego
    public TextMeshProUGUI recordTexto; //Variable p�blica para el texto del record
    public TextMeshProUGUI tiempoTexto; //Variable p�blica para el texto del tiempo
    public TextMeshProUGUI tituloTexto; //Variable p�blica para el texto del t�tulo
    public GameObject botonJugar; //Variable del objeto bot�n


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
        MoverCarretera(); //Llama al m�todo que mueve la carretera
        CrearCoches(); //Llama al m�todo para crear coches enemigos
        ActualizarTiempo(); //Llama al m�todo que actualiza los tiempos de record y tiempo
        ActualizarTextos(); //Llama al m�todo que actualiza los textos de record y tiempo
        
    }

    //M�todo que permite mover la carretera
    void MoverCarretera()
    {
        Vector3 posicionActual = gameObject.transform.position; //Obtengo la posici�n �ntegra (X, Y, Z)
        posicionActual.y = posicionActual.y - movimientoCarretera * velocidad; //La modifico dependiendo del  movimiento en Y
        posicionActual.y = posicionActual.y % 6.5f; //Devuelve el resto (tama�o de pixeles de la imagen de la carretera 6.5)
        gameObject.transform.position = posicionActual; //Devuelvo el valor a la variable original

    }

    //M�todo que permite crear coches enemigos y situarlos en la escena
    void CrearCoches()
    {
        // Actualizamos contador de tiempo
        contadorTiempoEnemigos = contadorTiempoEnemigos + Time.deltaTime; //Se le suma al contador la fraci�n de tiempo
        
        // Cuando pasa 1 segundo instanciamos enemigo
        if (contadorTiempoEnemigos >= aparicionEnemigos)
        {
            //Posici�n X carriles: -1.90 ,-0.6, 0.6, 1.90
            //Posici�n Y: 7f
            Vector3 posicionEnemigo = Vector3.zero; //Vector por defecto que vale 0
            int valorRandom; //Varialbe para el valor aleatorio
            valorRandom = Random.Range(0, 4); //Funci�n aleatoria que variar� entre los 4 casos correspondientes a la posici�n donde aparecer� el coche enmigo

            //Los cuatro casos posibles donde aparecer�n los conches enemigos (corresponden a las posiciones de los carriles)
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

    //M�todo que realizar� determinadas acciones al inicio del juego (Funci�n a�adida directamente en Unity)
    public void InicioJuego()
    {
        velocidad = 1;
        tituloTexto.text = "";
        aparicionEnemigos = 1;
        contadorTiempo = 0;
        botonJugar.SetActive(false);

    }

    //M�todo que realizar� determinadas acciones al finalizar el juego (funci�n a�adida directamente en Unity)
    public void FinJuego()
    {
        tituloTexto.text = "HAS PERDIDO"; //Actualizar� el texto de la variable "Titulo" y lo imprimir�
        velocidad = 0; //Parar� el juego, poniendo la velocidad a 0
        aparicionEnemigos = 10000000; //Valor muy alto para que no genere enemigos tras finalizar el juego
        botonJugar.SetActive(true); //Aparecer� de nuevo el bot�n de "Jugar"

    }

    //M�todo que actualiza los textos de los contadores
    void ActualizarTextos()
    {
        recordTexto.text = "Record: " + record;
        tiempoTexto.text = "Tiempo: " + (int) contadorTiempo; //Lo cambia a tipo entero al imprimir en pantalla

    }

    //M�todo que actualiza el tiempo del juego y el record
    void ActualizarTiempo()
    {
        if(velocidad>0)
        {
            contadorTiempo = contadorTiempo + Time.deltaTime; //A la variable se le asigna el valor del tiempo de juego transcurrido

            //Condici�n para actualizar el record cada vez que se supere el anterior
            if ((int)contadorTiempo > record)
            {
                record = (int)contadorTiempo;
            }

        }

    }


}
