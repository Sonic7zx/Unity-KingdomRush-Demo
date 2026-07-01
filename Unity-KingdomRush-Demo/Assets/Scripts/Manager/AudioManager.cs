using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("AudioSource")]
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;
    [Header("BGM配置")]
    [SerializeField] AudioClip bgmClip;
    [Header("SFX配置")]
    [SerializeField] AudioClip openMenuClip;
    [SerializeField] AudioClip arrowClip;
    [SerializeField] AudioClip GoblinDieClip;
    [SerializeField] AudioClip BarkieDieClip;
    [Header("其他配置")]
    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayBGM();
    }
    public void PlayBGM()
    {
        bgmSource.clip = bgmClip;
        bgmSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void SetBGMVolume(float value)
    {
        bgmSource.volume = value;
    }
    public void SetBGMEnabled(bool isOn)
    {
        bgmSource.mute = !isOn;
    }
    public void SetSFXEnabled(bool isOn)
    {
        sfxSource.mute = !isOn;
    }

    public void PlayOpenMenuSFX() => PlaySFX(openMenuClip);
    public void PlayArrowSFX() => PlaySFX(arrowClip);
    public void PlayGoblinDieSFX() => PlaySFX(GoblinDieClip);
    public void PlayBarkieDieSFX() => PlaySFX(BarkieDieClip);

}
