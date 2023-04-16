using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacther : MonoBehaviour
{
    public GameObject[] charactherPrefabs;
    public Transform spawnPoint;
      public TMP_Text label;
   



    public void Start()
    {
        int SelectCharacther = PlayerPrefs.GetInt("SelectCharacther");
        GameObject prefab = charactherPrefabs[SelectCharacther];
        prefab.SetActive(true);
      //  GameObject clone = Instantiate(prebab, spawnPoint.position, Quaternion.identity);
        label.text = prefab.name;
    }

    //private void Start()
    //{

    //  //  label.text = prebab.name;
    //}


}
