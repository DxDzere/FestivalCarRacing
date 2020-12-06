using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class VerificadorVuelta : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] CheckPoints;
    public int VueltaN;
    public bool Mostrar_Parcial, MostrarVuelta;
    string[] Parcial;
    public GameObject Text;
    public GameObject[] TParcial;
    private bool FinalPartido = false;

    private void Start()
    {
        //AQUI SE DEBE PONER LA CANTIDAD QUE TENGA CADA PISTA.
        //TEMPORALMENTE PONDREMOS 3 CHECPOINTS
        CheckPoints = new bool[4];
        Parcial = new string[4];
        //TParcial = new GameObject[4];
        for (int i = 0; i < 4; i++) Parcial[i] = "";
        VueltaN = 0;
    }

    private void Update()
    {
        if (FinalPartido == false)
        {
            if (VueltaN <= 3)
            {
                Text.GetComponent<TextMeshProUGUI>().text = VueltaN + "/3";
            }
            else
            {
                Text.GetComponent<TextMeshProUGUI>().text = "fin";
                TParcial[VueltaN - 1].GetComponent<TextMeshProUGUI>().text = TIEMPO.CopiaTiempo;
                FinalPartido = true;
            }

            if (Mostrar_Parcial == true)
            {
                Mostrar_Parcial = false;
                if (Parcial[VueltaN] == "" && VueltaN > 0)
                {
                    TParcial[VueltaN].GetComponent<TextMeshProUGUI>().text = TIEMPO.CopiaTiempo;
                    TParcial[VueltaN].SetActive(true);
                    TParcial[VueltaN].GetComponent<Animator>().Rebind();
                }
            }

            if (MostrarVuelta == true)
            {
                MostrarVuelta = false;
                if (VueltaN > 0)
                {
                    Text.GetComponent<Animator>().SetTrigger("Vuelta");
                }
                if (VueltaN > 1)
                {
                    TParcial[VueltaN - 1].GetComponent<TextMeshProUGUI>().text = TIEMPO.CopiaTiempo;
                    TParcial[VueltaN - 1].SetActive(true);
                    TParcial[VueltaN - 1].GetComponent<Animator>().Rebind();
                }
            }
        }

    }

    public void Reset()
    {
        for(int i = 0; i < 4; i++)
        {
            CheckPoints[i] = false;
        }
    }
}
