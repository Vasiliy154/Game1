using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ������������ �������� �������� ������
    public float sprintSpeedMultiplier = 2f; // ��������� �������� ��� �������
    public float acceleration = 10f; // ���������
    public Camera playerCamera; // ������ �� ������
    private float currentSpeed = 0f; // ������� �������� ������

    void Update()
    {
        // ��������� ����� �� ������������
        float horizontal = Input.GetAxis("Horizontal"); // A/D ��� ������� �����/������
        float vertical = Input.GetAxis("Vertical"); // W/S ��� ������� �����/����

        // ��������� ����������� ������ � ������ �� ������
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        // ������� ������������ ������������
        forward.y = 0;
        right.y = 0;

        // ������������ ��������
        forward.Normalize();
        right.Normalize();

        // �������� ������� ��������
        Vector3 movement = (forward * vertical + right * horizontal).normalized;

        // ���� ���� ����, ����������� ������� ��������
        if (movement.magnitude > 0)
        {
            currentSpeed += acceleration * Time.deltaTime; // ����������� ��������
            currentSpeed = Mathf.Clamp(currentSpeed, 0, moveSpeed); // ������������ ������������ ��������

            // �������� ������� ������� Shift ��� �������
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed *= sprintSpeedMultiplier; // ����������� �������� ��� �������
            }
        }
        else
        {
            currentSpeed = 0; // ���������� ��������, ���� ��� �����
        }

        // ����������� ������ � ������ ������� ��������
        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);
    }
}

