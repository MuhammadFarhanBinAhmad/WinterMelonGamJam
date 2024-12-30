using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{

    public AudioSource _AudioSound;

    public AudioClip m_MouseOnEnterSound;
    public AudioClip m_ExplosionSound;
    public AudioClip m_MouseClickSound;

    public Animator _Animator;

    public void WhenMouseEnter()
    {
        _AudioSound.clip = m_MouseOnEnterSound;
        _AudioSound.Play();
    }

    public void ExplosionSound()
    {
        _AudioSound.clip = m_ExplosionSound;
        _AudioSound.Play();
    }
    public void MainMenuToOption()
    {
        _Animator.SetTrigger("MainMenuToOption");
        _AudioSound.clip = m_MouseClickSound;
        _AudioSound.Play();
    }
    public void OptionToMainMenu()
    {
        _Animator.SetTrigger("OptionToMainMenu");
        _AudioSound.clip = m_MouseClickSound;
        _AudioSound.Play();
    }
    public void MainMenuToCredit()
    {
        _Animator.SetTrigger("MainMenuToCredits");
        _AudioSound.clip = m_MouseClickSound;
        _AudioSound.Play();
    }
    public void CreditToMainMenu()
    {
        _Animator.SetTrigger("CreditsToMainMenu");
        _AudioSound.clip = m_MouseClickSound;
        _AudioSound.Play();
    }
    public void StartGame(string scene)
    {
        StartCoroutine(ChangingScene(scene));
        _Animator.SetTrigger("StartGame");
    }
    IEnumerator ChangingScene(string scene)
    {
        yield return new WaitForSeconds(.5f);
        ExplosionSound();
        yield return new WaitForSeconds(.75f);
        SceneManager.LoadScene(scene);
    }
}
