using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    [SerializeField] GameObject balaPrefab = null;
    [SerializeField] float muzzleForce =100;
    [SerializeField] float muzzleTorque= 10;

    [SerializeField] Transform apuntador;

    // Start is called before the first frame update
    void Start()
    {
       //InvokeRepeating(nameof(Fire),1,1); 
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            charge();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Fire();
            muzzleForce = 0;
        }
        Apuntador();
    }

    private void Apuntador()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.up, out hit,15f))
        {
            Debug.Log(hit.collider.gameObject.name + hit.distance);
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.up)*hit.distance,Color.red);
            apuntador.position = hit.point;
        }
        //guardar una cuenta de tiempo 

    }
    void charge()
    {
        muzzleForce+=10 * Time.deltaTime;
    }
    void Fire()
    {   
        GameObject obj = Instantiate(
            balaPrefab
            ,gameObject.GetComponentInChildren<Transform>().position
            ,Quaternion.identity);

        Rigidbody rigidbody =  obj.GetComponent<Rigidbody>();
        //emparentar bala al cañon para que estén alineados
        obj.transform.SetParent(transform);
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.SetParent(null);
        //APLICAR FUERZA
        rigidbody.AddForce(gameObject.transform.up * muzzleForce,ForceMode.Impulse);
        rigidbody.AddTorque(gameObject.transform.up* muzzleTorque);
    }
}
