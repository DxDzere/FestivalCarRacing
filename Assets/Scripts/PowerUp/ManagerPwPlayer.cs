using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ManagerPwPlayer : MonoBehaviour
{
    public GameObject[] PowerUps;
    public GameObject imageItem,      Imagen_Item;
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
                imageItem.GetComponent<TextMeshProUGUI>().text = "Charco";
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("4");
                if (Input.GetKey("x"))
                {
                    Instantiate(PowerUps[0], positionObstaculo, rotation);
                    x = 4;
                }
                break;
            case 1:
                imageItem.GetComponent<TextMeshProUGUI>().text = "Proyectil";
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("3");
                if (Input.GetKey("x"))
                {
                    Instantiate(PowerUps[1], positionObstaculo, rotation);
                    x = 4;
                }
                break;
            case 2:
                imageItem.GetComponent<TextMeshProUGUI>().text = "Escudo";
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("2");
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
                imageItem.GetComponent<TextMeshProUGUI>().text = "Tele-Proyectil";
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("3");

                //
                //
                break;
            case 4:
                imageItem.GetComponent<TextMeshProUGUI>().text = "No item";
                Imagen_Item.GetComponent<Image>().sprite = Resources.Load<Sprite>("0");
                break;
        }

        if(escudoAct == true && x == 4)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Debug.Log("Etapa3");
                escudo.SetActive(false);
                timer = 3;
            }
        }
    }


    void OnTriggerEnter(Collider Colider)
    {
        if (Colider.gameObject.tag == "PoweUp")
        {
            Debug.Log("hola");
            x = Random.Range(0, 4);
            Debug.Log(x);
        }

    }
}


