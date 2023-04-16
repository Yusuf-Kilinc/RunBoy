using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharactherCode : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    public float Heart = 5;
    public float score;

    Animator anim;
    public Material MainMaterial;


    public List<GameObject> noktalar;
    public GameObject DeathScreen;
    BloodeCode Blood;
    SkinnedMeshRenderer matObje;

    public bool Dance = false;
    public bool Run = false;
    public bool leftTrue = false;
    public bool rightTrue = false;
    public bool Death = false;

    public bool GameStart = false;

    public Text ScoreText;
    public Text Hearttext;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "1")
        {
            score += 1;
            transform.localScale = new Vector3(transform.localScale.x + 5 * Time.deltaTime, transform.localScale.y + 5 * Time.deltaTime, transform.localScale.z + 5 * Time.deltaTime);
            noktalar.Add(other.gameObject);
            Destroy(noktalar[0]);
            noktalar = new List<GameObject>();
        }
        if (other.gameObject.tag == "trap")
        {
            Heart -= 1;
            transform.localScale = new Vector3(transform.localScale.x - 5 * Time.deltaTime, transform.localScale.y - 5 * Time.deltaTime, transform.localScale.z - 5 * Time.deltaTime);
            Blood.Active = true;
            Invoke("BloodEffectCont", 1);
        }
        if (other.gameObject.tag == "Dusme")
        {
            Heart = 0;
        }

        #region Colors Settings
        if (other.gameObject.tag == "Green")
        {
            MainMaterial.color = Color.green;
        }
        if (other.gameObject.tag == "Blue")
        {
            MainMaterial.color = Color.blue;
        }
        if (other.gameObject.tag == "Black")
        {
            MainMaterial.color = Color.black;
        }
        if (other.gameObject.tag == "Turkuaz")
        {
            MainMaterial.color = Color.yellow;
        }
        if (other.gameObject.tag == "Red")
        {
            MainMaterial.color = Color.red;
        }
        if (other.gameObject.tag == "Write")
        {
            MainMaterial.color = Color.white;
        }
        #endregion
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        DeathScreen.SetActive(false);
        //  MainMaterial.color = Color.white;
        Blood.Active = false;
        anim = GetComponent<Animator>();
    }

    void NowMagic()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.5f, transform.localScale.y + 0.5f, transform.localScale.z + 0.5f) * Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (Blood == null)
        {
            Blood = GameObject.FindWithTag("Bloode").GetComponent<BloodeCode>();
        }
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        if(matObje == null)
        {
            matObje=GetComponentInChildren<SkinnedMeshRenderer>();
            MainMaterial = matObje.material;
        }


        if (Death == false)
        {
            Time.timeScale = 1;
            DeathScreen.SetActive(false);

            #region Text Settings
            ScoreText.text = score.ToString();
            Hearttext.text = Heart.ToString();
            #endregion


            #region Run Controller
            if (GameStart == true)
            {
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * MovementSpeed);
                Dance = false;
                Run = true;
            }
            #endregion

            if (GameStart == false)
            {
                Run = false;
                Dance = true;
            }

        }
        else if (Death == true)
        {
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
        }

        #region Heart
        if (Heart >= 5)
        {
            Heart = 5;
        }
        if (Heart <= 0)
        {
            Heart = 0;
            Death = true;
        }
        if (Heart > 0)
        {
            Death = false;
        }
        #endregion

        #region Animations
        if (Run == true)
        {
            anim.SetBool("RUN", true);
        }
        if (Run == false)
        {
            anim.SetBool("RUN", false);
        }
        if (Dance == true)
        {
            anim.SetBool("DANCE", true);
        }
        if (Dance == false)
        {
            anim.SetBool("DANCE", false);
        }
        #endregion
    }
    private void LateUpdate()
    {
        #region Left and Right Controller
        if (leftTrue == true)
        {
            gameObject.transform.Translate(Vector3.left * 5 * Time.deltaTime);
        }
        if (rightTrue == true)
        {
            gameObject.transform.Translate(Vector3.right * 5 * Time.deltaTime);
        }
        #endregion
    }

    public void LeftClick()
    {

        leftTrue = true;
    }

    public void RightClick()
    {

        rightTrue = true;
    }
}
