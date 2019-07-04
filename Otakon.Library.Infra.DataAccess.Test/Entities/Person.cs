﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Otakon.Library.Infra.DataAccess.Test.Entities
{
    public class Person
    {

        public Person()
        {

        }

        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
