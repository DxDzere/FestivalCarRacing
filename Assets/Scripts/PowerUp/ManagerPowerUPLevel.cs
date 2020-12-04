using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;

public class ManagerPowerUPLevel : MonoBehaviour
{
    public GameObject Pw;
    float timer;
    public Vector3[] posiciones;

    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (timer >= 8)
        {
            for (int i = 0; i < posiciones.Length; i++)
            {
                Instantiate(Pw, posiciones[i], Quaternion.identity);
            }

            timer = 0;
        }

    }
}
