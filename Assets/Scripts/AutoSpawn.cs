// using UnityEngine;
// using System.Collections; // Đảm bảo thêm namespace này

// public class AutoSpawn : MonoBehaviour
// {
//     public GameObject objectToSpawn;
//     public Transform spawnPoint;
//     public float spawnInterval = 4f;

//     private void Start()
//     {
//         // Bắt đầu coroutine để spawn object tự động
//         StartCoroutine(SpawnObjectRepeatedly());
//     }

//     IEnumerator SpawnObjectRepeatedly()
//     {
//         while (true)
//         {
//             // Đợi một khoảng thời gian
//             yield return new WaitForSeconds(spawnInterval);

//             // Spawn object tại vị trí spawnPoint
//             Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
//         }
//     }
// }
using UnityEngine;
using System.Collections;

public class AutoSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public float spawnInterval = 4f;

    private void Start()
    {
        // Bắt đầu coroutine để spawn object tự động
        StartCoroutine(SpawnObjectRepeatedly());
    }

    IEnumerator SpawnObjectRepeatedly()
    {
        int spawnCount = 0;

        while (true)
        {
            // Đợi một khoảng thời gian
            yield return new WaitForSeconds(spawnInterval);

            // Spawn object tại vị trí spawnPoint với tên đã đặt
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            spawnedObject.name = "DefaultObject";

            // Tăng số lần spawn để tạo tên mới cho lần tiếp theo
            spawnCount++;
        }
    }
}
