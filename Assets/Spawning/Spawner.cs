using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // necesario para crear eventos

/// <summary>
/// Una clase para crear otros objetos
/// </summary>
public class Spawner : MonoBehaviour
{
    int count = 0;
    [SerializeField] GameObject prefab = null; // el objeto a crear
    public List<GameObject> Objects {get; private set;} // lista de objetos creados
    int min = -10; // tamaño minimo del volumen donde crear objetos
    int max = 10; // tamaño maximo del volumen donde crear objetos
    public UnityEvent onSpawned; // nuestro evento

    void Start()
    {
        Objects = new List<GameObject>();
    }

    void Update()
    {
        // ejemplo: se crea un objeto cada 60 cuadros
        count++;
        if (count % 60 == 0)
        {
            SpawnRandomly();
        }
    }

    void SpawnRandomly()
    {
        // Generar nueva posicion aleatoria en un cubo de tamaño min-max
        Vector3 position = new Vector3(
            Random.Range(min, max), // la posicion en x
            Random.Range(min, max), // la posicion en y
            Random.Range(min, max)  // la posicion en z
        ); 
        
        // Instanciar nuestro prefab en posicion y guardarlo
        GameObject obj = Instantiate(prefab, position, new Quaternion());

        // Agregar el nuevo objeto a la lista
        Objects.Add(obj);

        // Hacer que el metodo Action de el objeto creado escuche a nuestro evento
        // aqui esta obligado a ser del tipo Spawned o causara error
        onSpawned.AddListener(obj.GetComponent<Spawned>().OnSpawned);

        // AQUI SE PUEDE AGREGAR MAS CODIGO DE CONFIGURACION DEL OBJETO NUEVO

        // Invocar nuestro evento de que hemos creado un objeto nuevo
        onSpawned?.Invoke();
    }
}
