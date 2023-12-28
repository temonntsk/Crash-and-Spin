using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public string Language { get; private set; }

    private void Start() => SetLanguage();

    public void SetLanguage()
    {
        if (Application.absoluteURL.Contains(".com") || Application.absoluteURL.Contains(".en"))
        {
            Language = "en";
            LeanLocalization.SetCurrentLanguageAll("English");
        }
        else if (Application.absoluteURL.Contains(".ru"))
        {
            Language = "ru";
            LeanLocalization.SetCurrentLanguageAll("Russian");
        }
    }
}