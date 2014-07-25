using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class JoysticController : MonoBehaviour
{
    public GameObject playerGameObject;
    public GameObject joysticGameObject;
    public Sprite joyStartSprite;
    public Sprite joyPressSprite;

    public float PlayerSpeed;
    public float JoysticSpeed;
    public float PlayerTilt;

    private float vector;

    private Vector3 JoyPosition;
    private Vector3 PlayerPosition;

    void Start()
    {
        JoyPosition = joysticGameObject.transform.position;
        PlayerPosition = playerGameObject.transform.position;
    }

    void Update()
    {
        if (playerGameObject != null)
        {
            if (PlayerPosition.x != 0)
            {
                playerGameObject.rigidbody.rotation = Quaternion.Euler(270 + (playerGameObject.transform.position.x - PlayerPosition.x) * PlayerTilt, 270, 0.0f);
                playerGameObject.transform.position = Vector3.Lerp(playerGameObject.transform.position,
                    PlayerPosition, Time.deltaTime * PlayerSpeed);
            }
            else
            {
                playerGameObject.rigidbody.rotation = Quaternion.Euler(270, 270, 0.0f);
            }
        }

        if (joysticGameObject != null)
        {
            JoyPosition.x = PlayerPosition.x * 0.80f;
            joysticGameObject.transform.position = Vector3.Lerp(joysticGameObject.transform.position,
                JoyPosition, Time.deltaTime * JoysticSpeed);
        }
    }

    void OnMouseDown()
    {
        PlayerPosition.x = GetMousePositionAbsolute().x;
        ChangeJoySprite(joyPressSprite);
    }

    void OnMouseUp()
    {
        PlayerPosition.x = 0;
    }

    void OnMouseDrag()
    {
        PlayerPosition.x = GetMousePositionAbsolute().x;
    }

    private void ChangeJoySprite(Sprite expSprite)
    {
        if (((SpriteRenderer)joysticGameObject.GetComponent("SpriteRenderer")).sprite != expSprite)
            ((SpriteRenderer)joysticGameObject.GetComponent("SpriteRenderer")).sprite = expSprite;
    }

    private Vector3 GetMousePositionAbsolute()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return (Physics.Raycast(ray, out hit, 100)) ? hit.point : Vector3.zero;
    }
}
