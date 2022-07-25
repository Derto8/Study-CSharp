using System.Drawing;

namespace LearningCShap.Classies.ASCII
{
    class BitmapToASCIIConventer
    {
        private readonly Bitmap _bitmap;
        private readonly char[] asciiTableForBlackBackground = { '.', ',', ':', '+', '*', '?', '%', 'S', '#', '@' };
        private readonly char[] asciiTableForWhiteBackground = { '@', '#', 'S', '%', '?', '*', '+', ':', ',', '.' };

        public BitmapToASCIIConventer(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public char[][] ConvertForWhiteBackground()
        {
            var result = new char[_bitmap.Height][];

            for (int y = 0; y < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];
                for (int x = 0; x < _bitmap.Width; x++)
                {
                    int mapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, asciiTableForWhiteBackground.Length - 1);
                    result[y][x] = asciiTableForWhiteBackground[mapIndex];
                }
            }
            return result;
        }

        public char[][] ConvertForBlackBackground()
        {
            var result = new char[_bitmap.Height][];

            for (int y = 0; y < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];
                for (int x = 0; x < _bitmap.Width; x++)
                {
                    int mapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, asciiTableForBlackBackground.Length - 1);
                    result[y][x] = asciiTableForBlackBackground[mapIndex];
                }
            }
            return result;
        }

        private float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
        {
            return ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
    }
}
