using System;
using System.Threading;

namespace Problem {
    class Program {
        public const int height = 20;
        public const int Length = 40;

        static void Main(string[] args) {
            Random rand = new Random();
            Worm[] worms = new Worm[Length];
            for(int i = 0; i < Length; i++){
                worms[i] = new Worm(i, Math.Abs(rand.Next()) % (height / 3) + 3);

            }
            while(true) {
                foreach(Worm worm in worms)
                    worm.Draw();
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }

    class Worm {
        public int Top {get; set;}
        public int Left {get; set;} 
        public int Length {get; set;}

        public Worm(int left, int length) {
            Left    = left;
            Length  = length;
            Top     = -Length + 1 - new Random().Next() % 5;
        }

        public void Draw() {

            for(int i = 0; i < Length; i++){
                Console.CursorLeft = Left;
                if(Top + i < 0 || Top + i > Program.height )
                    continue;
                Console.CursorTop = Top + i;
                int end = Length - 1;
                int preEnd = Length - 2;
                
                ConsoleColor color;
                if(i == end)
                    color = ConsoleColor.White;
                else if(i == preEnd) 
                    color = ConsoleColor.Green;
                else 
                    color = ConsoleColor.DarkGreen;

                Console.ForegroundColor = color;
                Console.Write((char)(new Random().Next() % 256));
                Console.ResetColor();
            }
            Top++;
            if(Top > Program.height)
                Top = -Length + 1;
        }
    }
}
