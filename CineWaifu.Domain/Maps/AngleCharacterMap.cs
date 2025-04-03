namespace CineWaifu.Domain.Maps
{
    public static class AngleCharacterMap
    {
        public static char Map(int angle)
        {
            if (angle >= -45 && angle < 45)
            {
                return '/';
            }
            else if (angle >= 45 && angle < 135)
            {
                return '|';
            }
            else if (angle >= 135 && angle < 225)
            {
                return '\\';
            }
            else
            {
                return '-';
            }
        }
    }
}
