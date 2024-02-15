// using UnityEngine;

// public class LookAtObject : MonoBehaviour
// {
//     public Transform targetObject; // Đối tượng cần nhặt

//     void Update()
//     {
//         if (targetObject != null)
//         {
//             // Dùng LookAt để xoay cánh tay về hướng của đối tượng
//             transform.LookAt(targetObject.position);

//             // Lấy vector trục y của cánh tay (là trục y trong không gian của cánh tay)
//             Vector3 upVector = transform.up;

//             // In ra giá trị vector trục y
//             Debug.Log("Up Vector: " + upVector);
//         }
//     }
// }
// using UnityEngine;

// public class LookAtObject : MonoBehaviour
// {
//     public Transform cubeTransform;
//     public float rotationSpeed = 5f;

//     void Update()
//     {
//         if (cubeTransform != null)
//         {
//             // Xác định hướng từ trụ đến khối cube
//             Vector3 directionToCube = cubeTransform.position - transform.position;

//             // Xác định trục z của trụ
//             Vector3 cylinderUp = transform.up;

//             // Sử dụng Cross Product để xác định trục vuông góc với cả hai trục z và hướng đến khối cube
//             Vector3 cross = Vector3.Cross(cylinderUp, directionToCube);

//             // Xác định góc giữa trục z của trụ và hướng đến khối cube
//             float angle = Mathf.Atan2(cross.magnitude, Vector3.Dot(cylinderUp, directionToCube));

//             // Tạo một Quaternion từ trục và góc
//             Quaternion targetRotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, cross.normalized);

//             // Lerp để làm mềm góc quay
//             transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
//         }
//     }
// }

using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    public Transform targetObject; // Vật cần nhặt

    void Update()
    {
        if (targetObject != null)
        {
            // Xác định hướng từ cánh tay đến vật cần nhặt
            Vector3 directionToTarget = targetObject.position - transform.position;

            Vector3 newDirection = Vector3.RotateTowards(transform.right, directionToTarget, Time.deltaTime * 2f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            // transform.Rotate(90f,0f,0f);
        }
    }
}



