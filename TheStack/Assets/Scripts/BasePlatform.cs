public class BasePlatform : Platform
{

    public override void Cut()
    {
        throw new System.NotImplementedException();
    }

    public override bool Placeable()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move(float position)
    {
        //Do Nothing
    }
}
