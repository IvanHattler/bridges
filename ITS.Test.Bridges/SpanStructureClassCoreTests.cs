using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.Domain;
using System;
using Xunit;

namespace ITS.Test.Bridges
{
    public class SpanStructureClassCoreTests
    {
        #region CrossScheme
        [Fact]
        public void CrossSchemeTest1()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0.7f,
                CrossSchemeKb = 0.7f,
                CrossSchemePileDistances = new float[]
                {
                    1.71f,
                    1.71f,
                    1.71f,
                    1.69f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("К0,70+1,71x4+К0,70", scheme);
        }
        [Fact]
        public void CrossSchemeTest2()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0.213f,
                CrossSchemeKb = 0.666f,
                CrossSchemePileDistances = new float[]
                {
                    1.71f,
                    1.71f,
                    1.71f,
                    1.7f,
                    1.7f,
                    1.7f,
                    1.69f,
                    1.69f,
                    1.69f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("К0,21+1,70x9+К0,67", scheme);
        }
        [Fact]
        public void CrossSchemeTest3()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0.213f,
                CrossSchemeKb = 0.666f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                    2f,
                    3f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("К0,21+1,00+2,00+3,00+К0,67", scheme);
        }
        [Fact]
        public void CrossSchemeTest4()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0.213f,
                CrossSchemeKb = 0.666f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("К0,21+1,00+К0,67", scheme);
        }
        [Fact]
        public void CrossSchemeTest5()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0.213f,
                CrossSchemeKb = 0.666f,
                CrossSchemePileDistances = null
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("", scheme);
        }
        [Fact]
        public void CrossSchemeTest6()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0f,
                CrossSchemeKb = 0f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("1,00", scheme);
        }
        [Fact]
        public void CrossSchemeTest7()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0f,
                CrossSchemeKb = 1f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("1,00+К1,00", scheme);
        }
        [Fact]
        public void CrossSchemeTest8()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 1f,
                CrossSchemeKb = 0f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("К1,00+1,00", scheme);
        }
        [Fact]
        public void CrossSchemeTest9()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 1f,
                CrossSchemeKb = 0f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                    2f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("К1,00+1,00+2,00", scheme);
        }
        [Fact]
        public void CrossSchemeTest10()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0f,
                CrossSchemeKb = 1f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                    2f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("1,00+2,00+К1,00", scheme);
        }
        [Fact]
        public void CrossSchemeTest11()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 0f,
                CrossSchemeKb = 1f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                    1f,
                    1f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("1,00x3+К1,00", scheme);
        }
        [Fact]
        public void CrossSchemeTest12()
        {
            //arrange
            var obj = new SpanStructure()
            {
                CrossSchemeKa = 1f,
                CrossSchemeKb = 0f,
                CrossSchemePileDistances = new float[]
                {
                    1f,
                    1f,
                    1f,
                }
            };
            //act
            string scheme = obj.CrossScheme;
            //assert
            Assert.Equal("К1,00+1,00x3", scheme);
        }
        #endregion

        #region operator ==
        [Fact]
        public void EqualityTest_Equ1_null()
        {
            //arrange
            var obj1 = new SpanStructure()
            {
                CrossSchemeKa = 0.213f,
                CrossSchemeKb = 0.666f,
            };
            SpanStructure obj2 = null;
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_Equ2_null()
        {
            //arrange
            SpanStructure obj1 = null;
            SpanStructure obj2 = null;
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_Equ3()
        {
            //arrange
            SpanStructure obj1 = new SpanStructure();
            SpanStructure obj2 = new SpanStructure();
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_Equ4_Number()
        {
            //arrange
            SpanStructure obj1 = new SpanStructure() { Number = 1 };
            SpanStructure obj2 = new SpanStructure() { Number = 2 };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_Equ5_CrossSchemePileDistances()
        {
            //arrange
            SpanStructure obj1 = new SpanStructure() { CrossSchemePileDistances = null };
            SpanStructure obj2 = new SpanStructure()
            {
                CrossSchemePileDistances = new float[] { 1f, 3f }
            };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_Equ6_CrossSchemePileDistances()
        {
            //arrange
            SpanStructure obj1 = new SpanStructure() {
                CrossSchemePileDistances = new float[] { 1f, 2f},
            };
            SpanStructure obj2 = new SpanStructure()
            {
                CrossSchemePileDistances = new float[] { },
            };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_Equ7_CrossSchemePileDistances()
        {
            //arrange
            SpanStructure obj1 = new SpanStructure() {
                CrossSchemePileDistances = new float[] { 1f, 2f },
            };
            SpanStructure obj2 = new SpanStructure()
            {
                CrossSchemePileDistances = new float[] { 1f, 2.000001f },
            };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_Equ8_Bridge()
        {
            //arrange
            SpanStructure obj1 = new SpanStructure() {
                Bridge = new Bridge(),
            };
            SpanStructure obj2 = new SpanStructure()
            {
                Bridge = null,
            };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_Equ9_LongitudeScheme()
        {
            //arrange
            SpanStructure obj1 = new SpanStructure() {
                LongitudeScheme = "",
            };
            SpanStructure obj2 = new SpanStructure()
            {
                LongitudeScheme = "qwe",
            };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        #endregion
    }
}


