using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;

public class BackButtonController : MonoBehaviour
{
    public Sprite pressedSprite;
    private Sprite notPressedSprite;

    void Start()
    {
        notPressedSprite = ((SpriteRenderer)renderer).sprite;
    }

    void OnMouseDown()
    {
        if ((GameObject.Find("Screen Main Menu").transform.position.x >= -3 && GameObject.Find("Screen Main Menu").transform.position.x <= 3)            
            || (GameObject.Find("Screen Scores").transform.position.x >= -3 && GameObject.Find("Screen Scores").transform.position.x <= 3))
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        ((SpriteRenderer)renderer).sprite = pressedSprite;
                    }
                }
            }
    }

    void OnMouseUp()
    {
        ((SpriteRenderer)renderer).sprite = notPressedSprite;
        if ((GameObject.Find("Screen Main Menu").transform.position.x >= -3 && GameObject.Find("Screen Main Menu").transform.position.x <= 3)
            || (GameObject.Find("Screen Scores").transform.position.x >= -3 && GameObject.Find("Screen Scores").transform.position.x <= 3))
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        AppCore.BackButtonPress();
                    }
                }
            }
    }
}