using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // necesario para crear eventos

public class LogFPS : MonoBehaviour
{
    int count; // la cuenta de cuadros
    float accumulated; // la suma total de tiempo
    public UnityAction<float> cadaSesentaCuadros; // evento

    // Start is called before the first frame update
    void Start()
    {
        // iniciamos nuestras variables en 0
        count = 0;
        accumulated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LogFramesPerSecond();
    }

    // Escribe el cuadro actual, el tiempo que tardo en generarse, y el tiempo acumulado
    // tambien emite 
    void LogFramesPerSecond()
    {
        // suma 1 a nuestra cuenta de cuadros
        count++; 

        // suma el tiempo que tardo en generarse al tiempo acumulado
        accumulated += Time.deltaTime;

        // si la cuenta es divisible por 60 sin tener remanente, es decir, cada 60 cuadros, entonces...
        if (count % 60 == 0)
        {
            // invoca evento enviando la suma de 
            cadaSesentaCuadros?.Invoke(accumulated);

            // manda la informacion a que aparezca en la consola
            Debug.Log($"{count} - {Time.deltaTime} - {accumulated}");
        }
    }
}
