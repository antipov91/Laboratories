using UnityEngine;

namespace UnityPlot
{
    public static class Brushes
    {
        public static void Pencil(Texture2D texture, int x, int y, Color color)
        {
            texture.SetPixel(x, y, color);
        }

        public static void PencilSize2(Texture2D texture, int x, int y, Color color)
        {
            texture.SetPixels(x, y, 2, 2, new Color[4] { color, color, color, color });
        }
    }
}