using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connections
{
    public class TaskUtils
    {
        
        public static int StudNumber(List<Student> AllStudents, string requiredName) 
        {
            for (int i = 0; i < AllStudents.Count(); i++)
            {
                if (AllStudents[i].Name==requiredName)
                {
                    return i;
                }
            }
            return -1;
        }
        public static bool DoKnow(List<Student> AllStudents, string wanted, int stud)
        {
            for (int i = 0; i < AllStudents[stud].KnownCount; i++)
            {
                if (AllStudents[stud].KnownStudents[i]==wanted)
                {
                    return true;
                }
            }
            return false;
        }
        public static void FindPossiblePairs(List<Student> AllStudents, bool[] Validated, 
            int firstStud, ref bool found, ref List<string> FoundPairs, string wanted)
        {
            int nextStud;
            for (int i = 0; i < AllStudents[firstStud].KnownCount; i++)
            {
                Student current = AllStudents[firstStud];
                if (current.KnownStudents[i] == wanted)
                {
                    found = true;
                }
                else
                {
                    nextStud = StudNumber(AllStudents, current.KnownStudents[i]);

                    if (!Validated[nextStud])
                    {
                        
                        Validated[nextStud] = true;
                        FoundPairs.Add(current.KnownStudents[i]);

                        FindPossiblePairs(AllStudents, Validated, nextStud, ref found, ref FoundPairs, wanted);

                        if (found)
                        {
                            break;
                        }
                        else
                        {
                            FoundPairs.RemoveAt(FoundPairs.Count() - 1);
                        }

                    }
                }
            }
        }
        public static void FindFriendsFromBoth(List<Student> AllStudents, List<Pairs> AllPairs)
        {
            int studnum1;

            for (int i = 0; i < AllPairs.Count(); i++)
            {
                bool found = false;

                bool[] Validated = new bool[AllStudents.Count()];

                List<string> FoundPairs = new List<string>();

                studnum1 = StudNumber(AllStudents, AllPairs[i].Name1);

                if (studnum1 != -1)
                {
                    if (DoKnow(AllStudents, AllPairs[i].Name2, studnum1))
                    {
                        AllPairs[i].Relation("jau pažįstami");
                    }
                    else
                    {
                        Validated[studnum1] = true;
                        FindPossiblePairs(AllStudents, Validated, studnum1, ref found, ref FoundPairs, AllPairs[i].Name2);

                        if(found)
                        {
                            AllPairs[i].Relation(FromListToString(FoundPairs));
                        }
                        else
                        {
                            AllPairs[i].Relation("negali susipažinti");
                        }
                    }
                }
                else
                {
                    AllPairs[i].Relation("negali susipažinti");
                }

            }
        }
        public static string FromListToString(List<string> Strings)
        {
            string final = string.Empty;
            for (int i = 0; i < Strings.Count(); i++)
            {
                final += Strings[i] + " ";
            }
            final.Remove(final.Length - 1,1);
            
            return "bendri pažįstami:" + final;
        }
    }
}