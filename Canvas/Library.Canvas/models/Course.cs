﻿using System.Data.SqlTypes;

namespace Canvas.Models 
{
    public class Course // this is a public class (and not internal) because it's a model (akin to a record in a database)
    {
        public int Id { get; set; }

        public string? Code{get; set;}
        
        public string? Name{get; set;}

        public string? Description{get; set;}

        public List<int> Roster{get; set;}

        // public List<int>? Assignments{get; set;}

        //public List<int>? Modules{get; set;}    // if Module has CourseId on it, why is this even needed?
        public Course() // default constructor, replaces automatic constructor
        {
            // Id = Guid.NewGuid();
            // replacing this ^ with something on the service to generate IDs safely (no repeats)
        }

        public override string ToString() //equivalent to overloading the insertion operation in C++ so that you can cout a custom class object
        {
            return $"{Code} - {Name} | Students: {Roster?.Count()}"; // "13. When selected from a list or search results, a course should show all its information. Only the course code and name should show in the lists."
        }
    }

}