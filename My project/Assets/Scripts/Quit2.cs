using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
