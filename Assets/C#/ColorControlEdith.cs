using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class ColorControlEdith : MonoBehaviour
{
    public Material ColorContMat;
    public Material TrapContMat;
    public Color Norcolors;
    public Color TrapColor;
    public GameObject NormalCube;
    public GameObject TrapCube;
    public GameObject FocusCube;

    public GameObject VecNormal;
    public GameObject VecTrap;
    public GameObject VecFocus;

    GameObject Characther;
    float friendColor;
    float EnemyColor;

    // Start is called before the first frame update
    void Start()
    {
        Characther = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Rot = new Vector3(this.transform.rotation.x, 90, this.transform.rotation.z);

        float Mesafe = Vector3.Distance(this.transform.position, Characther.transform.position);

        if (Mesafe < 10)
        {
            Instantiate(NormalCube, VecNormal.transform.position, Quaternion.EulerAngles(this.transform.rotation.x, 100, this.transform.rotation.z));
            Instantiate(TrapCube, VecTrap.transform.position, Quaternion.EulerAngles(this.transform.rotation.x, 100, this.transform.rotation.z));
            Instantiate(FocusCube, VecFocus.transform.position, Quaternion.identity);
            friendColor = Random.Range(0, 6);
            EnemyColor=Random.Range(0, 6); 


            ColorContMat.color = Norcolors;
            ColorContMat.color = TrapColor;

        }


        #region Colors

        #region FriendColors
        if (friendColor == 1)
        {
            Norcolors = Color.white;
        }
        if (friendColor == 2)
        {
            Norcolors = Color.yellow;
        }
        if (friendColor == 3)
        {
            Norcolors = Color.blue;
        }
        if (friendColor == 4)
        {
            Norcolors = Color.black;
        }
        if (friendColor == 5)
        {
            Norcolors = Color.green;
        }
        #endregion

        #region TrapColors
        if (EnemyColor == 1)
        {
            TrapColor = Color.yellow;
        }
        if (EnemyColor == 2)
        {
            TrapColor = Color.white;
        }
        if (EnemyColor == 3)
        {
            TrapColor = Color.green;
        }
        if (EnemyColor == 4)
        {
            TrapColor = Color.blue;
        }
        if (EnemyColor == 5)
        {
            TrapColor = Color.black;
        }
        #endregion

        #endregion
    }
}
