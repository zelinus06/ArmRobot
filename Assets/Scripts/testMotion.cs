using UnityEngine;

public class testMotion : MonoBehaviour
{
    public Transform targetObject; // Đối tượng mà chúng ta muốn cánh tay robot chỉ đến
    public float rotationSpeed = 5f; // Tốc độ quay của khớp hinge

    private void Update()
    {
        if (targetObject != null)
        {
            // Xác định hướng từ cánh tay đến đối tượng
            Vector3 directionToTarget = targetObject.position - transform.position;

            // Tính toán góc quay tương ứng với hướng đến đối tượng
            float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            // Tạo một Quaternion từ góc quay và xoay cánh tay theo nó
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
