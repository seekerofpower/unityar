using UnityEngine;

/// <summary>
/// Un MonoBehaviour que funciona como singleton.
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    public static T singleton = null;
    [SerializeField] private protected bool destroyGameObject = true;
    [SerializeField] private protected bool dontDestroyOnLoad = true;
    
    private void Awake()
    {
        // SINGLETON
        if (singleton != null && singleton != this)
        {
            if (destroyGameObject)
            {
                Destroy(gameObject);
                
            }
            else
            {
                Destroy(this);
            }
            Debug.Log("Class can only have one instance!");
        }
        else
        {
            singleton = (T)this;
        }
        
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }

        OnAwake();
    }

    protected virtual void OnAwake() {}
}

// AWAKE
// > logica de singleton (de la clase padre)
// > OnAwake (de la clase derivada)
// START