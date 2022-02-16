﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutMovie.Models
{
    public class Actors
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
    }
}
