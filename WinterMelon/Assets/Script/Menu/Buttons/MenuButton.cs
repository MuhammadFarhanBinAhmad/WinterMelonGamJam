using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    public Image b_Arrow;

    public RectTransform rt_Ship;
    RectTransform rt_Button;

    public AudioSource _AudioSound;
    public AudioClip m_MouseOnEnterSound;

    public GameObject m_Projectile;

    private void Start()
    {
        rt_Button = GetComponent<RectTransform>();
    }

    public void WhenMouseEnter()
    {
        b_Arrow.transform.position = new Vector3(b_Arrow.transform.position.x,
                                                transform.position.y,
                                                transform.position.z);

        // Get the direction from the image to the button in Canvas space
        Vector3 direction = rt_Button.position - rt_Ship.position;

        // Calculate the angle to rotate the image
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the image
        rt_Ship.rotation = Quaternion.Euler(0, 0, angle);

        _AudioSound.clip = m_MouseOnEnterSound;
        _AudioSound.Play();
    }
    public void SetAndShootProjectile()
    {
        GameObject go = Instantiate(m_Projectile, rt_Ship.position, rt_Ship.rotation);
        go.SetActive(false);
        go.transform.SetParent(GameObject.Find("Canvas").transform);
        go.GetComponent<MenuProjectile>().targetImage = rt_Button;
        go.SetActive(true);
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
