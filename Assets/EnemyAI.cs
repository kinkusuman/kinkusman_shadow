using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SeraializeField] private float chaseRange = 10f;
    [SeraializeField, Range(0, 360)] private float fieldOfView = 120f;
    [SeraializeField] private float chaseSpeed = 4f;
    [SeraializeField] private float acceleration = 2f;

    private NavMeshAgent agent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private float rotationSpeed;
    private Transform target;

    private Rigidbody rb;
   
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        rotationSpeed = Random.Range(30f, 90f);
        rb = GetComponent<Rigidbody>();
        agent.speed = chaseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange && IsTargetInFieldOfView()) ;
        {
            isProvoked = true;
        }
        else if (distanceToTarget > chaseRange)
        {
            isProvoked = false;
        }
        if (isProvoked)
        {
            EngageTarget();
        }
        else
        {
            transform.Rottate(0, rotationSpeed * Time.deltaTime, 0);
            rb.vector3.zero;
        }
    }
    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget <= chaseRange)
        {
            agent.SetDestination(target.position);
        }
    }
}
