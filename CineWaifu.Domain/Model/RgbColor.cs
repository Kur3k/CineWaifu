namespace CineWaifu.Domain.Model
{
    public record RgbColor
    {
        public RgbColor(int R, int G, int B)
        {
            this.R = R < 0 ? 0 : R > 255 ? 255 : R;
            this.G = G < 0 ? 0 : G > 255 ? 255 : G;
            this.B = B < 0 ? 0 : B > 255 ? 255 : B;
        }

        public int R { get; init; }
        public int G { get; init; }
        public int B { get; init; }

    }
}
