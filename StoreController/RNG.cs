using System;

namespace StoreController
{
    public static class RNG
    {
        private static Random rand = new Random();

        public static int RandomGen(){
            return rand.Next(10000, 20001);
        }
    }
}