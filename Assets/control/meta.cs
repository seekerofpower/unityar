using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meta : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.GetComponent<bala>() != null)
        {
            Debug.Log("INTRO");
        }
        else
        {
            Debug.Log("NO es una bala");
        }
        
        
         
    }
}
