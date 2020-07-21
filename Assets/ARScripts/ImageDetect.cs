using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageDetect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] objetos;
    [SerializeField] string[] nombres;
    void Start()
    {
        var arImage = GetComponent<ARTrackedImage>();
        for (int i =0; i< objetos.Length;i++)
        {
            if(arImage.referenceImage.name == nombres[i])
            {
                Instantiate(objetos[i],transform);    
            }
        }
    }

}
