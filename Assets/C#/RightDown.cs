using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    GameObject Player;

    public void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Player.GetComponent<MainCharactherCode>().rightTrue = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Player.GetComponent<MainCharactherCode>().rightTrue = false;
    }
}
