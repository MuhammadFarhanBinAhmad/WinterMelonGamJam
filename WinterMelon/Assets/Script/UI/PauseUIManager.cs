using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUIManager : MonoBehaviour
{

    public Animator _Animator;
    bool is_Paused;
    public AudioSource _AudioSound;

    public AudioClip m_MouseOnEnterSound;
    public AudioClip m_MouseOnClickSound;
    public AudioClip m_ExplosionExit;
    private void Start()
    {
        _AudioSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (is_Paused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void WhenMouseEnter()
    {
        _AudioSound.clip = m_MouseOnEnterSound;
        _AudioSound.Play();
    }
    void MouseClickSound()
    {
        _AudioSound.clip = m_MouseOnClickSound;
        _AudioSound.Play();
    }    
    public void PauseGame()
    {
        Time.timeScale = 0; // Pause game logic
        is_Paused = true;

        if (_Animator != null)
            _Animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        _Animator.SetTrigger("OpenPauseMenu");
    }

    public void OpenOptionMenu()
    {
        _Animator.SetTrigger("OpenOptionMenu");
        MouseClickSound();
    }
    public void CloseOptionMenu()
    {
        _Animator.SetTrigger("CloseOptionMenu");
        MouseClickSound();
    }
    public void ConfirmExit()
    {
        _Animator.SetTrigger("OpenExitMenu");
        MouseClickSound();
    }
    public void CloseConfirmExit()
    {
        _Animator.SetTrigger("CloseExitMenu");
        MouseClickSound();
    }
    public void ExitGame(string scene)
    {
        StartCoroutine(ExitingGame(scene));
        MouseClickSound();
        _Animator.SetTrigger("ExitGame");
        Time.timeScale = 1;

    }
    IEnumerator ExitingGame(string scene)
    {
        yield return new WaitForSeconds(.5f);
        _AudioSound.clip = m_ExplosionExit;
        _AudioSound.Play();
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(scene);

    }
    public void ChangeLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1; // Resume game logic
        is_Paused = false;
        MouseClickSound();
        _Animator.SetTrigger("ClosePauseMenu");

    }
}
