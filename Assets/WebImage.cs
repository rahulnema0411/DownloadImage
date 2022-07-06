using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebImage : MonoBehaviour
{
    public Image image;

    public void RenderImage(string imageUrl) {
        if(!string.IsNullOrEmpty(imageUrl)) {
            StartCoroutine(DownloadImage.instance.FetchAndSetImage(imageUrl, image));
        } else {
            Debug.LogError("Empty string");
        }
    }
}
