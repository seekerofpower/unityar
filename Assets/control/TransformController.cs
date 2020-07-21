using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 vetticalOffset;
    //[SerializeField] Transform eje;
    [SerializeField] float velocidad;
    Transform trans = null;
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        
        // SI ES EL TRASNFORM DEL OBEJTO LOCAL
        //transform 
    }

    // Update is called once per frame
    void Update()
    {
        
        //moveConBoton();
        moveConAxis();
        
        
        /*EJEMPLOS
        Transform hijo = trans.GetChild(0);
        Debug.Log(trans.localPosition);
        Debug.Log(trans.localRotation);
        Debug.Log(trans.localScale);


        Debug.Log("Nombre del primer hijo:"+trans.GetChild(0).name);

        Vector3 pos = trans.localPosition;
        Quaternion rot = trans.localRotation;
        Vector3 scale = trans.localScale;

        Debug.Log("Posiciones: "+pos.ToString()+ rot.ToString()+scale.ToString());

        Vector3 rotEuler= rot.eulerAngles;
        */
             /*
        if(Input.GetButtonDown("Horizontal"))
        {
            //trans.SetPositionAndRotation()
            
            //EJE Y POSOSCION GLOBAL O LOCAL
            //trans.Translate();
            trans.localPosition=trans.localPosition + offset;
            // OTRA MANERA
            //trans.localPosition= new Vector3 (trans.localPosition.x,0,trans.localPosition.z );

        }
        if(Input.GetMouseButtonDown(0))
        {
            //trans.eulerAngles = trans.eulerAngles + new Vector3(0,1,0);
            //trans.Rotate(new Vector3(0,1,0));
            //trans.Rotate(0,1,0,Space.World);

            trans.RotateAround(eje.position,eje.up,1);
        }
        /*if(Input.GetAxis("horizontal")<0)
        {
        
            trans.localPosition=trans.localPosition - offset;
        }    */
    
    }

void moveConAxis()
{   
    float deltaX = Input.GetAxis("Horizontal");
    float deltaY = Input.GetAxis("Vertical");
    transform.localPosition = transform.localPosition + (new Vector3(deltaX,deltaY,0) * velocidad * Time.deltaTime);

}
void moveConBoton()
{
       if(Input.GetKey(KeyCode.UpArrow)) // GetAxis("Horizontal") --> regresa un float
        {
           
            trans.localPosition = trans.localPosition + (Vector3.up * velocidad * Time.deltaTime);
           //trans.Translate(trans.up*velocidad,Space.Self); 
           //trans.SetPositionAndRotation();    
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            trans.localPosition = trans.localPosition + (Vector3.down * velocidad * Time.deltaTime);   
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            trans.localPosition = trans.localPosition + (Vector3.left * velocidad * Time.deltaTime);   
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            trans.localPosition = trans.localPosition + (Vector3.right * velocidad * Time.deltaTime);   
        }

}

}
