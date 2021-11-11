using ITS.Core.Bridges.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ITS.Test.Bridges
{
    public class TerritoryTests
    {
        class T : Territory
        {
            public T(string s, int i) : base(s)
            {
                ID = i;
            }
        }
        [Fact]
        public void ToStringTest1()
        {
            //arrange
            T obj = new T("Адыгея республика", 1);
            //act
            string name = obj.ToString();
            //assert
            Assert.Equal("Адыгея республика - 01", name);
        }
        [Fact]
        public void ToStringTest2()
        {
            //arrange
            T obj = new T("Адыгея республика", 11);
            //act
            string name = obj.ToString();
            //assert
            Assert.Equal("Адыгея республика - 11", name);
        }
    }
}
