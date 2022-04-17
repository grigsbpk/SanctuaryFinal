using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{

    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject MainCam;
    public GameObject Player;
    public GameObject Goblin;
    public GameObject LocationText;

    void Start()
    {
        StartCoroutine (TheSequence ());
    }

    IEnumerator TheSequence ()
    {

        yield return new WaitForSeconds(5);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(5);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        yield return new WaitForSeconds(5);
        MainCam.SetActive(true);
        Goblin.SetActive(true);
        Cam3.SetActive(false);
        LocationText.SetActive(false);
        

    }

}
