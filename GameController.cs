using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int pairsFound = 0;
    public int numberOfUpCards = 0;
    public int totalNumber;
    public int clicks = 0;

    public GameObject[] cardsArray; 
    public GameObject gameOver;

  

    public CardController[] cardController;
    public List<Transform> cardTransforms;

    private void Awake()
    {
        cardController = GetComponentsInChildren<CardController>();

    }
    private void Start()
    {
        Shuffle();
    }

    void Update()
    {
        AreYaWinningSon();
    }

    public void AreYaWinningSon()
    {
        if (totalNumber > 17)
        {
            gameOver.SetActive(true);
        }
    }

    public void ThirdFlip()
    {

        foreach (CardController card in cardController)
        {
            card.FlipDown();
        }

    }

  public void Shuffle()
  {
  
      for (int i = 0; i < cardTransforms.Count; i++)
      {
          int randomNumber = Random.Range(0, cardTransforms.Count);
          Vector3 lastposition = cardTransforms[i].position;
          cardTransforms[i].position = cardTransforms[randomNumber].position;
          cardTransforms[randomNumber].position = lastposition;
      }
  }
}

