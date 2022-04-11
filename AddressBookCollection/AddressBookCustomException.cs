﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_Problem_Collections
{
    class AddressBookCustomException : Exception
    {
        public enum ExceptionType
        {
            Wrong_city_name, Wrong_state_name
        }
        private readonly ExceptionType type;
       
        public AddressBookCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}