using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ManagerPwPlayer : MonoBehaviour
{
    public GameObject[] PowerUps;
    public GameObject Imagen_Item, imgtxt;
    public GameObject escudo;
    bool escudoAct = false;
    int x = 4;

    float timer = 3.0f;
    void Start()
    {
        escudo.SetActive(false);
    }
    void Update()
    {
        float Posx = gameObject.transform.position.x;
        float Posy = gameObject.transform.position.y;
        float Posz = gameObject.transform.position.z;
        Quaternion rotation = new Quaternion();
        Vector3 positionObstaculo = new Vector3(Posx, Posy, Posz);

        switch (x)
        {
            case 0:
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("4");
                imgtxt.SetActive(false);
                if (Input.GetKey("x"))
                {
                    Instantiate(PowerUps[0], positionObstaculo, rotation);
                    x = 4;
                }
                break;
            case 1:
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("3");
                imgtxt.SetActive(false);
                if (Input.GetKey("x"))
                {
                    Instantiate(PowerUps[1], positionObstaculo, rotation);
                    x = 4;
                }
                break;
            case 2:
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("2");
                imgtxt.SetActive(false);
                if (Input.GetKey("x"))
                {
                    Instantiate(PowerUps[2], positionObstaculo, rotation);
                    escudo.SetActive(true);
                    escudoAct = true;
                    Debug.Log(escudoAct);
                    x = 4;
                }
                break;
            case 3:
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("3");
                imgtxt.SetActive(false);
                if (Input.GetKey("x"))
                {
                    Instantiate(PowerUps[1], positionObstaculo, rotation);
                    x = 4;
                }
                break;
            case 4:
                imgtxt.SetActive(true);
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("0");
                break;
        }

        if(escudoAct == true && x == 4)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
            if (timer <= 0)
            {

                //Debug.Log("Etapa3");

                timer = 3;
                escudo.SetActive(false);
                escudoAct = false;
            }
        }
    }


    void OnTriggerEnter(Collider Colider)
    {
        if (Colider.gameObject.tag == "PoweUp")
        {
            Debug.Log("hola");
            x = Random.Range(0, 3);
            Debug.Log(x);
            if(x == 4)
            {
                x = 0;
            }
        }

    }
}


