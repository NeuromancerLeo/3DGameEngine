using System.Security.Cryptography.X509Certificates;

namespace Base.Engine;

public struct Vector2
{
    private float x;
    private float y;

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    public float Y
    {
        get
        {
            return y;
        }

        set
        {
            y = value;
        }
    }


    public override string ToString()
    {
        return "(" + x + ", " + y + ")";
    }
}