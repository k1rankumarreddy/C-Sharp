using System;
using System.Collections.Generic;
using System.Linq;

class Solution { 
    static void Main(String[] args) {
        string[][] enrollments = {
          new string[] {"58", "Linear Algebra"},
          new string[] {"94", "Art History"},
          new string[] {"17", "Software Design"},
          new string[] {"58", "Mechanics"},
          new string[] {"58", "Economics"},
          new string[] {"17", "Linear Algebra"},
          new string[] {"17", "Political Science"},
          new string[] {"94", "Economics"},
          new string[] {"25", "Economics"},
          new string[] {"58", "Software Design"}, 
        };
        foreach(var i in find_pairs(enrollments))
            Console.WriteLine("["+i.Key[0]+", "+i.Key[1]+"]: ["+ string.Join( ", ", i.Value.Select(s => $"\"{s}\""))+"]");
    }
    public static List<KeyValuePair<int[], string[]>> find_pairs(string[][] student_courses) {
        var map = student_courses.Select(course => new KeyValuePair<string, string>(course[0], course[1])).GroupBy(kvp => kvp.Key).ToDictionary(group => group.Key, group => group.Select(kvp => kvp.Value).ToList());
        var stu = map.Keys.ToArray();
        var sol = new List<KeyValuePair<int[], string[]>>();
        for (int i = 0; i<stu.Length; i++)
            for (int j = i+1; j<stu.Length; j++)
                sol.Add(new KeyValuePair<int[], string[]>(new[] { int.Parse(stu[i]), int.Parse(stu[j]) }, map[stu[i]].Intersect(map[stu[j]]).ToArray()));
        return sol;
    }
}


/*
Output :
--------
[58, 94]: ["Economics"]
[58, 17]: ["Linear Algebra", "Software Design"]
[58, 25]: ["Economics"]
[94, 17]: []
[94, 25]: ["Economics"]
[17, 25]: []

*/
