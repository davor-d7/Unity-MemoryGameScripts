using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D cursorClick;
    private Camera mainCamera;
    public GameObject controller;
    GameController gameController3;
    private int currentlyUp;
    public GameObject ui1;
    public GameObject ui2;
    public GameObject ui3;
    public bool noUI;


    private void Awake()
    {
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;  
        gameController3 = controller.GetComponent<GameController>();
    }

    private void Update()
    {
        UiCheck();
        if (Input.GetMouseButtonDown(0) && noUI == true)
        {
            ChangeCursor(cursorClick);
            currentlyUp = gameController3.numberOfUpCards;


            if (currentlyUp < 2)
            {
                DetectObject();
            }
            else if (currentlyUp > 1 && currentlyUp < 3)
            {
                gameController3.ThirdFlip();
                DetectObject();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ChangeCursor(cursor);
        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto); 
    }

    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            CardController cardController2 = hit.transform.GetComponent<CardController>();

            if(hit.transform.tag == "Card" && cardController2 != null)
            {
                print("card is hit");
                cardController2.FlipUp();
                cardController2.CheckForMatch();
            }
        }
    }

    private void UiCheck()
    {
        if (ui1.activeSelf == false && ui2.activeSelf == false && ui1.activeSelf == false)
        {
            noUI = true;
        }
        else
        {
            noUI = false;
        }
    }

}
