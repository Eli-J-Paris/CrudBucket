﻿namespace CrudBucketMVC.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public Contienent contienent { get; set; }
    }
}
