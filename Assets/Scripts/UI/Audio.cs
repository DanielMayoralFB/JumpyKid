using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    #region Variables
    private static Audio instance;
    private AudioSource source;
    [SerializeField] AudioMixerGroup[] mixers;
    #endregion

    #region Instance
    public static Audio Instance
    {
        get
        {
            return instance;
        }
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if(instance!= null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Manage the music that is sound in the levels and in the menus
    /// </summary>
    private void Update()
    {
        if(SceneManager.GetActiveScene().name.Equals("Scene1") || 
            SceneManager.GetActiveScene().name.Equals("Scene2") ||
            SceneManager.GetActiveScene().name.Equals("Scene3"))
        {
            source.outputAudioMixerGroup = mixers[1];
        }
        else
        {
 
            source.outputAudioMixerGroup = mixers[0];
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Reset song when change between different scene's types
    /// </summary>
    public void resetSong()
    {
        source.Stop();
        source.Play();
    }
    #endregion


}
