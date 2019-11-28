using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WhatIs1CFramework.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [DataType(DataType.Html)]
        public string Text { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
