using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;

    public bool IsColorPlayer = false;

    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if(IsColorPlayer)
        {
            SaveController.Instance.colorPlayer01 = paddleReference.color;
        }
        else
        {
            SaveController.Instance.colorPlayer02 = paddleReference.color;
        }
    }
}
