/// 规定：左手坐标系，Z+ 朝前， Y+ 朝上， X+ 朝右

namespace Base.Engine;

public struct Vector3
{
    private float x;
    private float y;
    private float z;

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
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

    public float Z
    {
        get
        {
            return z;
        }

        set
        {
            z = value;
        }
    }

    public static readonly Vector3 Zero = new(0f, 0f, 0f);
    public static readonly Vector3 Up = new(0f, 1f, 0f);
    public static readonly Vector3 Down = new(0f, -1f, 0f);
    public static readonly Vector3 Left = new(-1f, 0f, 0f);
    public static readonly Vector3 Right = new(1f, 0f, 0f);
    public static readonly Vector3 Forward = new(0f, 0f, 1f);
    public static readonly Vector3 Backward = new(0f, 0f, -1f);

    public static Vector3 operator +(Vector3 v)
    {
        return v;
    }

    public static Vector3 operator -(Vector3 v)
    {
        return new Vector3(-v.X, -v.Y, -v.Z);
    }

    public static Vector3 operator +(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector3 operator -(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    // 数乘
    public static Vector3 operator *(Vector3 v, float scalar)
    {
        return new Vector3(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    // 数除
    public static Vector3 operator /(Vector3 v, float scalar)
    {
        if (MathF.Abs(scalar) < float.Epsilon)
            throw new DivideByZeroException("Cannot divide vector by zero");

        return new Vector3(v.X / scalar, v.Y / scalar, v.Z / scalar);
    }

    /// <summary>
    /// 根据给定误差值判断向量与给定向量是否近似相等.
    /// <para>考虑到浮点值的不准确性，如果两个向量的差值 <see cref="tolerance"/> 小于 <see cref="1e-5"/>，则认为它们是相等的</para>
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="tolerance">误差值</param>
    /// <returns></returns>
    public readonly bool IsApproximate(Vector3 vector, float tolerance = 1e-5f)
    {
        return (
            (MathF.Abs(x - vector.X) < tolerance) &&
            (MathF.Abs(y - vector.Y) < tolerance) &&
            (MathF.Abs(z - vector.Z) < tolerance)
        );
    }

    public override readonly string ToString()
    {
        return "(" + x + ", " + y + ", " + z + ")";
    }

    /// <summary>
    /// 返回向量的模长.
    /// </summary>
    /// <returns>向量的模长.</returns>
    public readonly float Length()
    {
        return MathF.Sqrt(x * x + y * y + z * z);
    }

    /// <summary>
    /// 将向量与给定向量点乘，返回结果.
    /// </summary>
    /// <param name="vector3"></param>
    /// <returns>与给定向量点乘后的结果（标量）.</returns>
    public readonly float Dot(Vector3 vector3)
    {
        return x * vector3.X + y * vector3.Y + z * vector3.Z;
    }

    /// <summary>
    /// 将向量归一化后返回.
    /// <para>注意: 当前向量保持不变，返回一个新的归一化向量</para>
    /// </summary>
    /// <returns>新的归一化向量.</returns>
    public readonly Vector3 Normalized()
    {
        float length = Length();

        if (length != 0)
        {
            float x = this.x;
            float y = this.y;
            float z = this.z;
            x /= length;
            y /= length;
            z /= length;

            return new Vector3(x, y, z);
        }
        else
        {
            return Zero;
        }
    }

    /// <summary>
    /// 返回该向量绕其 X 轴给定弧度旋转后的向量.
    /// </summary>
    /// <param name="radians"></param>
    /// <returns>绕其 X 轴给定弧度旋转后的向量.</returns>
    public readonly Vector3 RotateX(float radians)
    {
        float cos = MathF.Cos(radians);
        float sin = MathF.Sin(radians);

        return new Vector3(
            x,
            y * cos - z * sin,
            z * cos + y * sin
        );
    }

    /// <summary>
    /// 返回该向量绕其 Y 轴给定弧度旋转后的向量.
    /// </summary>
    /// <param name="radians"></param>
    /// <returns>绕其 Y 轴给定弧度旋转后的向量.</returns>
    public readonly Vector3 RotateY(float radians)
    {
        float cos = MathF.Cos(radians);
        float sin = MathF.Sin(radians);

        return new Vector3(
            x * cos + z * sin,
            y,
            z * cos - x * sin
        );
    }

    /// <summary>
    /// 返回该向量绕其 Z 轴给定弧度旋转后的向量.
    /// </summary>
    /// <param name="radians"></param>
    /// <returns>绕其 Z 轴给定弧度旋转后的向量.</returns>
    public readonly Vector3 RotateZ(float radians)
    {
        float cos = MathF.Cos(radians);
        float sin = MathF.Sin(radians);

        return new Vector3(
            x * cos - y * sin,
            y * cos + x * sin,
            z
        );
    }

    /// <summary>
    /// 返回该向量绕其 X 轴给定角度旋转后的向量.
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns>绕其 X 轴给定角度旋转后的向量.</returns>
    public readonly Vector3 RotateXDegrees(float degrees) => RotateX(degrees * MathF.PI / 180f);

    /// <summary>
    /// 返回该向量绕其 Y 轴给定角度旋转后的向量.
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns>绕其 Y 轴给定角度旋转后的向量.</returns>
    public readonly Vector3 RotateYDegrees(float degrees) => RotateY(degrees * MathF.PI / 180f);

    /// <summary>
    /// 返回该向量绕其 Z 轴给定角度旋转后的向量.
    /// </summary>
    /// <param name="degrees"></param>
    /// <returns>绕其 Z 轴给定角度旋转后的向量.</returns>
    public readonly Vector3 RotateZDegrees(float degrees) => RotateZ(degrees * MathF.PI / 180f);
}