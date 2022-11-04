using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace InlineColorPicker
{
    public struct Color32
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color32(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return r;
                    case 1:
                        return g;
                    case 2:
                        return b;
                    case 3:
                        return a;
                }
                return 0;
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.r = value;
                        break;
                    case 1:
                        this.g = value;
                        break;
                    case 2:
                        this.b = value;
                        break;
                    case 3:
                        this.a = value;
                        break;
                }
            }
        }


        public static Color32 black { get => new Color32(0, 0, 0, 1); }
       
        public static Color32 white { get => new Color32(1, 1, 1, 1); }
        public static Color32 clear { get => new Color32(0, 0, 0, 0); }

        public static implicit operator Color32(Color v)
        {
            return new Color32(v.R / 255f, v.G / 255f, v.B / 255f, v.A / 255f);
        }

        public static implicit operator Color(Color32 c)
        {
            byte rr = (byte)(c.r * 255);
            rr = Math.Max((byte)0, Math.Min(rr, (byte)255));

            byte gg = (byte)(c.g * 255);
            gg = Math.Max((byte)0, Math.Min(gg, (byte)255));

            byte bb = (byte)(c.b * 255);
            bb = Math.Max((byte)0, Math.Min(bb, (byte)255));

            byte aa = (byte)(c.a * 255);
            aa = Math.Max((byte)0, Math.Min(aa, (byte)255));

            return Color.FromArgb(aa, rr, gg, bb);
        }

        //颜色字符串 #RRGGBBAA 或#RRGGBB
        static public Color32 GetColor32(string colorStr)
        {
            if (string.IsNullOrEmpty(colorStr))
            {
                return Color32.clear;
            }
            int offset = 0;
            if (colorStr[0] == '#') offset = 1;

            if (colorStr.Length != offset + 6 && colorStr.Length != offset + 8)
                return Color32.clear;

            int r = (HexToDecimal(colorStr[offset]) << 4) | HexToDecimal(colorStr[offset + 1]);
            int g = (HexToDecimal(colorStr[offset + 2]) << 4) | HexToDecimal(colorStr[offset + 3]);
            int b = (HexToDecimal(colorStr[offset + 4]) << 4) | HexToDecimal(colorStr[offset + 5]);
            float f = 1f / 255f;
            int a = 255;
            if (colorStr.Length - offset == 8)
            {
                a = (HexToDecimal(colorStr[offset + 6]) << 4) | HexToDecimal(colorStr[offset + 7]);
            }
            return new Color32(f * r, f * g, f * b, f * a);
        }


        static public int HexToDecimal(char ch)
        {
            switch (ch)
            {
                case '0': return 0x0;
                case '1': return 0x1;
                case '2': return 0x2;
                case '3': return 0x3;
                case '4': return 0x4;
                case '5': return 0x5;
                case '6': return 0x6;
                case '7': return 0x7;
                case '8': return 0x8;
                case '9': return 0x9;
                case 'a':
                case 'A': return 0xA;
                case 'b':
                case 'B': return 0xB;
                case 'c':
                case 'C': return 0xC;
                case 'd':
                case 'D': return 0xD;
                case 'e':
                case 'E': return 0xE;
                case 'f':
                case 'F': return 0xF;
            }
            return 0xF;
        }

    }
}
