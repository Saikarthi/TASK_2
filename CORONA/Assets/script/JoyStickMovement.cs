using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    //public Transform circle;
    //public Transform outerCircle;

    //Infinity Movement Var
    public  bool joyPadTouch;
    public GameObject JoystickHolder;
    bool downPressed;
    private Vector3 startPos;
    private bool comeFromLeftSide;
    private Vector2 mobileStartPos;
    float ScreenWidth;
    private Vector2 mobileDifference;
    private bool canMove;
    private Vector3 difference;
    public RectTransform JoyStickrect;
    public  float rotationSpeed;
    public  float joystickMovementSpeed;
    private Vector3 joyPadStartPos;
    private Vector3 joyPadStartPos1;
    private int fingerCount;
    public float offsetX;
    public  float offsetY;

    //Player
    GameObject Player;
    public float  movementSpeed;

    private void Start()
    {
        ScreenWidth = Screen.width;
        Player = GameObject.FindGameObjectWithTag("Player");
        joyPadStartPos = JoystickHolder.transform.position;
        joyPadStartPos1 = Vector2.zero;
        JoystickHolder.SetActive(true);
    }
    private void Update()
    {
        InfinityMovement();
      //  InfinityMobileMovement();
        if (canMove)
        {
           // Player.transform.position += transform.up * movementSpeed * Time.deltaTime;
            Debug.Log("Player is moving");
        }
       
    }

    private void InfinityMovement()
    {
        if (joyPadTouch)
        {
            //Touch wont work if it is on the right side
            if (Input.mousePosition.x < ScreenWidth / 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    JoystickHolder.SetActive(true);
                    downPressed = true;
                    startPos = Input.mousePosition;
                    comeFromLeftSide = true;
                    JoystickHolder.transform.position = new Vector3(startPos.x, startPos.y, 0f);
                }

                if (Input.GetMouseButton(0) && downPressed)
                {

                    JoystickHolder.SetActive(true);
                    difference = Input.mousePosition - startPos;//Mouse delta...
                    if (difference.sqrMagnitude < 0.5f)
                        return;
                    else
                    {
                        //Move the player
                        canMove = true;
                       
                      //  float angle = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
                      //  Vector3 targetRotation = new Vector3(0f, 0f, angle + Camera.main.transform.eulerAngles.y);
                      //  transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, -targetRotation, rotationSpeed);
                      Debug.Log(difference);
                      transform.position=new Vector2(difference.x * speed ,difference.y* speed);
                      JoyStickrect.localPosition = new Vector3(transform.up.x + offsetX, transform.up.y + offsetY, 0f) * joystickMovementSpeed;


                    }
                }


                if (Input.GetMouseButtonUp(0))
                {

                    //canMove = false;
                    //joyPadTouch = false;
                    downPressed = false;
                    JoyStickrect.anchoredPosition = joyPadStartPos1;
                    JoystickHolder.transform.position = joyPadStartPos;
                    //also dont show the JoyPadHolder 
                    // JoystickHolder.SetActive(false);
                    canMove = false;
                    comeFromLeftSide = false;



                }
            }
            else
            {
                //Come from left side then movemnet must work.... to make the player comtroller reliable..
                if (comeFromLeftSide && Input.GetMouseButton(0))
                {
                    JoystickHolder.SetActive(true);
                    difference = Input.mousePosition - startPos;//Mouse delta...
                    if (difference.sqrMagnitude < 0.5f)
                        return;
                    else
                    {
                        //Move the player
                        canMove = true;
                     //   float angle = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
                     //   Vector3 targetRotation = new Vector3(0f, 0f, angle + Camera.main.transform.eulerAngles.y);
                        // transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, -targetRotation, rotationSpeed);
                        
                        JoyStickrect.localPosition = new Vector3(transform.up.x + offsetX, transform.up.y + offsetY, 0f) * joystickMovementSpeed;


                    }
                }


                //Only when the player get over to the right side...
                if (Input.GetMouseButtonUp(0))
                {
                    downPressed = false;
                    canMove = false;
                    //JoyStickrect.position = joyPadStartPos;
                    //JoystickHolder.SetActive(false);
                    JoyStickrect.anchoredPosition = joyPadStartPos1;
                    JoystickHolder.transform.position = joyPadStartPos;
                    comeFromLeftSide = false;
                }



            }
        }


    }

    //Mobile Movement
    void InfinityMobileMovement()
    {
        if (Input.touchCount > 0)//Checking if any touched happened..
        {
            foreach (Touch touch in Input.touches)
            {

                if (touch.fingerId == 0)
                {

                    if (joyPadTouch)
                    {
                        if (touch.position.x < ScreenWidth / 2)
                        {
                            if (Input.GetTouch(0).phase == TouchPhase.Began)
                            {
                                JoystickHolder.SetActive(true);
                                downPressed = true;
                                mobileStartPos = Input.GetTouch(0).position;
                                JoystickHolder.transform.position = new Vector3(mobileStartPos.x, mobileStartPos.y, 0f);
                                fingerCount++;


                            }
                            if (Input.GetTouch(0).phase == TouchPhase.Moved && downPressed)
                            {
                                JoystickHolder.SetActive(true);
                                mobileDifference = (Vector2)Input.GetTouch(0).position - mobileStartPos;//Mouse delta...
                                if (mobileDifference.sqrMagnitude < 0.8f)
                                    return;
                                else
                                {
                                    canMove = true;

                                    float angle = Mathf.Atan2(mobileDifference.x, mobileDifference.y) * Mathf.Rad2Deg;
                                    Vector3 targetRotation = new Vector3(0f, 0f, angle + Camera.main.transform.eulerAngles.y);
                                    transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, -targetRotation, rotationSpeed);
                                    //Joystick movement
                                    //JoystickImage.transform.localEulerAngles = new Vector3(0f,0f,angle);  

                                    JoyStickrect.localPosition = new Vector3(transform.up.x + offsetX, transform.up.y + offsetY, 0f) * joystickMovementSpeed;




                                }
                            }

                            if (Input.GetTouch(0).phase == TouchPhase.Ended)
                            {
                                //ButtonPressedFun.buttonPressed = false;
                                downPressed = false;
                                JoyStickrect.anchoredPosition = joyPadStartPos1;
                                JoystickHolder.transform.position = joyPadStartPos;
                                fingerCount = 0;
       
                                //JoystickHolder.SetActive(false);
                                canMove = false;

                            }
                        }
                        else
                        {

                            //Come from left side then movemnet must work.... to make the player comtroller reliable..
                            if (comeFromLeftSide && Input.GetTouch(0).phase == TouchPhase.Moved)
                            {
                                JoystickHolder.SetActive(true);
                                mobileDifference = (Vector2)Input.GetTouch(0).position - mobileStartPos;//Mouse delta...
                                if (mobileDifference.sqrMagnitude < 0.8f)
                                    return;
                                else
                                {
                                    canMove = true;

                                    float angle = Mathf.Atan2(mobileDifference.x, mobileDifference.y) * Mathf.Rad2Deg;
                                    Vector3 targetRotation = new Vector3(0f, 0f, angle + Camera.main.transform.eulerAngles.y);
                                    transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, -targetRotation, rotationSpeed);
                                    //Joystick movement
                                    //JoystickImage.transform.localEulerAngles = new Vector3(0f,0f,angle);  
                                    JoyStickrect.localPosition = new Vector3(transform.up.x + offsetX, transform.up.y + offsetY, 0f) * joystickMovementSpeed;

                                }
                            }


                            //Stop player andd disable the joystick
                            if (Input.GetTouch(0).phase == TouchPhase.Ended)
                            {
                                downPressed = false;
                                canMove = false;
                                JoyStickrect.anchoredPosition = joyPadStartPos1;
                                JoystickHolder.transform.position = joyPadStartPos;
                                //  JoystickHolder.SetActive(false);
                            }


                        }
                    }
                }
            }
        }
    }
}