using System;

namespace OOP
{
    public class OrderException : Exception
    {
        public OrderException()
            : base("can't make order with only 1 item, please add more and thank you. ")
        {
        }
    }
}