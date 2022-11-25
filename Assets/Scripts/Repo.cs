using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repo : MonoBehaviour
{
    public string URL = "https://github.com/TUD-RSmith/Lecture_Demo";
    public void loadUrl()
    {
        Application.OpenURL(URL);
    }
}
