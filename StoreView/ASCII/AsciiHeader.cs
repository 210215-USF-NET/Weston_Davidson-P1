using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace StoreView
{
    /// <summary>
    /// This class provides the ascii logo header that appears on most navigation pages in our system
    /// </summary>
    public static class AsciiHeader
    {

        public static void AsciiHead()
        {
            var arr = new[]
                {

//Awesome ascii art generator used for logo:
//https://www.patorjk.com/software/taag/#p=display&f=Graffiti&t=Type%20Something%20


@"      ___                   ___          ___          ___          ___          ___          ___                ",
@"     /\  \        ___      /\__\        /\  \        /\  \        /\__\        /\  \        /\  \               ",
@"    /::\  \      /\  \    /::|  |      /::\  \      /::\  \      /:/  /       /::\  \      /::\  \              ",
@"   /:/\ \  \     \:\  \  /:|:|  |     /:/\:\  \    /:/\ \  \    /:/__/       /:/\:\  \    /:/\:\  \             ",
@"  _\:\~\ \  \    /::\__\/:/|:|  |__  /::\~\:\  \  _\:\~\ \  \  /::\  \ ___  /:/  \:\  \  /::\~\:\  \            ",
@" /\ \:\ \ \__\__/:/\/__/:/ |:| /\__\/:/\:\ \:\__\/\ \:\ \ \__\/:/\:\  /\__\/:/__/ \:\__\/:/\:\ \:\__\           ",
@" \:\ \:\ \/__/\/:/  /  \/__|:|/:/  /\:\~\:\ \/__/\:\ \:\ \/__/\/__\:\/:/  /\:\  \ /:/  /\/__\:\/:/  /           ",
@"  \:\ \:\__\ \::/__/       |:/:/  /  \:\ \:\__\   \:\ \:\__\       \::/  /  \:\  /:/  /      \::/  /            ",
@"   \:\/:/  /  \:\__\       |::/  /    \:\ \/__/    \:\/:/  /       /:/  /    \:\/:/  /        \/__/             ",
@"    \::/  /    \/__/       /:/  /      \:\__\       \::/  /       /:/  /      \::/  /                           ",
@"     \/__/                 \/__/        \/__/        \/__/        \/__/        \/__/ Your home for Synthesizers!",


        };

            Console.WriteLine("\n");
            foreach (string line in arr){
                Console.WriteLine(line);
                }
            Console.WriteLine("\n");


        }

    }
}
