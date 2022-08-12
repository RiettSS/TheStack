using UnityEngine;

public class RightPlatform : Platform
{
    private void Start()
    {
        transform.position = new Vector3(LastPlatform.transform.position.x, transform.position.y, transform.position.z);
    }

    public override void Cut()
    {
        float placedPlatformScale;
        float placedPlatformPos;
        float positionsDelta;
        
        var startPoint = LastPlatform.transform.position;
        positionsDelta = Mathf.Abs(startPoint.z - CurrentPlatform.transform.position.z);

        if (CurrentPlatform.transform.position.z <= startPoint.z)
            placedPlatformPos = CurrentPlatform.transform.position.z + (positionsDelta / 2);
        else
            placedPlatformPos = CurrentPlatform.transform.position.z - (positionsDelta / 2);
                
        placedPlatformScale = LastPlatform.transform.localScale.z - positionsDelta;

        Place();
        
        transform.localScale = new Vector3( transform.localScale.x, transform.localScale.y, placedPlatformScale);
        transform.position = new Vector3(transform.position.x, transform.position.y, placedPlatformPos);
        
        Debug.Log(positionsDelta);
    }

    public override bool Placeable()
    {
        var startPoint = LastPlatform.transform.position;
        var positionsDelta = Mathf.Abs(startPoint.z - CurrentPlatform.transform.position.z);

        Debug.Log("delta is " + positionsDelta + ", last platform scale is " + LastPlatform.transform.localScale.z);
        
        if (positionsDelta < LastPlatform.transform.localScale.z)
        {
            return true;
        }

        return false;
    }

    protected override void Move(float position)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, position);
    }
}
