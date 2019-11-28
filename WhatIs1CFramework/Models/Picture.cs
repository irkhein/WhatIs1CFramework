using System;
using System.Web;
namespace WhatIs1CFramework.Models
{
    public class Picture
    {
        public int PictureID { get; set; }
        public int ArticleID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageByte { get; set; }
        public Article Article { get; set; }
    }
}
