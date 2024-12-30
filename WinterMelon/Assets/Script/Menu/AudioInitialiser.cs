using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsInitializer : MonoBehaviour
{
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    private void Start()
    {
        if (AudioManager.Instance != null)
        {
            // Initialize and assign listeners
            masterSlider.value = AudioManager.Instance.GetMasterLevel();
            sfxSlider.value = AudioManager.Instance.GetSFXLevel();
            musicSlider.value = AudioManager.Instance.GetMusicLevel();

            masterSlider.onValueChanged.AddListener(AudioManager.Instance.SetMasterLevel);
            sfxSlider.onValueChanged.AddListener(AudioManager.Instance.SetSFXLevel);
            musicSlider.onValueChanged.AddListener(AudioManager.Instance.SetMusicLevel);
        }
    }

    private void Update()
    {
        // Dynamically find sliders in the scene
        if (masterSlider == null) masterSlider = GameObject.Find("Master").GetComponent<Slider>();
        if (sfxSlider == null) sfxSlider = GameObject.Find("SFX").GetComponent<Slider>();
        if (musicSlider == null) musicSlider = GameObject.Find("Music").GetComponent<Slider>();
    }

    private void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        masterSlider.onValueChanged.RemoveAllListeners();
        sfxSlider.onValueChanged.RemoveAllListeners();
        musicSlider.onValueChanged.RemoveAllListeners();
    }
}
