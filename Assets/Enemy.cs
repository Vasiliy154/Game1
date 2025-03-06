using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // ������ �� ��������� ������
    public float stoppingDistance = 1.5f; // ����������, �� ������� ��������� ����������� �� ������
    private NavMeshAgent navMeshAgent; // ������ �� NavMeshAgent

    void Start()
    {
        // �������� ��������� NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ���������, ���� �� ������ �� ������
        if (player != null)
        {
            // ��������� ���������� �� ������
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // ���� ��������� ��������� ������, ��� stoppingDistance, �������� � ������
            if (distanceToPlayer > stoppingDistance)
            {
                // ������������� ���� ��� NavMeshAgent
                navMeshAgent.SetDestination(player.position);
            }
            else
            {
                // ���������������, ����� ��������� �� ������ ����������
                navMeshAgent.SetDestination(transform.position);
            }
        }
    }
}
