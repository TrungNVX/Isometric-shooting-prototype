using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviAgentCharacterSample : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public NavMeshAgent m_agent;
    public NavMeshPath meshPath;
    private Vector3 targetPoint;
    private int index;
    public bool isMoveByCode = false;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        m_agent.updateRotation = false;
        // m_agent.updatePosition = !isMoveByCode;
        m_agent.updatePosition = false;
         meshPath = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                m_agent.Warp(transform.position);
                if (isMoveByCode)
                {
                    m_agent.CalculatePath(hit.point, meshPath);
                    index = 1;
                    targetPoint = meshPath.corners[index];
                }
                else
                {
                    m_agent.destination = hit.point;

                }
            }
        }
        if (isMoveByCode)
        {
            if (meshPath.corners.Length > 0)
            {
                for (int i = 0; i < meshPath.corners.Length - 1; i++)
                {
                    Debug.DrawLine(meshPath.corners[i], meshPath.corners[i + 1]);
                }
                // rotate
                Vector3 dir = targetPoint - transform.position;
                if (dir.magnitude > 0.3f)
                {
                    dir.Normalize();
                    Quaternion q = Quaternion.LookRotation(dir, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
                    characterController.Move(transform.forward * Time.deltaTime * 2);
                    if (Vector3.Distance(transform.position, targetPoint) <= 0.4f)
                    {
                        index++;
                        if (index < meshPath.corners.Length)
                        {
                            targetPoint = meshPath.corners[index];

                        }

                    }
                }

            }
        }
        else
            RotateCharacter();
        float speed = m_agent.velocity.magnitude / m_agent.desiredVelocity.magnitude;
        speed = speed * m_agent.speed;
        animator.SetFloat("Speed", speed);

    }

    private void RotateCharacter()
    {
        Vector3 dir = m_agent.steeringTarget - transform.position;
        if(dir.magnitude>0.2f)
        {
            dir.Normalize();
            Quaternion q = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 360);
        }
       
    }
    private void OnAnimatorMove()
    {
        // Update position to agent position
        transform.position = m_agent.nextPosition;
    }
}
