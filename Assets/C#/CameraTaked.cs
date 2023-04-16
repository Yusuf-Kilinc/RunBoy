using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTaked : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float chaseSpeed = 5;
   // public CharactherMovement Characther;


    void Start()
    {
        //if (!target)
        //{
        //    target = GameObject.FindWithTag("Player").transform;
        //}
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!target)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, chaseSpeed * Time.deltaTime);
        offset = new Vector3(7, 7, 0);
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, chaseSpeed * Time.deltaTime);

        //  if (Characther.WideCamera == true)
        //  {
        //     offset = new Vector3(8, 10, 0);
        //     transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, chaseSpeed * Time.deltaTime);
        //  }
        //  else
        //   {

        //    }
    }
}
