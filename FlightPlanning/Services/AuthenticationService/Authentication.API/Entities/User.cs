﻿using System;

namespace Authentication.API.Entities
{
    public class User
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}