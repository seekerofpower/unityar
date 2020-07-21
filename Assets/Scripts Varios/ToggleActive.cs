using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Para prender y apagar una lista de objetos
/// </summary>
public class ToggleActive : MonoBehaviour
{
    [SerializeField] GameObject[] objects = null; // lista de objetos que podemos asignar en el editor

    // podemos llamar este metodo desde cualquier otro lugar
    public void Toggle()
    {
        // si la lista esta vacia genera error, revisamos no este vacia...
        if (objects != null)
        {
            // ciclo de 0 hasta la longitud de la lista
            for (int i = 0; i < objects.Length; i++)
            {   
                // si el objeto existe, obtenemos su estado activo, lo invertimos, y lo aplicamos
                objects[i]?.SetActive(!objects[i].activeSelf);
            }
        }
    }
}