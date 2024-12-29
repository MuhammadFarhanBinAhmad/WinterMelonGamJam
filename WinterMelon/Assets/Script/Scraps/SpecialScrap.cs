using UnityEngine;

public class SpecialScrap : BaseScrap
{
    public GameObject go_Explosion;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Explosion>() != null || other.GetComponent<BaseScrap>() != null)
        {
            Instantiate(go_Explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
    }
}