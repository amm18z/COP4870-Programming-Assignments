﻿using Canvas.Models;
using Canvas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Canvas.ViewModels
{
    public class PersonDialogViewModel
    {
        private Person? person;  // pass through properties

        //private string name;
        public string Name
        {
            get { return person?.Name ?? string.Empty; }
            set 
            { 
                if (person == null) person = new Person();
                person.Name = value; 
            }
        }

        //private string classification;
        public string Classification
        {
            get { return person?.Classification ?? string.Empty; }
            set 
            { 
                if (person == null) person = new Person();
                person.Classification = value; 
            }
        }

        public int Grades   // kind of a place holder because 'Grades' on 'Person' model isn't really intended to be an integer.
        {
            get { return person?.Grades ?? 0; }
            set
            {
                if (person == null) person = new Person();
                person.Grades = value;
            }
        }

        public PersonDialogViewModel(int pId)
        {
            if(pId == 0)        // Person does not yet exist
            {
                person = new Person();
            }
            else
            {
                person = PersonService.Current.Get(pId) ?? new Person();   // Update button will display this person when we click on it
            }
            
        }

        public void AddPerson()
        {
            if(person != null)
            {
                PersonService.Current.AddOrUpdate(person) ;
            }
        }
    }
}
