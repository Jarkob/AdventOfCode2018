using System;
namespace Day03
{
    public class Claim
    {
        public Claim(int id, int paddingLeft, int paddingTop, int width, int height)
        {
            this.Id = id;
            this.PaddingLeft = paddingLeft;
            this.PaddingTop = paddingTop;
            this.Width = width;
            this.Height = height;
        }

        public int Id { get; set; }
        public int PaddingLeft { get; set; }
        public int PaddingTop { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
