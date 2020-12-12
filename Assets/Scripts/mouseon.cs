using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mouseon : MonoBehaviour, IPointerEnterHandler
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.PlaySound2D("Boton_Opciones");
    }
}
