using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : AbstractClass
    {
        public string Model { get; set; }
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
