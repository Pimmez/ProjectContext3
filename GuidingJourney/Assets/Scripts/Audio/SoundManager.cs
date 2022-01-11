using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    [Header("Component References")]
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioSource musicSource;

    [Header("Pitch Values")]
    // Random pitch adjustment range.
    public float LowPitchRange = 0.95f;
    public float HighPitchRange = 1.05f;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip _clip)
    {
        effectsSource.clip = _clip;
        effectsSource.Play();
    }

    public void PlayWithPitch(AudioClip _clip)
    {
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
        effectsSource.pitch = randomPitch;
        effectsSource.clip = _clip;
        effectsSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip _clip)
    {
        musicSource.clip = _clip;
        musicSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] _clips)
    {
        int randomIndex = Random.Range(0, _clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        effectsSource.pitch = randomPitch;
        effectsSource.clip = _clips[randomIndex];
        effectsSource.Play();
    }
}