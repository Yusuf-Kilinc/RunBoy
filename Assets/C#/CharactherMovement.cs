using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactherMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    [SerializeField] private float RotationSpeed = 500;

    private Touch touch;

    private Vector3 touchDown;
    private Vector3 touchUp;

    private bool dragStarted;
    private bool isMoving;
    
    public Animator anim;
    bool Run;
    public bool Death = false;

    public float score;
    public Text ScoreText;
    public Text Hearttext;
    public bool WideCamera = false;

    public float Heart = 5;
    public List<GameObject> noktalar;
    public GameObject DeathScreen;
    public Material MainMaterial;
    public float LevelFloat;
    public GameObject[] LevelScene;
    public GameObject Edit;
    public GameObject Blood;


    public bool leftTrue = false;
    public bool rightTrue = false;

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
            Blood.SetActive(true);
            Invoke("BloodEffectCont", 1);
        }
        if (other.gameObject.tag == "Dusme")
        {
            Heart = 0;
        }

        if (other.gameObject.tag == "NextLevel")
        {
            LevelFloat = Random.Range(0, 4);
            if (LevelFloat == 0)
            {
                //    Instantiate(LevelScene[2], Edit.transform.position /*transform.position.x, transform.position.y, transform.position.z*/,Quaternion.identity);
                LevelScene[2].transform.position = new Vector3(Edit.transform.position.x + 10, transform.position.y, transform.position.z);
            }
            if (LevelFloat == 1)
            {
                // Instantiate(LevelScene[1], Edit.transform.position /*transform.position.x, transform.position.y, transform.position.z*/, Quaternion.identity);
                LevelScene[1].transform.position = new Vector3(Edit.transform.position.x - 10, transform.position.y, transform.position.z);
            }
            if (LevelFloat == 2)
            {
                //  Instantiate(LevelScene[0], Edit.transform.position /*transform.position.x, transform.position.y, transform.position.z*/, Quaternion.identity);
                LevelScene[0].transform.position = new Vector3(Edit.transform.position.x - 10, transform.position.y, transform.position.z);
            }
            if (LevelFloat == 3)
            {
                //   Instantiate(LevelScene[3], Edit.transform.position /*transform.position.x, transform.position.y, transform.position.z*/, Quaternion.identity);
                LevelScene[3].transform.position = new Vector3(Edit.transform.position.x - 10, transform.position.y, transform.position.z);
            }
        }

        #region Colors
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "uzunkamera")
        {
            WideCamera = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "uzunkamera")
        {
            WideCamera = false;
        }
    }


    void Start()
    {
        score = 0;
        DeathScreen.SetActive(false);
        MainMaterial.color = Color.white;
        Blood.SetActive(false);
    }

    void NowMagic()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.5f, transform.localScale.y + 0.5f, transform.localScale.z+ 0.5f) * Time.deltaTime;
    }

    
    void Update()
    {
        if (Death == false)
        {
            Time.timeScale= 1;
            DeathScreen.SetActive(false);
            ScoreText.text = score.ToString();
            Hearttext.text = Heart.ToString();

            #region Touch Control
            //if (Input.touchCount > 0)
            //{
            //    touch = Input.GetTouch(0);
            //    if (touch.phase == TouchPhase.Began)
            //    {
            //        dragStarted = true;
            //        isMoving = true;
            //        touchDown = touch.position;
            //        touchUp = touch.position;
            //    }
            //}
            //if (dragStarted)
            //{
            //    if (touch.phase == TouchPhase.Moved)
            //    {
            //        touchDown = touch.position;
            //    }
            //    if (touch.phase == TouchPhase.Ended)
            //    {
            //        touchDown = touch.position;
            //        isMoving = false;
            //        dragStarted = false;
            //    }
            //    gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), RotationSpeed * Time.deltaTime);
            //    gameObject.transform.Translate(Vector3.forward * Time.deltaTime * MovementSpeed);
            //    Run = true;
            //}
            //else
            //{
            //    Run = false;
            //}
            #endregion

            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * MovementSpeed);
            Run = true;

            //if (leftTrue == true)
            //{
            //    gameObject.transform.Translate(Vector3.left * 5 * Time.deltaTime);
            //}
            //if (rightTrue == true)
            //{
            //    gameObject.transform.Translate(Vector3.right * 5 * Time.deltaTime);
            //}

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
        if(Run== false)
        {
            anim.SetBool("RUN", false);
        }
        #endregion

    }
    private void LateUpdate()
    {
        if (leftTrue == true)
        {
            gameObject.transform.Translate(Vector3.left * 5 * Time.deltaTime);
        }
        if (rightTrue == true)
        {
            gameObject.transform.Translate(Vector3.right * 5 * Time.deltaTime);
        }
    }

    Quaternion CalculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
        return temp;
    }


    Vector3 CalculateDirection()
    {
        Vector3 temp=(touchDown-touchUp).normalized;
        temp.z = temp.y;
        temp.y = 0;
        return temp;
    }


    public void LeftClick()
    {

        leftTrue = true;
    }

    public void RightClick()
    {

        rightTrue = true;
    }

    public void BloodEffectCont()
    {
        Blood.SetActive(false);
    }

}
