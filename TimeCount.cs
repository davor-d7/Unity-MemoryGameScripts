using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCount : MonoBehaviour
{
    public float timeStart;
    public TMP_Text textBox;
    public GameObject cardHolder;
    public GameController gameController;

    private void Awake()
    {
        gameController = cardHolder.GetComponent<GameController>();

    }
    private void Start()
    {
        textBox.text = timeStart.ToString("F0");
    }

    private void Update()
    {
        if (gameController.pairsFound < 9)
        {
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F0");
        }
    }


  
}
