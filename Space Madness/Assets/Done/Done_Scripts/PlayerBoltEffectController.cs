using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerBoltEffectController : MonoBehaviour
{
    public GameObject boltExmplosion;

    void Start() { }
    void Update() { }
    void OnTriggerEnter(Collider other)
    {
        if (other.name.StartsWith("Asteroid_Ice_0") || other.CompareTag("EnemyShip"))
            if (boltExmplosion != null)
            {
                Instantiate(boltExmplosion, transform.position, transform.rotation);
            }
    }
}

