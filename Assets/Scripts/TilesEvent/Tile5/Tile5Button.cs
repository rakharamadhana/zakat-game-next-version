using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile5Button : MonoBehaviour
{
    private void Start()
    {
        //this.gameObject.SetActive(false);
    }
    public void Clicked()
    {
        Debug.Log("Clicked");
        this.gameObject.SetActive(false);
    }
}
