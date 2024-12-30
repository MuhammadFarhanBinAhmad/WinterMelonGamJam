using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_movementTutorial;
    [SerializeField]
    private GameObject m_goalTutorial;

    private static bool m_runOnce = false; // Only first playthrough of the session has the tutorial

    private void Start() {
        if (m_runOnce) {
            m_movementTutorial.SetActive(false);
        }
        else {
            m_runOnce = true;    
        }
    }

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
        
        yield return new WaitForSeconds(12f);
        
        m_goalTutorial.SetActive(false);
    }
}
