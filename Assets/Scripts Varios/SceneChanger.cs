using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Una clase para cambiar escenas.
/// </summary>
public class SceneChanger : SingletonBehaviour<SceneChanger>
{
    [SerializeField]
    private KeyCode key = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log("press");
            LoadNext();
        }
    }

    /// <summary>
    /// Carga una escena en base a su build index.
    /// </summary>
    /// <param name="buildIndex">El numero de la escena en la configuracion de build settings</param>
    /// <param name="mode">Si carga sencillo o aditivo</param>
    public void LoadScene(int buildIndex, LoadSceneMode mode)
    {
        SceneManager.LoadSceneAsync(buildIndex, mode);
    }

    /// <summary>
    /// Carga una escena en base a su nombre.
    /// </summary>
    /// <param name="sceneName">El nombre de la escena.</param>
    /// <param name="mode">Si carga sencillo o aditivo</param>
    public void LoadScene(string sceneName, LoadSceneMode mode)
    {
        SceneManager.LoadSceneAsync(sceneName, mode);
    }

    /// <summary>
    /// Carga una escena.
    /// </summary>
    /// <param name="sceneName">El objeto de la escena.</param>
    /// <param name="mode">Si carga sencillo o aditivo</param>
    public void LoadScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.LoadSceneAsync(scene.buildIndex, mode);
    }

    public void LoadNext(bool wrap = false)
    {
        int activeIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeIndex != SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadSceneAsync(activeIndex + 1);
        }
        else
        {
            if (wrap)
                SceneManager.LoadSceneAsync(0); // cargar la primera escena.
            else
                Debug.LogWarning("Ya estas en la ultima escena");
        }
    }

    public void LoadPrevious(bool wrap = false)
    {
        int activeIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeIndex != 0)
        {
            SceneManager.LoadSceneAsync(activeIndex - 1);
        }
        else
        {
            if (wrap)
                SceneManager.LoadSceneAsync(SceneManager.sceneCountInBuildSettings - 1); // cargar la ultima escena.
            else
                Debug.LogWarning("Ya estas en la primera escena");
        }
    }

    public void Reload()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}