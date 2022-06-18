
using System;
using System.Collections.Generic;
namespace Bishop
{
    class med
    {
        public static void Main(String[] args)
        {
            String start;
            String dest;
            String[] path;
            start = "F1";
            dest = "K14";
            path = getBishopPath(16, 14, start, dest);
            Console.Write("{");
            foreach (String move in path)
            {
                if (move != path[path.Length-1])
                {
                    Console.Write(move + ",");
                }
                else
                {
                    Console.Write(move);
                }
            }
            Console.Write("}");
        }

        public static String[] getBishopPath(int n, int m, String start, String dest)
        {
                var previous = new Dictionary<String, String>();
                var visited = new List<String>();
                bool[,] adj = AdjList(n, m);
                var queue = new Queue<String>();
                int[] destEncode = Encoder(dest);

                List<String[]> paths = new List<string[]>();
                queue.Enqueue(start);
                while (queue.Count > 0)
                {

                    var vx = queue.Dequeue();

                    var evx = Encoder(vx);
                    if (adj[evx[0], evx[1]] == true)
                    {
                        continue;
                    }
                    adj[evx[0], evx[1]] = true;
                    visited.Add(vx);
                    String[] neigbhors = pMoves(n, m, vx);
                    foreach (String neigbhor in neigbhors)
                    {
                        var evx2 = Encoder(neigbhor);
                        if (previous.ContainsKey(neigbhor))
                        {
                            continue;
                        }
                        if (adj[evx2[0], evx2[1]] == false)
                        {
                            previous[neigbhor] = vx;
                            queue.Enqueue(neigbhor);
                        }
                    }
                }
               var path = new List<String> { };

               var current = dest;
               while (!current.Equals(start))
                    {
                        path.Add(current);
                        current = previous[current];
                    }

               path.Add(start);
               path.Reverse();

               return path.ToArray();
                


        }


        public static String[] pMoves (int n, int m, String s)
        {
            int[] encodedStart = Encoder(s);
            int currentColunm = encodedStart[0];

            int currentRow = encodedStart[1];
            List<String> solvedLetters = new List<String>();
            int j = currentRow;
            int k = currentRow;
            int l = currentRow;
            int c = currentRow;
 
            for (int i = currentColunm + 1; i <= n && j < m; i++) //bottom right
            {
                j++;
                solvedLetters.Add(decoder(i) + "" + j + "");
  
            }
            for (int i = currentColunm - 1; i > 0 && k > 1; i--) // top left
            {
                k--;

                solvedLetters.Add(decoder(i) + "" + k + "");


            }

            for (int i = currentColunm + 1; i <= n && l > 1; i++) //top right
            {
                l--;

                solvedLetters.Add(decoder(i) + "" + l + "");

            }

            for (int i = currentColunm - 1; i > 0 && c < m; i--)// bottom left
            {
                c++;
                solvedLetters.Add(decoder(i) + "" + c + "");


            }
            return solvedLetters.ToArray();

        }
        public static int[] Encoder(String s)
        {
            int colunm;
            int row;
            if (s.Length == 2)
            {
                 
                 colunm = s[0]-64;
                 row = int.Parse(s[1] + "");

            }
            else
            {
                 colunm = s[0] - 64;
                row = int.Parse( s.Substring(1)+ "");
            }
            int[] returner = { colunm, row };
            return returner;
        }
        public static String decoder (int i)
        {
            switch (i) {
                case (1):
                    return "A";
                    break;
                case (2):
                    return "B";
                    break;
                case (3):
                    return "C";
                    break;
                case (4):
                    return "D";
                    break;
                case (5):
                    return "E";
                    break;
                case (6):
                    return "F";
                    break;
                case (7):
                    return "G";
                    break;
                case (8):
                    return "H";
                    break;
                case (9):
                    return "I";
                    break;
                case (10):
                    return "J";
                    break;
                case (11):
                    return "K";
                    break;
                case (12):
                    return "L";
                    break;
                case (13):
                    return "M";
                    break;
                case (14):
                    return "N";
                    break;
                case (15):
                    return "O";
                    break;
                case (16):
                    return "P";
                    break;
                case (17):
                    return "Q";
                    break;
                case (18):
                    return "R";
                    break;
                case (19):
                    return "S";
                    break;
                case (20):
                    return "T";
                    break;
                case (21):
                    return "U";
                    break;
                case (22):
                    return "V";
                    break;
                case (23):
                    return "W";
                    break;
                case (24):
                    return "X";
                    break;
                case (25):
                    return "Y";
                    break;
                case (26):
                    return "Z";
                    break;
                default:
                    return "invalid";
            }
            return "invalid";
        }
        public static bool[,] AdjList(int n,int m)
        {
            bool[,] List = new bool[n+1,m+1];
           
            for (int i=1; i<n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    List[i,j] = false;
                }
            }
            return List;
        }
     
        

    }
}
