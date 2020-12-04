using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwProyectil : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 8f);
        gameObject.transform.Translate(new Vector3(0.9f, 0f, 0f));
    }
    void OnTriggerEnter(Collider PwProyectil)
    {
        if(PwProyectil.gameObject.tag == "Escudo")
        {
            Destroy(gameObject);
        }
    }
}
