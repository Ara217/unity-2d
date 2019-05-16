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
                Main.MoveRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                Main.MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Main.Jump();
            }
        }
    }
}