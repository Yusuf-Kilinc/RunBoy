using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneCode : MonoBehaviour
{
    Vector3 hareketYonleri;
    public float hiz = 5;
    public Rigidbody karakterRB;
    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kube")
        {
            
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hareketYonleri = transform.position;

        // hareketYonleri = new Vector3(Input.GetAxis("Horizontal") * hiz * Time.deltaTime, 0, Input.GetAxis("Vertical") * hiz * Time.deltaTime);
        karakterRB.AddForce(hareketYonleri * -2 * Time.deltaTime, ForceMode.Impulse);
        anim.SetBool("FASTRUN", true);
    }
}
