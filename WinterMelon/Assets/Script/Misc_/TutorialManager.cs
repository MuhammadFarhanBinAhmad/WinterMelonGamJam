using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_movementTutorial;
    [SerializeField]
    private GameObject m_goalTutorial;

    private void Update() {
        if (m_movementTutorial.activeSelf) {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
                StartCoroutine(ShowGoalTutorial());
            }
        }
    }

    private IEnumerator ShowGoalTutorial() {
        yield return new WaitForSeconds(3f);
        
        m_movementTutorial.SetActive(false);
        m_goalTutorial.SetActive(true);
        
        yield return new WaitForSeconds(8f);
        
        m_goalTutorial.SetActive(false);
    }
}
