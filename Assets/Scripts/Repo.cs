using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repo : MonoBehaviour
{
    public string URL = "https://github.com/SarahAlexia/AstroBot";
    public void loadUrl()
    {
        Application.OpenURL(URL);
    }
}
