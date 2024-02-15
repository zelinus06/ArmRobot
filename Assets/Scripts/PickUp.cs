using System;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    public Transform magnetTransform;
    public string otherCubeName = "DefaultObject";
    public float moveSpeed1 = 1f;
    public float moveSpeed2 = 2f;
    private bool isTransport = false;
    private bool canMove = true;
    public float detectionRadius = 0.5f;
    public bool isDetected = false;
    public Vector3 targetPositions = new Vector3(2.5f, 2.3f, -11f);
    public Vector3 tpPosition = new Vector3(2.5f, 2.3f, -9f);
    // public puzzle otherScript;
    void Start() {
        // Invoke("CallMethodFromOtherScript", 2f);
    }
    void Update()
    {
        // Kiểm tra xem có đối tượng nào ở vị trí targetPosition hay không
        Collider[] colliders = Physics.OverlapSphere(targetPositions, detectionRadius);

        // Nếu có ít nhất một đối tượng
        if (colliders.Length > 1)
        {
            Debug.Log("Có đối tượng ở vị trí " + targetPositions);
            isDetected = true;
        }
        else
        {
            // puzzle();
            Debug.Log("x");
        }
         if (isDetected && canMove)
        {
            MoveTowardsTarget();
        }
        if (isTransport){
            MoveObject();   
        }
        
    }

    void MoveTowardsTarget()
    {
            Vector3 worldPosition = magnetTransform.position;
            Vector3 direction = targetPositions - worldPosition;
            transform.position += direction * moveSpeed1 * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
            {
                // Kiểm tra xem có va chạm với đối tượng khác không
                if (collision.gameObject.name == otherCubeName)
                {
                    Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                    Debug.Log("Có va chạm với " + otherCubeName);
                    canMove = false;
                    // TakeObject();
                        if (otherRigidbody != null)
                        {
                        // Tạo FixedJoint và kết nối nó với Rigidbody của targetCube
                        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                        joint.connectedBody = otherRigidbody;
                            }
                    else
                    {
                        Debug.LogError("Không tìm thấy Rigidbody trên targetCube.");
                        }
                        isTransport = true;
                }
            }
    void MoveObject() {
            Vector3 directionTP = tpPosition - transform.position;
            float distance = directionTP.magnitude;
            if (distance > 0.1f) {
            transform.position += directionTP * moveSpeed2 * Time.deltaTime;
            Debug.Log("moving ");
            }
            else
        {
            // Lấy danh sách các FixedJoint trên object1
            FixedJoint[] fixedJoints = GetComponents<FixedJoint>();
            
            // Duyệt qua mỗi FixedJoint và loại bỏ nó
            foreach (FixedJoint joint in fixedJoints)
            {
                    // Loại bỏ FixedJoint
                    Destroy(joint);
                    canMove = true;
                    isTransport = false;
                    Debug.Log("bỏ ra");
                // }
            }
        }
            
    }
    // void puzzle() {
    //     Debug.Log("hello");
    // }
}   


