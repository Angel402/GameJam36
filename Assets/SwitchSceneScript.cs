using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchSceneScript : MonoBehaviour
{
    void OnCollisionEnter(Collision gameObjectInformation)
    {
        if(gameObjectInformation.gameObject.name == "Player")
            SceneManager.LoadScene(2);
    }

}
