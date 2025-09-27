using System.Runtime.InteropServices;

namespace Base.Engine;

/// <summary>
/// 代表与行向量交互工作的 4x4 矩阵结构体.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Matrix4x4
{
    private float m11, m12, m13, m14;
    private float m21, m22, m23, m24;
    private float m31, m32, m33, m34;
    private float m41, m42, m43, m44;

    public Matrix4x4(
        float m11, float m12, float m13, float m14,
        float m21, float m22, float m23, float m24,
        float m31, float m32, float m33, float m34,
        float m41, float m42, float m43, float m44)
    {
        this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14;
        this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24;
        this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34;
        this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44;
    }

    /// <summary>
    /// 单位 4x4 矩阵.
    /// </summary>
    public static readonly Matrix4x4 Identity = new(
        1f, 0f, 0f, 0f,
        0f, 1f, 0f, 0f,
        0f, 0f, 1f, 0f,
        0f, 0f, 0f, 1f);

    public float M11 { get => m11; set => m11 = value; }
    public float M12 { get => m12; set => m12 = value; }
    public float M13 { get => m13; set => m13 = value; }
    public float M14 { get => m14; set => m14 = value; }
    public float M21 { get => m21; set => m21 = value; }
    public float M22 { get => m22; set => m22 = value; }
    public float M23 { get => m23; set => m23 = value; }
    public float M24 { get => m24; set => m24 = value; }
    public float M31 { get => m31; set => m31 = value; }
    public float M32 { get => m32; set => m32 = value; }
    public float M33 { get => m33; set => m33 = value; }
    public float M34 { get => m34; set => m34 = value; }
    public float M41 { get => m41; set => m41 = value; }
    public float M42 { get => m42; set => m42 = value; }
    public float M43 { get => m43; set => m43 = value; }
    public float M44 { get => m44; set => m44 = value; }

    public override readonly string ToString()
    {
        return
            $"┌ {m11,-6:F2}  {m12,-6:F2}  {m13,-6:F2}  {m14,-6:F2} ┐\n" + 
            $"│ {m21,-6:F2}  {m22,-6:F2}  {m23,-6:F2}  {m24,-6:F2} │\n" +
            $"│ {m31,-6:F2}  {m32,-6:F2}  {m33,-6:F2}  {m34,-6:F2} │\n" +
            $"└ {m41,-6:F2}  {m42,-6:F2}  {m43,-6:F2}  {m44,-6:F2} ┘";
    }

    /// <summary>
    /// 返回该 4x4 矩阵与给定 4x4 矩阵相乘的结果（this * <see cref="other"/>）.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly Matrix4x4 Multiply(Matrix4x4 other)
    {
        float _m11  =   m11 * other.M11 +
                        m12 * other.M21 +
                        m13 * other.M31 +
                        m14 * other.M41;

        float _m12  =   m11 * other.M12 +
                        m12 * other.M22 +
                        m13 * other.M32 +
                        m14 * other.M42;

        float _m13  =   m11 * other.M13 +
                        m12 * other.M23 +
                        m13 * other.M33 +
                        m14 * other.M43;

        float _m14  =   m11 * other.M14 +
                        m12 * other.M24 +
                        m13 * other.M34 +
                        m14 * other.M44;

        //////////////////////////////////////////////////////////

        float _m21  =   m21 * other.M11 +
                        m22 * other.M21 +
                        m23 * other.M31 +
                        m24 * other.M41;

        float _m22  =   m21 * other.M12 +
                        m22 * other.M22 +
                        m23 * other.M32 +
                        m24 * other.M42;

        float _m23  =   m21 * other.M13 +
                        m22 * other.M23 +
                        m23 * other.M33 +
                        m24 * other.M43;

        float _m24 =    m21 * other.M14 +
                        m22 * other.M24 +
                        m23 * other.M34 +
                        m24 * other.M44;

        //////////////////////////////////////////////////////////

        float _m31  =   m31 * other.M11 +
                        m32 * other.M21 +
                        m33 * other.M31 +
                        m34 * other.M41;

        float _m32  =   m31 * other.M12 +
                        m32 * other.M22 +
                        m33 * other.M32 +
                        m34 * other.M42;

        float _m33  =   m31 * other.M13 +
                        m32 * other.M23 +
                        m33 * other.M33 +
                        m34 * other.M43;

        float _m34  =   m31 * other.M14 +
                        m32 * other.M24 +
                        m33 * other.M34 +
                        m34 * other.M44;

        //////////////////////////////////////////////////////////

        float _m41  =   m41 * other.M11 +
                        m42 * other.M21 +
                        m43 * other.M31 +
                        m44 * other.M41;

        float _m42  =   m41 * other.M12 +
                        m42 * other.M22 +
                        m43 * other.M32 +
                        m44 * other.M42;

        float _m43  =   m41 * other.M13 +
                        m42 * other.M23 +
                        m43 * other.M33 +
                        m44 * other.M43;

        float _m44  =   m41 * other.M14 +
                        m42 * other.M24 +
                        m43 * other.M34 +
                        m44 * other.M44;

        return new Matrix4x4(
            _m11, _m12, _m13, _m14,
            _m21, _m22, _m23, _m24,
            _m31, _m32, _m33, _m34,
            _m41, _m42, _m43, _m44);
    }
}