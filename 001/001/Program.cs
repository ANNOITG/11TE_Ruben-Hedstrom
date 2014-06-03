using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class A
    {
        public void publicA()
        {
        }

        protected void protectedA()
        {
        }

        private void privateA()
        {
        }

        class AB
        {
            public void publicAB()
            {
            }

            protected void protectedAB()
            {
            }

            private void privateAB()
            {
            }
        }
    }
    class B : A
    {
        public void publicB()
        {
        }

        protected void protectedB()
        {
        }

        private void privateB()
        {
        }
    }
}
