using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodeCode : MonoBehaviour
{
    public GameObject Effect;

    public bool Active = false;

    void Start()
    {
        Effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {
            Effect.SetActive(true);
            Invoke("ActiveTrue", 1.5f);
        }
    }

    void ActiveTrue()
    {
        Effect.SetActive(false);
    }


}
