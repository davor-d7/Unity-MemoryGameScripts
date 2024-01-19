using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    public TMP_Text textBox;
    public GameObject cardHolder;
    public GameController gameController;
    public int clickCount;

    private void Awake()
    {
        gameController = cardHolder.GetComponent<GameController>();

    }

    private void Start()
    {
        textBox.text = clickCount.ToString();
    }

    private void Update()
    {
        clickCount = gameController.clicks;
        textBox.text = clickCount.ToString();
    }
}
