using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : Singleton<AudioManager>
{
    /*사운드를 내볼거임
     
     * BGM(배경음악)
     * - BGM은 끊기면 안됨 -> 음원이 Loop가 되어야 함
     * - BGM은 2D 사운드로 구현되어야 함 (AudioListener의 위치와 관계없이 재생되어야 함)
     * - BGM은 하나면 재생하면 됨
     
     * SFX(효과음)
     * - 시작지점과 끝 지점을 정할수 있어야 함
     * - 효과음은 3D사운들을 지원해줘야 함
     * - 음원을 재생하는 빈도가 엄청 많음
     * - (Object Pooling 기법을 사용해서 최적화함)
     
     * Audio를 재생하려면
     * AudioSource라는 컴포넌트가 필요함
     * AudioClip을 AudioSource에 끼워넣어서 음원을 재생함
     
     * AudioPlayer라는 오브젝트를 만들거임
     * AudioPlayer에는 AudioSource가 달려있고,
     * AudioSource에 AudioClip을 넣어서 재생하는 방식을 사용할것임
     * 
     * AudioPlayer의 위치를 바꿔주는 동작도 필요함
     */

    /*
     * AudioManager가 해야하는 기능
     * BGM을 재생하거나, 효과음을 재생하는 기능
     */

    [SerializeField] private AudioPlayer audioPlayer = null;
    [SerializeField] private AudioClip bgmClip = null;
    [SerializeField] private AudioClip bgmClip1 = null;
    [SerializeField] private AudioClip sfxClip = null;
    private List<AudioPlayer> audioPlayerList = null;


    private void Awake()
    {
        audioPlayerList = new List<AudioPlayer>();
    }

    private void Start()
    {
        //PlayBgm();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayBgm(bgmClip);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayBgm(bgmClip1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaySfx(sfxClip);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RemoveAll();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAll();
        }
    }


    public void PlayBgm(AudioClip _clip, bool _loop = true, float _pitch = 1f, float _volume = 1f, bool _enable3DSound=false)
    {
        AudioPlayer availabePlayer = null;

        //이제 만들어진, AudioPlayer를 List로 관리할거임
        //그리고 List 안에 있는 AudioPlayer를 하나씩 돌면서
        //IsPlaying() 이게 false인 녀석을 골라서, 걔한테 재생을 시킬거임

        //AudioPlayer를 생성
        //이미 놀고 있는 Player가 있을때는 생성을 안해도 됨
        for (int i = 0; i < audioPlayerList.Count; i++)
        {
            AudioPlayer ap = audioPlayerList[i];
            if (ap.IsBgmPlayer() == true)
            {
                availabePlayer = ap;
                break;
            }
        }
        if (availabePlayer == null)
        {
            GameObject bgmPlayer = Instantiate(audioPlayer.gameObject, transform);
            AudioPlayer playerComponent = bgmPlayer.GetComponent<AudioPlayer>();

            playerComponent.SetIsBgmPlayer(true);

            audioPlayerList.Add(playerComponent);
            availabePlayer = playerComponent;
        }

        /*
         * Clip 끼우고
         * Loop 할지말지 설정해주고
         * Pitch는 어떻게 할지
         * Volume은 어떻게 할지
         * 3D 사운드 킬지 말지
         * 설정 다 된거 같으면 Play() 해주면 됨
         */
        availabePlayer.SetClip(_clip);
        availabePlayer.SetLoop(_loop);
        availabePlayer.SetPitch(_pitch);
        availabePlayer.SetVolume(_volume);

        if (_enable3DSound)
        {
            availabePlayer.Enable3DSound();
        }
        else
        {
            availabePlayer.Disable3DSound();
        }

        availabePlayer.Play();
    }

    public void PlaySfx(AudioClip _clip, bool _loop = false, float _pitch = 1f, float _volume = 1f, bool _enable3DSound = true)
    {
        AudioPlayer availabePlayer = null;

        //이제 만들어진, AudioPlayer를 List로 관리할거임
        //그리고 List 안에 있는 AudioPlayer를 하나씩 돌면서
        //IsPlaying() 이게 false인 녀석을 골라서, 걔한테 재생을 시킬거임

        //AudioPlayer를 생성
        //이미 놀고 있는 Player가 있을때는 생성을 안해도 됨
        for (int i = 0;  i < audioPlayerList.Count; ++i)
        {
            AudioPlayer ap = audioPlayerList[i];
            if (ap.IsPlaying()==false)
            {
                availabePlayer = ap;
                break;
            }
        }
        if (availabePlayer == null)
        {
            GameObject sfxPlayer = Instantiate(audioPlayer.gameObject, transform);
            AudioPlayer playerComponent = sfxPlayer.GetComponent<AudioPlayer>();
            audioPlayerList.Add(playerComponent);

            availabePlayer = playerComponent;
        }

        /*
         * Clip 끼우고
         * Loop 할지말지 설정해주고
         * Pitch는 어떻게 할지
         * Volume은 어떻게 할지
         * 3D 사운드 킬지 말지
         * 설정 다 된거 같으면 Play() 해주면 됨
         */
        availabePlayer.SetClip(_clip);
        availabePlayer.SetLoop(_loop);
        availabePlayer.SetPitch(_pitch);
        availabePlayer.SetVolume(_volume);

        if(_enable3DSound)
        {
            availabePlayer.Enable3DSound();
        }
        else
        {
            availabePlayer.Disable3DSound();
        }
        
        availabePlayer.Play();
    }

    //전체 AudioPlayer들을 싹 정리하는 코드
    public void RemoveAll()
    {
        for (int i = 0;i < audioPlayerList.Count; ++i)
        {
            Destroy(audioPlayerList[i].gameObject);
        }
        audioPlayerList.Clear();
    }
    //전체 재생중인 사운드를 멈추는 코드
    public void StopAll()
    {
        for (int i = 0; i < audioPlayerList.Count; ++i)
        {
            audioPlayerList[i].Stop();
        }
    }
}
