using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update

    private bool onCooldown = false;

    public void LoadScene(string sceneName)
    {
        if(onCooldown == false)
        {
            StartCoroutine(Waiting(sceneName));
            Invoke("ResetCooldown", 5.0f);
            onCooldown = true;
        }
            


    }

    IEnumerator Waiting(string sceneName)
    {
        
        
        yield return new WaitForSeconds(7);


        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        
    }

    void ResetCooldown()
    {
        onCooldown = false;
    }
}
