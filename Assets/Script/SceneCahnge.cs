using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCahnge : MonoBehaviour
{
    public void changeScene()
    {
        SceneManager.LoadScene("ExplanationScene");
    }
}
