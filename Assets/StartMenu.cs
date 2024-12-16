using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{
    public string SpaceInvaders;

    public void LoadSpaceInvaders()
    {
        SceneManager.LoadScene(SpaceInvaders);
    }
}
