using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");

        if(treeHealth <= 0)
        {
            anim.SetTrigger("cut");
            //drop da madeira
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}
