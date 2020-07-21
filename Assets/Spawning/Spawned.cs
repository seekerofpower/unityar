using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawned : MonoBehaviour
{
    [SerializeField] float factor = 1.1f;

    // al momento que el objeto nace esto es llamado por un evento externo
    public void OnSpawned()
    {
        Debug.Log("Spawned");

        // la escala del objeto se multiplica por el factor
        transform.localScale = new Vector3(
            transform.localScale.x * factor,
            transform.localScale.y * factor,
            transform.localScale.z * factor
        );
    }
}