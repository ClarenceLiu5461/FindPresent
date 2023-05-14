using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PresentsControll : MonoBehaviour
{
    int Presents = 0;
    string PresentsNum = null;
    public AudioSource GetAS = null;
    public AudioClip Collect = null;

    public void OnCollisionEnter(Collision Main)
    {
        if (Main.collider.name.Contains("present") ) 
        {
            Presents++;
            PresentsNum = "" + Presents;
            Destroy(Main.other.gameObject);
            GameObject ifCollect = GameObject.Find("/Canvas/BG/Gift");
            ifCollect.GetComponent<Text>().text = PresentsNum.ToString();
            GetAS.clip = Collect;
            GetAS.Play();
            GameObject ifComplete = GameObject.Find("/Canvas/BG/Status");
            if (Presents == 5)
            {
                ifComplete.GetComponent<Text>().text = "已完成";
            }
        }
        if (Main.collider.name == "TargetArea")
        {
            if (Presents == 5)
            {
                SceneManager.LoadScene("End");
            }
        }
    }
}
