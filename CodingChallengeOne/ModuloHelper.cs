namespace CodingChallengeOne
{
    public class ModuloHelper
    {
        public int Modulo(int x, int mod)
        {
            return ((x % mod) + mod) % mod;
        }
    }
}