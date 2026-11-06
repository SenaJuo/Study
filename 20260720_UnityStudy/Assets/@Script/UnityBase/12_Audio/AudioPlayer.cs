using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource = null;
    private bool isBgmPlayer = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void SetLoop(bool _loop)
    {
        audioSource.loop = _loop;
    }

    public void SetClip(AudioClip _clip)
    {
        audioSource.clip = _clip;
    }

    public void SetVolume(float _volume)
    {
        audioSource.volume = _volume;
        if (_volume > 1f)
        { 
            _volume = 1f;
        }
        else if (_volume < 0f)
        {
            _volume = 0f;
        }
    }

    public void SetPitch(float _pitch)
    {
        audioSource.pitch = _pitch;
        if (_pitch > 3f)
        {
            _pitch = 3f;
        }
        else if( _pitch < 0f)
        {
            _pitch = 0f;
        }
    }

    public void Enable3DSound()
    {
        audioSource.spatialBlend = 1f;
    }

    public void Disable3DSound()
    {
        audioSource.spatialBlend = 0f;
    }

    public bool IsPlaying()
    {
        //Debug.Log(audioSource.isPlaying);
        return audioSource.isPlaying;
    }

    public void SetPosition(Vector3 _position)
    {
        transform.position = _position;
    }

    public bool IsBgmPlayer()
    {
        return isBgmPlayer;
    }

    public void SetIsBgmPlayer(bool _value)
    {
        isBgmPlayer = _value;
    }
}
