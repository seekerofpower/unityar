using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physics : MonoBehaviour
{
    Rigidbody rb = null;
    [SerializeField] Transform explosionPos;
    // Start is called before the first frame update
    void Start()
    {
        rb =gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space) )
         explode();

    }
    void explode()
    {
        rb.AddExplosionForce(1,explosionPos.position,10);
    }
}
