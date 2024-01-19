using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public bool facingUp;
    public bool matched;

    public GameObject cardHolder;
    public GameObject matchingCard;
    public Transform cubePosition;

    CardController matchingCardController; 
    GameController gameController;

    private void Start()
    {
        cubePosition = GetComponent<Transform>();
        gameController = cardHolder.GetComponent<GameController>();
        matchingCardController = matchingCard.GetComponent<CardController>();
        matched = false;
        facingUp = false;
    }


    public void FlipUp()
    {
        if (!facingUp)
        {
            cubePosition.transform.localEulerAngles = new Vector3(0, 0, 0);
            facingUp = true;
            gameController.numberOfUpCards++;
            gameController.totalNumber++;
            gameController.clicks++;

        }
    }

    public void FlipDown()
    {
        if (!matched && facingUp)
        {
            cubePosition.transform.localEulerAngles = new Vector3(0, 180, 0);
            facingUp = false;
            gameController.numberOfUpCards--;
            gameController.totalNumber--;

        }

    }

    public void CheckForMatch()
    {
        if (matchingCardController.facingUp == true)
        {
            matched = true;
            matchingCardController.matched = true;
            gameController.pairsFound++;
            gameController.numberOfUpCards = 0;
        }
    }
}
