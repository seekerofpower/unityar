using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb= null;

    [SerializeField] float explosionForce =100;
    [SerializeField] float explosionRadius= 10;

    [SerializeField] GameObject explosionPrefeb;

    [SerializeField] AudioClip clip = null;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        explode();    
    }

    void explode()
    {
        if(clip!= null)
            AudioSource.PlayClipAtPoint(clip,transform.position);
        if(explosionPrefeb!= null)
            Instantiate(explosionPrefeb,transform.position,Quaternion.identity); 
        
        //OBtener todos los colisionadores dentro del radio de la explision
        var collis = Physics.OverlapSphere(transform.position,explosionRadius);
        for(int i =0;i<collis.Length;i++)
        {
            var rigid = collis[i].GetComponent<Rigidbody>();
            if(rigid!=null)
            {
                rigid.AddExplosionForce(explosionForce,transform.position,explosionRadius);
            }
        }

        //rb.AddExplosionForce(explosionForce,transform.position,explosionRadius);
        //destruir la bala
        Destroy(gameObject,0.01f);
    }
}
