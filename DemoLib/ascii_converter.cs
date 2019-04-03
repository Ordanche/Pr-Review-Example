using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLib.demo
{
    public static class ascii_converter
    {
        public static string convert_to_ascii(Bitmap image)
        {
            string ret = "";
            if (image != null)
            {
                Boolean toggle = false;
                for (int i = 0; i < image.Height; i++)
                {
                    for (int j = 0; j < image.Width; j++)
                    {
                        int red = 0; int green = 0; int blue = 0;
                        Color level = Color.Black;
                        try
                        {
                            Color Col = image.GetPixel(j, i);
                            red = (Col.R + Col.G + Col.B) / 3;
                            green = (Col.R + Col.G + Col.B) / 3;
                            blue = (Col.R + Col.G + Col.B) / 3;
                            // int tr = (Col.R + Col.G + Col.B);
                            level = Color.FromArgb(red, green, blue);
                        }
                        catch (Exception e)
                        {
                        }

                        if (!toggle)
                        {
                            int p = (level.R * 10) / 255;
                            if (p == 0 || p == 1)
                            {
                                ret += "#";
                            }
                            else
                            {
                                if (p == 2)
                                {
                                    ret += "@";
                                }
                                else
                                {
                                    if (p == 3)
                                    {
                                        ret += "%";
                                    }
                                    else
                                    {
                                        if (p == 4)
                                        {
                                            ret += "=";
                                        }
                                        else
                                        {
                                            if (p == 5)
                                            {
                                                ret += "+";
                                            }
                                            else
                                            {
                                                if (p == 6)
                                                {
                                                    ret += "*";
                                                }
                                                else
                                                {
                                                    if (p == 7)
                                                    {
                                                        ret += ":";
                                                    }
                                                    else
                                                    {
                                                        if (p == 8)
                                                        {
                                                            ret += "-";
                                                        }
                                                        else
                                                        {
                                                            if (p == 9)
                                                            {
                                                                ret += ".";
                                                            }
                                                            else
                                                            {
                                                                ret += "&nbsp;";
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (!toggle)
                    {
                        ret += "<BR>";
                        toggle = true;;
                    }
                    else
                    {
                        toggle = false;
                    }
                }
            }

            return ret;
        }
    }
}