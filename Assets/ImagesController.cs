using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesController : MonoBehaviour
{
    public WebImage[] webImages;
    public string imageUrl;

    private void Start() {
        RenderAllImages();
    }

    private void RenderAllImages() {
        foreach(WebImage webImage in webImages) {
            webImage.RenderImage(imageUrl);
        }
    }
}
