using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    GameObject BulletPrefab;
    Transform FirePosition;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletPrefab, FirePosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.right * 1000);
        }
    }
}
