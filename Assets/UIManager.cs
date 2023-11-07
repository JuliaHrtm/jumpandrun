using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject deathpanel;

    public void ToggleDeathPanel()
    {
        deathpanel.SetActive(!deathpanel.activeSelf);
    }


}
