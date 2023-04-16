using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour,IPointerDownHandler
{
   // MainCharactherCode mcC;
    public GameObject Go;

    public MainCharactherCode Player;

    private void Start()
    {
        Go.SetActive(true);
    }

    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player").GetComponent<MainCharactherCode>();
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Player.GameStart = true;
        Go.SetActive(false);
    }
}
