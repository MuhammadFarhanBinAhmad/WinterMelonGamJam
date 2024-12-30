using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction when changing scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void SetMasterLevel(float _volume)
    {
        masterMixer.SetFloat("MasterParam", Mathf.Log10(_volume) * 20);
    }

    public float GetMasterLevel()
    {
        float volume;
        masterMixer.GetFloat("MasterParam", out volume);
        volume = Mathf.Pow(10, volume / 20);

        return volume;
    }

    public void SetSFXLevel(float _volume)
    {
        masterMixer.SetFloat("SFXParam", Mathf.Log10(_volume) * 20);
    }

    public float GetSFXLevel()
    {
        float volume;
        masterMixer.GetFloat("SFXParam", out volume);
        volume = Mathf.Pow(10, volume / 20);

        return volume;
    }

    public void SetMusicLevel(float _volume)
    {
        masterMixer.SetFloat("MusicParam", Mathf.Log10(_volume) * 20);
    }

    public float GetMusicLevel()
    {
        float volume;
        masterMixer.GetFloat("MusicParam", out volume);
        volume = Mathf.Pow(10, volume / 20);

        return volume;
    }
}
