using UnityEngine;

public class MP3Player : MonoBehaviour
{
    public string mp3FileName; 
    private AudioSource audioSource;

    private void OnEnable() {
        SoundActions.JumpToTime += JumpToTime;
        SoundActions.IncrementSound += IncrementSong;
    }

    private void OnDisable() {
        SoundActions.JumpToTime -= JumpToTime;
        SoundActions.IncrementSound -= IncrementSong;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioClip audioClip = Resources.Load<AudioClip>(mp3FileName);

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("MP3 file not found: " + mp3FileName);
        }
    }

    private void IncrementSong()
    {
        if (audioSource.clip != null)
        {
            float timeInSeconds = audioSource.time + 60f;
            timeInSeconds = Mathf.Clamp(timeInSeconds, 0f, audioSource.clip.length);
            audioSource.time = timeInSeconds;
        }
    }


    private void JumpToTime(float timeInSeconds)
    {
        if (audioSource.clip != null)
        {
            timeInSeconds = Mathf.Clamp(timeInSeconds, 0f, audioSource.clip.length);
            audioSource.time = timeInSeconds;
        }
    }
}
