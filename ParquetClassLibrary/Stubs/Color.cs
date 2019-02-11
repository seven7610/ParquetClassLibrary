﻿namespace ParquetClassLibrary.Stubs
{
    /// <summary>
    /// Stand-in for Unity Color class.
    /// </summary>
    public struct Color
    {
        public static readonly Color White = new Color(1f, 1f, 1f);
        public static readonly Color SkyBlue = new Color(0.7f, 0.9f, 1f);
        public static readonly Color Brown = new Color(0.6f, 0.3f, 0f);

        public readonly float r;
        public readonly float g;
        public readonly float b;
        public readonly float a;

        public Color(float in_r, float in_g, float in_b, float in_a = 1f)
        {
            r = in_r;
            g = in_g;
            b = in_b;
            a = in_a;
        }

    }
}
