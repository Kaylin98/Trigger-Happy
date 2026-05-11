using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] [Range(0f, 1f)] float musicVolume = 0.3f; // subtle, sits in background

    [Header("Pickups")]
    [SerializeField] AudioClip weaponPickupClip;
    [SerializeField] [Range(0f, 1f)] float weaponPickupVolume = 0.7f;
    [SerializeField] AudioClip ammoPickupClip;
    [SerializeField] [Range(0f, 1f)] float ammoPickupVolume = 0.5f; // less important than weapon pickup

    [Header("UI")]
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] [Range(0f, 1f)] float gameOverVolume = 0.8f;
    [SerializeField] AudioClip winClip;
    [SerializeField] [Range(0f, 1f)] float winVolume = 0.8f;

    [Header("Enemies")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f, 1f)] float explosionVolume = 0.6f; // frequent sound, keep moderate

    AudioSource musicSource;
    AudioSource sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.spatialBlend = 0f;
        sfxSource.spatialBlend = 0f;

        musicSource.volume = musicVolume;
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayWeaponPickup() => PlaySFX(weaponPickupClip, weaponPickupVolume);
    public void PlayAmmoPickup() => PlaySFX(ammoPickupClip, ammoPickupVolume);
    public void PlayGameOver() => PlaySFX(gameOverClip, gameOverVolume);
    public void PlayWin() => PlaySFX(winClip, winVolume);
    public void PlayExplosion() => PlaySFX(explosionClip, explosionVolume);
}