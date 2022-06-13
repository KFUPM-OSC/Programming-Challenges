
namespace Bishop
{
    class med
    {
        /* my monkey brain brute forced this code, haven't checked it but it worked for the provided case
         * so i would like to see it break for other cases too if possible
         */
        public static void Main(String[] args)
        {
            String start;
            String dest;
            String[] path;
            start = "F1";
            dest = "K14";
            path = getBishopPath(16,14,start, dest);
            
            Console.Write("{");
            foreach (String move in path)
            {
                if (move != path[path.Length - 1])
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
            if (dest == start)
            {
                String[] outList = { start };
                return outList;
            }
            String[] pathList = AllPossiblePaths(n,m,start,dest);
            if (pathList != null && pathList.Contains(dest))
            {
                String[] outList = { start, dest };
                return outList;

            }
            if (pathList != null && !pathList.Contains(dest))
            {
                List<String[]> checkedP = new List<String[]>();
                foreach (String path in pathList)
                {
                    String[] startPath = { start };
                    checkedP.Add(getBishopPathRec(n, m, path, dest, startPath));

                        if (!checkedP.Contains(getBishopPathRec(n, m, path, dest, startPath)))
                        {
                            checkedP.Add(getBishopPathRec(n, m, path, dest, startPath));
                        }
                  
                }
                checkedP.Reverse();
                return checkedP.MinBy(p => p.Length);
            }
            return null;

        }
        public static String[] getBishopPathRec(int n, int m, String start, String dest, String[] prevpath)
        {
            String[] pathList = AllPossiblePaths(n,m,start,dest);
            if (pathList != null && pathList.Contains(dest))
            {
                String[] prevpathRec = new string[prevpath.Length + 2];
                for (int i = 0; i < prevpath.Length; i++)
                {
                    prevpathRec[i] = prevpath[i];
                }
                prevpathRec[prevpathRec.Length - 2] = start;
                prevpathRec[prevpathRec.Length - 1] = dest;
                return prevpathRec;
            }
            if (pathList != null && !pathList.Contains(dest))
            {
                String[] prevpathRec = new string[prevpath.Length + 1];
                for (int i = 0; i < prevpath.Length; i++)
                {

                    prevpathRec[i] = prevpath[i];
                }
                prevpathRec[prevpathRec.Length - 1] = start;
                foreach (String path in pathList)
                {
                    if (!prevpathRec.Contains(path))
                    {
                       return getBishopPathRec(n, m, path, dest, prevpathRec);
  
                    }
                }

            }
            return null;

        }

        private static String[] AllPossiblePaths(int n, int m,String start, String dest)
        {
            List<String> solvedLetters = new List<String>();
            int[] encodedStart = Encoder(start);
            int currentColunm = encodedStart[0];

            int currentRow = encodedStart[1];

            int[] encodeddest = Encoder(dest);
            int destColunm = encodeddest[0];

            int destRow = encodeddest[1];


            //  if they have the same slope, then a bishop can move in it's direction
            if (currentRow-currentColunm == destRow - destColunm) return new string[] {start,dest};
            if (currentRow + currentColunm == destRow + destColunm) return new string[] { start, dest };                 
            
            // diagonal movement is done by switching the letter and the number by increments and decrements of 1 
            int j = currentRow;
            int k = currentRow;
            int l = currentRow;
            int c = currentRow;
            int listIterator = 0;
            for (int i = currentColunm + 1; i <= n && j < m; i++) //bottom right
            {
                j++;
                solvedLetters.Add( decoder(i) + "" + j + "");
                listIterator++;
            }
            for (int i = currentColunm - 1; i>0 && k>1; i--) // top left
            {
                k--;

                solvedLetters.Add(decoder(i) + "" + k + "");
                listIterator++;

            }

            for (int i = currentColunm + 1; i <= n && l >1; i++) //top right
            {             
                l--;

                solvedLetters.Add(decoder(i) + "" + l + "")  ;
                listIterator++;
            }

            for (int i = currentColunm - 1; i >0 && c < m; i--)// bottom left
            {    
                c++;
                solvedLetters.Add(decoder(i) + "" + c + "");
                listIterator++;
                
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
    }
}

