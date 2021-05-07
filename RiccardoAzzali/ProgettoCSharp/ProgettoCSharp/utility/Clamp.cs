namespace utility
{
    public class Clamp
    {
        private Clamp()
        {
        }

        public static int clamp(int var, int min, int max)
        {
            return var < min ? min : (var > max ? max : var);
        }

    }

}