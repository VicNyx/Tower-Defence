using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionControlText : MonoBehaviour
{
    [SerializeField] private Text versionText;

    private void Awake()
    {
        versionText = GetComponent<Text>();
    }

    private void Start()
    {
        versionText.text = ("V: " + Application.version);
    }
}
