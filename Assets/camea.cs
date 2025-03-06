using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // ���������������� ����
    public Transform playerBody; // ������ �� ������ ������
    private float xRotation = 0f; // ���� �������� �� ��� X

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ������ ������ � ������������� ��� � ������ ������
    }

    void Update()
    {
        // ��������� ����� ����
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ������� ������ �� ��� Y
        playerBody.Rotate(Vector3.up * mouseX);

        // ����������� ���� �������� �� ��� X
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // ����������� ���� �������

        // ���������� �������� � ������
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

