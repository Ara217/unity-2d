using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{

    public Main Main;

    private void Start()
    {

        Main = Main == null ? GetComponent<Main>() : Main;
        if (Main == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void Update()
    {
        if (Main != null)
        {

            if (Input.GetKey(KeyCode.D))
            {
                Main.MoveRight(Input.GetAxis("Horizontal"));
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Main.Idle();
            }
            if (Input.GetKey(KeyCode.A))
            {
                Main.MoveLeft(Input.GetAxis("Horizontal"));
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                Main.Idle();
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Main.Jump();
            }
        }
    }

    // void OnGUI()
    //{
    //    GUILayout.Label("Press Enter To Start Game");

    //    if (Event.current.Equals(Event.KeyboardEvent("[enter]")))
    //    {
    //        Application.LoadLevel(1);
    //    }

    //    if (Event.current.Equals(Event.KeyboardEvent("return")))
    //    {
    //        print("I said enter, not return - try the keypad");
    //    }
    //}
}