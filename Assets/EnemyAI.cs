using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float chaseRange = 10f;
    [SerializeField, Range(0, 360)] private float fieldOfView = 120f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float acceleration = 2f;

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
        if (distanceToTarget <= chaseRange && IsTargetInFieldOfView())
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
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            rb.velocity = Vector3.zero;
        }
    }
    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget <= chaseRange)
        {
            agent.SetDestination(target.position);
        }
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = Vector3.Lerp(rb.velocity, direction * agent.speed, Time.deltaTime * acceleration);
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
    private bool IsTargetInFieldOfView()
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Vector3 forward = transform.forward;
        float halfFOV = fieldOfView / 2f;
        float angleToTarget = Vector3.Angle(forward, directionToTarget);
        if (angleToTarget <= halfFOV)
        {
            if (Physics.Raycast(transform.position, directionToTarget, out RaycastHit hit, chaseRange))
            {
                Debug.DrawRay(transform.position, directionToTarget * chaseRange, Color.red);
                if (hit.transform == target)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
