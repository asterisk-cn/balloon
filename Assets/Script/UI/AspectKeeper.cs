using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AspectKeeper : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera;
    [SerializeField]
    private Vector2 aspect = new Vector2(16, 9);

    void Update()
    {
        var screenAspect = (float)Screen.width / Screen.height;
        var targetAspect = aspect.x / aspect.y;

        var scale = targetAspect / screenAspect;

        var cameraRect = new Rect(0, 0, 1, 1);
        if (scale < 1)
        {
            cameraRect.width = scale;
            cameraRect.x = (1 - scale) / 2;
        }
        else
        {
            var scaleHeight = 1 / scale;
            cameraRect.height = scaleHeight;
            cameraRect.y = (1 - scaleHeight) / 2;
        }

        targetCamera.rect = cameraRect;
    }
}
