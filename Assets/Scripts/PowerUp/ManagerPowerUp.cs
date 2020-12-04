using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPowerUp : MonoBehaviour
{
    float timer;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 1f, 0f));
        Destroy(gameObject, 8f);
    }

    void OnTriggerEnter(Collider PowerUp)
    {
        if (PowerUp.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
