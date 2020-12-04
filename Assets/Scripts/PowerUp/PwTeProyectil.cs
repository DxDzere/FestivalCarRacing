using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwTeProyectil : MonoBehaviour
{
    public GameObject enemigo;
    private Rigidbody rbEnemigo;

    void Start()
    {
        rbEnemigo = GetComponent<Rigidbody>();
        enemigo = GameObject.Find("Enemigoo");
    }
    void Update()
    {
       rbEnemigo.AddForce(enemigo.transform.position - transform.position); 
    }
}
