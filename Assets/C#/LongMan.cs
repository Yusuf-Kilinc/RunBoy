using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LongMan : MonoBehaviour
{
    public GameObject characther;
  

    private void Start()
    {
        characther = GameObject.FindWithTag("Player");
    }



    //private void OnTriggerStay(Collider other)
    //{
    //    // characther.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 2f;
    //    ScoreText.text = score.ToString();
    //    if (other.gameObject.tag == "Player")
    //    {
    //        transform.localScale = new Vector3(transform.localScale.x + 5f, transform.localScale.y + 5f, transform.localScale.z + 5f);
    //        score += 1;
    //    }
    //}
}
