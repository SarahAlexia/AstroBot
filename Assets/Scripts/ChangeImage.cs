using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeButtonImage()
    {
        button.image.sprite = newButtonImage;
    }
}
