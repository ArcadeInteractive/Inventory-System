using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlayerHotbarSelector : MonoBehaviour
{
    private Player player;
    private RectTransform myTransform;

	void Start ()
    {
        player = FindObjectOfType<Player>();
        myTransform = GetComponent<RectTransform>();
	}
	
	void Update ()
    {
		if(player != null)
        {
            Vector2 pos = new Vector2((player.getSelectedHotbarIndex() * 50) - 125, 0);
            myTransform.anchoredPosition = pos;
        }
	}
}