using UnityEngine.Audio;
using UnityEngine;
using System;


public class AudioController : MonoBehaviour
{
    public static AudioController instance = null;
    [SerializeField] private AudioSource trackSource = null;
    [SerializeField] private AudioSource sfxSource = null;


    [SerializeField] private AudioClip[] tracks = null;


    [SerializeField] private float[] modeVolumes = null;
    [SerializeField] private float[] pitchVolumes = null;

    public enum VOLUME_MODE { MINIMAL, NORMAL, HIGH }
    public enum PITCH_MODE { MINIMAL, NORMAL, HIGH }

    public enum TRACK { MENU, GAMEPLAY }


    #region UNITY_CALLS
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
     
    }

    private void Update()
    {
       
    }
    #endregion

    #region PUBLIC_METHODS
    public void SetVolumeInstant(int mode)
    {
        trackSource.volume = modeVolumes[mode];
    }

    public void SetTrack(int track)
    {
        trackSource.clip = tracks[track];
        trackSource.Play();
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f, float pitch = 1.0f)
    {
        sfxSource.volume = volume;
        sfxSource.pitch = pitch;

        sfxSource.PlayOneShot(clip);
    }
    #endregion

    #region PRIVATE_METHODS
    private void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopMusic()
    {
        trackSource.Stop();
    }

    public void SwitchMusic(bool status)
    {
        if (status)
        {
            trackSource.Play();
        }
        else
        {
            if (trackSource.isPlaying)
            {
                trackSource.Pause();
            }
            else
            {
                trackSource.Stop();
            }
        }


    }
    #endregion
}

