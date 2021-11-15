using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private const float DEADZONE = 70, TAP_THRESHOLD = 0.2f;
    public static MobileInput Instance {set; get;}
    private bool tap, doubleTap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 swipeDelta, startTouch;
    private float startTapTime;

    public bool Tap {get{return tap;}}
    public bool DoubleTap {get{return doubleTap;}}
    private Vector2 SwipeDelta {get{return swipeDelta;}}
    public bool SwipeLeft {get{return swipeLeft;}}
    public bool SwipeRight {get{return swipeRight;}}
    public bool SwipeUp {get{return swipeUp;}}
    public bool SwipeDown {get{return swipeDown;}}
    public bool Swiping {get{return swipeDown || swipeLeft || swipeRight || swipeUp;}}

    private void Awake(){
        Instance  = this;
        startTapTime = 0f;
    }

    private void Update(){
        //Reseting all the booleans
        tap = doubleTap = swipeRight = swipeLeft = swipeDown = swipeUp = false;

        //Let's check for inputs

        #region Standalone Inputs
        if(Input.GetMouseButtonDown(0)){
            float thisTime = Time.time;
            if(thisTime-startTapTime <= TAP_THRESHOLD){
                doubleTap = true;
                //Debug.Log("double");
            }
            else{
                tap = true;
                //Debug.Log("single");
                startTouch = Input.mousePosition;
            }
            startTapTime = thisTime;
        }
        else if (Input.GetMouseButtonUp(0)){
            startTouch = swipeDelta = Vector2.zero;
        }
        #endregion

        #region Mobile Inputs
        if(Input.touches.Length != 0){
            if(Input.touches[0].phase == TouchPhase.Began){
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
                startTouch = swipeDelta = Vector2.zero;
            }
        }
        #endregion

        // Calculate distance
        swipeDelta = Vector2.zero;
        if(startTouch != Vector2.zero){
            // Let's check with mobile
            if(Input.touches.Length != 0){
                swipeDelta = Input.touches[0].position - startTouch;
            }
            //Let's chech with standalone
            else if(Input.GetMouseButton(0)){
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        // Let's check if we're beyond the deadzone
        if(swipeDelta.magnitude > DEADZONE){
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x)>Mathf.Abs(y)){
                //Left or Right
                if(x<0){
                    swipeLeft = true;
                }
                else{
                    swipeRight = true;
                }
            }
            else{
                //Up or Down
                if(y<0){
                    swipeDown = true;
                }
                else{
                    swipeUp = true;
                }
            }

            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
