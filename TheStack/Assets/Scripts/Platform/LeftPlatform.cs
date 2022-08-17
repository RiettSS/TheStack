using System;
using UnityEngine;

public class LeftPlatform : Platform
{
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, LastPlatform.transform.position.z);
    }
    
    public override void Cut()
    {
        float placedPlatformScale;
        float placedPlatformPos;
        float positionsDelta;
        
        var startPoint = LastPlatform.transform.position;
        positionsDelta = Mathf.Abs(startPoint.x - CurrentPlatform.transform.position.x);
        
        if (CurrentPlatform.transform.position.x <= startPoint.x)
            placedPlatformPos = CurrentPlatform.transform.position.x + (positionsDelta / 2);
        else
            placedPlatformPos = CurrentPlatform.transform.position.x - (positionsDelta / 2);
        
        placedPlatformScale = LastPlatform.transform.localScale.x - positionsDelta;

        Place();
        
        transform.localScale = new Vector3( placedPlatformScale, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(placedPlatformPos, transform.position.y, transform.position.z);
    }

    public override bool Placeable()
    {
        var startPoint = LastPlatform.transform.position;
        var positionsDelta = Mathf.Abs(startPoint.x - CurrentPlatform.transform.position.x);

        if (positionsDelta < LastPlatform.transform.localScale.x)
        {
            return true;
        }

        return false;
    }

    protected override void Move(float position)
    {
        transform.position = new Vector3(position, transform.position.y, transform.position.z);
    }
}
