using UnityEngine;

public class TreeObj : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;

    public void OnHit()
    {
        treeHealth--;

        anim.SetTrigger("isHit");

        if (treeHealth <= 0)
        {
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, spawnPoint.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f), 0f), Quaternion.identity); //Instancia o prefab da madeira na posição da arvore
            }

            anim.SetTrigger("cut"); //drop da madeira
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        {
            OnHit();
        }
    }
}
