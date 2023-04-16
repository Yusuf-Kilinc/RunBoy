using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftDown : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
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

        Player.GetComponent<MainCharactherCode>().leftTrue = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Player.GetComponent<MainCharactherCode>().leftTrue = false; 
    }
}
