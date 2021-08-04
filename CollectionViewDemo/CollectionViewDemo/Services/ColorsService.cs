using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionViewDemo.Services
{
    public class ColorsService
    {
        public static List<SquareColor> GetColors(int numberOfSquares = 15)
        {
            int colorSpace = 255 / numberOfSquares;
            int color = 20;
            List<SquareColor> SquareColors = new List<SquareColor>();
            for (int i = 0; i < numberOfSquares; i++)
            {
                SquareColors.Add(new SquareColor
                {
                    HexCode = $"#00{color:x2}00",
                    Size = color
                });
                color += colorSpace;
            }
            return SquareColors;
        }
    }

    public class SquareColor
    {
        public string HexCode { get; set; }
        public double Size { get; set; }
    }

}
