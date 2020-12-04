using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwCharco : MonoBehaviour
{

    private void OnCollisionEnter(Collision PwCharco)
    {
      /*  if(PwCharco.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
      */
        if (PwCharco.gameObject.tag == "Escudo")
        {
            Destroy(gameObject);
        }
    }
}
