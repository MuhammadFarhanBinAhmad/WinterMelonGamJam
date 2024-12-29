using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{

    public AudioSource _AudioSound;
    public AudioClip m_MouseOnEnterSound;

    public Animator _Animator;

    public void WhenMouseEnter()
    {
        _AudioSound.clip = m_MouseOnEnterSound;
        _AudioSound.Play();
    }
    public void StartGame()
    {
        _Animator.SetTrigger("StartGame");
    }
    public void MainMenuToOption()
    {
        _Animator.SetTrigger("MainMenuToOption");
    }
    public void OptionToMainMenu()
    {
        _Animator.SetTrigger("OptionToMainMenu");
    }
    public void MainMenuToCredit()
    {
        _Animator.SetTrigger("MainMenuToCredits");
    }
    public void CreditToMainMenu()
    {
        _Animator.SetTrigger("CreditsToMainMenu");
    }
    public void ChangeScene(string scene)
    {
        StartCoroutine(ChangingScene(scene));
    }
    IEnumerator ChangingScene(string scene)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scene);
    }
}
