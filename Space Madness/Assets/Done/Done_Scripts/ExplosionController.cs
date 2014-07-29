using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public GameObject explosionObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyShip") || other.CompareTag("Meteor"))
            Instantiate(explosionObject, transform.position, Quaternion.identity);
    }
}
