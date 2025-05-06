using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private SkeletonAnim animControl;

    private Player player;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);

        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            // chegou no limite de distância do player
            animControl.PlayAnim(2);

        }
        else
        {
            //skeleton se movendo
            animControl.PlayAnim(1);
        }

        float posX = (player.transform.position.x - transform.position.x);
        if (posX < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (posX > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}
