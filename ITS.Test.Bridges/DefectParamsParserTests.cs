using ITS.Core.Bridges.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ITS.Test.Bridges
{
    public class DefectParamsParserTests
    {
        [Fact]
        public void ParseTest1()
        {
            //arrange
            var pattern = "F:float;T:float";
            var value = "F=2.01;T=213.4";
            //act
            var res = DefectParamsParser.Parse(value, pattern);
            //assert
            Assert.Equal(new Dictionary<string, string>()
            {
                { "F", "2.01" },
                { "T", "213.4" },
            }, res);
        }
        [Fact]
        public void ParseTest_InvalidPattern1()
        {
            //arrange
            var pattern = "";
            var value = "F=2.01;T=213.4";
            //act
            var res = DefectParamsParser.Parse(value, pattern);
            //assert
            Assert.Null(res);
        }
        [Fact]
        public void ParseTest_InvalidPattern2()
        {
            //arrange
            var pattern = "{}{}123";
            var value = "F=2.01;T=213.4";
            //act
            //assert
            Assert.Throws<ArgumentException>(()=>DefectParamsParser.Parse(value, pattern));
        }
        [Fact]
        public void ParseTest_InvalidPattern3()
        {
            //arrange
            var pattern = ":123;:123";
            var value = "F=2.01;T=213.4";
            //act
            //assert
            Assert.Throws<ArgumentException>(()=>DefectParamsParser.Parse(value, pattern));
        }
        [Fact]
        public void ParseTest_InvalidPattern4()
        {
            //arrange
            var pattern = "F:123;A:123";
            var value = "F=2.01;T=213.4";
            //act
            //assert
            Assert.Throws<ArgumentException>(()=>DefectParamsParser.Parse(value, pattern));
        }
        [Fact]
        public void ParseTest_IntValue()
        {
            //arrange
            var pattern = "F:int";
            var value = "F=201.1";
            //act
            var res = DefectParamsParser.Parse(value, pattern);
            //assert
            Assert.Equal(res, new Dictionary<string, string>()
            {
                { "F", "201.1" },
            });
        }
        [Fact]
        public void GetRulesTest_OrParams1()
        {
            //arrange
            var pattern = "F или L:int";
            //act
            var res = DefectParamsParser.GetRules(pattern);
            //assert
            Assert.Equal(res, new Dictionary<string, string>()
            {
                { "F или L", "int" },
            });
        }
        [Fact]
        public void GetRulesTest_OrParams2()
        {
            //arrange
            var pattern = "F или l,C:int";
            //act
            var res = DefectParamsParser.GetRules(pattern);
            //assert
            Assert.Equal(res, new Dictionary<string, string>()
            {
                { "F или l,C", "int" },
            });
        }
        [Fact]
        public void GetRulesTest_NoParams()
        {
            //arrange
            var pattern = "";
            //act
            var res = DefectParamsParser.GetRules(pattern);
            //assert
            Assert.Null(res);
        }
        [Fact]
        public void ParseTest_NoParams()
        {
            //arrange
            var pattern = "";
            var value = "";
            //act
            var res = DefectParamsParser.Parse(value, pattern);
            //assert
            Assert.Null(res);
        }
        [Fact]
        public void GetRulesTest1_NoParams()
        {
            //arrange
            var pattern = "L(F):float";
            //act
            var res = DefectParamsParser.GetRules(pattern);
            //assert
            Assert.Equal(res, new Dictionary<string, string>()
            {
                { "L(F)", "float" },
            });
        }
    }
}
