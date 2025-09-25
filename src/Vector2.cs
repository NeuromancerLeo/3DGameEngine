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

    public static readonly Vector2 Zero = new(0f, 0f);
    public static readonly Vector2 Up = new(0f, 1f);
    public static readonly Vector2 Down = new(0f, -1f);
    public static readonly Vector2 Left = new(-1f, 0f);
    public static readonly Vector2 Right = new(1f, 0f);


    public static Vector2 operator +(Vector2 v)
    {
        return v;
    }

    public static Vector2 operator -(Vector2 v)
    {
        return new Vector2(-v.X, -v.Y);
    }

    public static Vector2 operator +(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector2 operator -(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
    }

    // 数乘
    public static Vector2 operator *(Vector2 v, float scalar)
    {
        return new Vector2(v.X * scalar, v.Y * scalar);
    }

    // 数除
    public static Vector2 operator /(Vector2 v, float scalar)
    {
        if (MathF.Abs(scalar) < float.Epsilon)
            throw new DivideByZeroException("Cannot divide vector by zero");

        return new Vector2(v.X / scalar, v.Y / scalar);
    }

    /// <summary>
    /// 根据给定误差值判断向量与给定向量是否近似相等.
    /// <para>考虑到浮点值的不准确性，如果两个向量的差值 <see cref="tolerance"/> 小于 <see cref="1e-5"/>，则认为它们是相等的</para>
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="tolerance">误差值</param>
    /// <returns></returns>
    public readonly bool IsApproximate(Vector2 vector, float tolerance = 1e-5f)
    {
        return (MathF.Abs(x - vector.X) < tolerance) && (MathF.Abs(y - vector.Y) < tolerance);
    }

    public override readonly string ToString()
    {
        return "(" + x + ", " + y + ")";
    }

    /// <summary>
    /// 返回向量的模长.
    /// </summary>
    /// <returns>向量的模长.</returns>
    public readonly float Length()
    {
        return MathF.Sqrt(x * x + y * y);
    }

    /// <summary>
    /// 将向量与给定向量点乘，返回结果.
    /// </summary>
    /// <param name="vector2"></param>
    /// <returns>与给定向量点乘后的结果（标量）.</returns>
    public readonly float Dot(Vector2 vector2)
    {
        return x * vector2.X + y * vector2.Y;
    }

    /// <summary>
    /// 将向量归一化后返回.
    /// <para>注意: 当前向量保持不变，返回一个新的归一化向量</para>
    /// </summary>
    /// <returns>新的归一化向量.</returns>
    public readonly Vector2 Normalized()
    {
        float length = Length();

        if (length != 0)
        {
            float x = this.x;
            float y = this.y;
            x /= length;
            y /= length;

            return new Vector2(x, y);
        }
        else
        {
            return Zero;
        }
    }

    /// <summary>
    /// 返回该向量给定弧度旋转后的向量.
    /// </summary>
    /// <param name="radians"></param>
    /// <returns>给定弧度旋转后的向量.</returns>
    public readonly Vector2 Rotated(float radians)
    {
        float cos = MathF.Cos(radians);
        float sin = MathF.Sin(radians);

        return new Vector2(
            x * cos - y * sin,
            y * cos + x * sin
        );
    }

    /// <summary>
    /// 返回该向量给定角度旋转后的向量.
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns>给定角度旋转后的向量.</returns>
    public readonly Vector2 RotatedDegrees(float degrees)
    {
        return Rotated(degrees * MathF.PI / 180f);
    }
}