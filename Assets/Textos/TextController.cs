using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // necesario para accesar a los textos
using UnityEngine.Events; // necesario para crear eventos

/// <summary>
/// Para controlar textos
/// </summary>
public class TextController : MonoBehaviour
{
    [SerializeField] GameObject obj = null; // el objeto al que vamos a manipular, asignable en el editor
    RectTransform rect = null; // el componente transform del objeto a manipular
    Text textMesh = null; // el componente de texto del objeto a manipular
    [SerializeField] TextObject textObject = null; // nuestro objeto que contiene el texto que usaremos
    [SerializeField] float speed = 1; // la velocidad de movimiento
    [SerializeField] Color color = Color.white; // el color del texto

    public UnityEvent onTextAway;
    public int count;
    public int max =10000;
    // Start is called before the first frame update
    void Start()
    {
        // si el objeto esta vacio, automaticamente asignar el objeto en el que esta el script
        if (obj == null) obj = gameObject;

        // obtener y guardar  el Component RectTransform de el objeto
        rect = obj.GetComponent<RectTransform>();

        // obtener y guardar el Componente de texto del objeto
        textMesh = obj.GetComponent<Text>();

        // asignar las propiedades
        SetTextProperties();

        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(count<max)
        {
            count++; //incrementa la cuenta
            Move(); // cada cuadro movemos el texto   
        }
        else if(count==max)
        {
            count++;
            onTextAway?.Invoke();
        }
        
        
    }

    public void Move()
    {
        // movemos el texto 
        rect.Translate(0, speed * Time.deltaTime, 0, Space.Self);                
        // en el eje x, no movemos
        // en el eje y, multiplicamos la velocidad por el tiempo entre cuadros, para que sea independiente de la velocidad de la compu
        // en el eje z, no movemos
        // le decimos que use los ejes locales, no globales

        

    }

    [ContextMenu(nameof(SetTextProperties))] // con esto podemos dar click derecho sobre el componente y ejecutar
    public void SetTextProperties()
    {
        // asignamos el texto
        textMesh.text = textObject.text;

        // asignamos el color
        textMesh.color = color;
    }
}