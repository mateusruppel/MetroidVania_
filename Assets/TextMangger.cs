using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMangger : MonoBehaviour
{
	// Start is called before the first frame update
	public TextMeshProUGUI text;

    void Start()
    {
		text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
