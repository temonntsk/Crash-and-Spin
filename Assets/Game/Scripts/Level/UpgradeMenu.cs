using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
