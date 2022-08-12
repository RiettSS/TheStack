using UnityEngine;

public class ColorGenerator
{
    private int _colorCounter;
    private bool _increasing;
    private Color _lastColor;

    public ColorGenerator()
    {
        _colorCounter = 0;
        _increasing = true;
    }
    
    public Color GetColor()
    {
        var offset = ColorIndex() * 0.03f;
        var offsetSin = Mathf.Abs(Mathf.Sin(offset)) * 0.95f;

        _lastColor = new Color(offsetSin, offsetSin, offsetSin);
        
        return _lastColor;
    }

    public Color GetOppositeColor()
    {
        var color = _lastColor;

        var r = 1f - color.r;
        var g = 1f - color.g;
        var b = 1f - color.b;
        
        return new Color(r, g, b);
    }

    private int ColorIndex()
    {
        if (_colorCounter >= 30)
            _increasing = false;

        if (_colorCounter == 0)
            _increasing = true;
            
        
        if (_increasing)
        {
            return _colorCounter++;
        }
        else
        {
            return _colorCounter--;
        }
    }
}
