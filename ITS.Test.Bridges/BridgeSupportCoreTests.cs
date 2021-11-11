using ITS.Core.Bridges.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ITS.Test.Bridges
{
    public class BridgeSupportCoreTests
    {
        #region HeightAsString
        [Fact]
        public void HeightAsStringTest1()
        {
            //arrange
            var obj = new BridgeSupport()
            {
                Heights = new []
                {
                    1.6f,
                    2.95f,
                }
            };
            //act
            string a = obj.HeightsAsString;
            //assert
            Assert.Equal("1,60; 2,95",a);
        }
        [Fact]
        public void HeightAsStringTest2()
        {
            //arrange
            var obj = new BridgeSupport()
            {
                Heights = new []
                {
                    1.6f,
                }
            };
            //act
            string a = obj.HeightsAsString;
            //assert
            Assert.Equal("1,60",a);
        }
        [Fact]
        public void HeightAsStringTest3()
        {
            //arrange
            var obj = new BridgeSupport()
            {
                Heights = new []
                {
                    1.6f,
                    1.6f,
                    1.6f,
                    1.6f,
                    1.6f,
                    1.6f,
                }
            };
            //act
            string a = obj.HeightsAsString;
            //assert
            Assert.Equal("1,60; 1,60; 1,60; 1,60; 1,60; 1,60", a);
        }
        #endregion

        #region Scheme
        [Fact]
        public void SchemeTest1()
        {
            //arrange
            var obj = new BridgeSupport()
            {
                SchemeKLeft = 0.7f,
                SchemeKRight = 0.7f,
                SchemePileDistances = new float[]
                {
                    1.71f,
                    1.71f,
                    1.71f,
                    1.69f,
                }
            };
            //act
            string a = obj.Scheme;
            //assert
            Assert.Equal("К0,70+1,71x4+К0,70", a);
        }
        [Fact]
        public void SchemeTest2()
        {
            //arrange
            var obj = new BridgeSupport()
            {
                SchemeKLeft = 0.7f,
                SchemeKRight = 0.7f,
                SchemePileDistances = new float[]
                {
                    1.71f,
                    1.71f,
                    1.71f,
                    1.69f,
                },
                SchemePileRowDistance1 = 1.3f,
            };
            //act
            string a = obj.Scheme;
            //assert
            Assert.Equal("{1,30}(К0,70+1,71x4+К0,70)", a);
        }
        [Fact]
        public void SchemeTest3()
        {
            //arrange
            var obj = new BridgeSupport()
            {
                SchemeKLeft = 0.7f,
                SchemeKRight = 0.7f,
                SchemePileDistances = new float[]
                {
                    1.71f,
                    1.71f,
                    1.71f,
                    1.69f,
                },
                SchemePileRowDistance1 = 1.3f,
                SchemePileRowDistance2 = 1.2f,
            };
            //act
            string a = obj.Scheme;
            //assert
            Assert.Equal("{1,30+1,20}(К0,70+1,71x4+К0,70)", a);
        }
        #endregion

        #region operator ==
        [Fact]
        public void EqualityTest_DefaultConstructors()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport();
            BridgeSupport obj2 = new BridgeSupport();
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_DifferentBridgeProperty()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Bridge = null };
            BridgeSupport obj2 = new BridgeSupport() { Bridge = new Bridge() };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }

        #region Heights
        [Fact]
        public void EqualityTest_SameHeights()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Heights = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport() { Heights = new float[] { 1f, 2f, 3f } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_DifferentHeightsElement()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Heights = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport() { Heights = new float[] { 1f, 2f, 3.0001f } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_DifferentHeightsNullAndNotNull()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Heights = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport() { Heights = null };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_DifferentHeights()
        {
            //arrange
            float a = 0.9f + 0.1f;
            BridgeSupport obj1 = new BridgeSupport() { Heights = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport() { Heights = new float[] { a, a*2, a*3 } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_SameHeightsGetCopy()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Heights = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport();
            obj2.CopyFrom(obj1);
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        #endregion   
        
        #region SchemePileDistances
        [Fact]
        public void EqualityTest_SameSchemePileDistances()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { SchemePileDistances = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport() { SchemePileDistances = new float[] { 1f, 2f, 3f } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_DifferentSchemePileDistancesElement()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { SchemePileDistances = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport() { SchemePileDistances = new float[] { 1f, 2f, 3.0001f } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_DifferentSchemePileDistancesNullAndNotNull()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { SchemePileDistances = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport() { SchemePileDistances = null };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_DifferentSchemePileDistances()
        {
            //arrange
            float a = 0.9f + 0.1f;
            BridgeSupport obj1 = new BridgeSupport() { SchemePileDistances = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport() { SchemePileDistances = new float[] { a, a*2, a*3 } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_SameSchemePileDistancesGetCopy()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { SchemePileDistances = new float[] { 1f, 2f, 3f } };
            BridgeSupport obj2 = new BridgeSupport();
            obj2.CopyFrom(obj1);
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        #endregion

        [Fact]
        public void EqualityTest_DifferentNumberProperty()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Number = 1 };
            BridgeSupport obj2 = new BridgeSupport() { Number = 2 };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_NullAndNotNull()
        {
            //arrange
            BridgeSupport obj1 = null;
            BridgeSupport obj2 = new BridgeSupport() { Heights = new float[] { 1f, 2f, 3.0001f } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_Nulls()
        {
            //arrange
            BridgeSupport obj1 = null;
            BridgeSupport obj2 = null;
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_SameCrossbarHeight()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { CrossbarHeight = 1f };
            BridgeSupport obj2 = new BridgeSupport() { CrossbarHeight = 1f };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_DifferentCrossbarHeight()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { CrossbarHeight = 1f };
            BridgeSupport obj2 = new BridgeSupport() { CrossbarHeight = 1.000001f };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        //[Fact]
        //public void Test1()
        //{
        //    //arrange
        //    float a = 1f, b = 1f;
        //    b *= 2f;
        //    //act
        //    //assert
        //    Assert.True(a == b/2f);
        //}
        #endregion

        #region operator !=
        [Fact]
        public void EqualityTest_NotEqu1()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport();
            BridgeSupport obj2 = new BridgeSupport();
            //act
            var res = obj1 != obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_NotEqu2()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { PileCrossSectionHeight = null };
            BridgeSupport obj2 = new BridgeSupport() { PileCrossSectionHeight = 1f };
            //act
            var res = obj1 != obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_NotEqu3()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { PileCrossSectionHeight = 1f };
            BridgeSupport obj2 = new BridgeSupport() { PileCrossSectionHeight = 1f };
            //act
            var res = obj1 != obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_NotEqu4()
        {
            //arrange
            BridgeSupport obj1 = null;
            BridgeSupport obj2 = new BridgeSupport() { PileCrossSectionHeight = 1f };
            //act
            var res = obj1 != obj2;
            //assert
            Assert.True(res);
        }
        #endregion

        #region TypicalProject
        [Fact]
        public void EqualityTest_TypicalProject1()
        {
            //arrange
            var proj1 = new TypicalProject() { Name = "", Target = "йцу" };
            var proj2 = new TypicalProject() { Name = "", Target = "" };
            BridgeSupport obj1 = new BridgeSupport() { TypicalProject = proj1 };
            BridgeSupport obj2 = new BridgeSupport() { TypicalProject = proj2 };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_TypicalProject2()
        {
            //arrange
            var proj1 = new TypicalProject() { Name = "123", Target = "" };
            var proj2 = new TypicalProject() { Name = "", Target = "" };
            BridgeSupport obj1 = new BridgeSupport() { TypicalProject = proj1 };
            BridgeSupport obj2 = new BridgeSupport() { TypicalProject = proj2 };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_TypicalProject3()
        {
            //arrange
            var proj1 = new TypicalProject() { Name = "", Target = "" };
            var proj2 = new TypicalProject() { Name = "", Target = "" };
            BridgeSupport obj1 = new BridgeSupport() { TypicalProject = proj1 };
            BridgeSupport obj2 = new BridgeSupport() { TypicalProject = proj2 };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_TypicalProject4()
        {
            //arrange
            var proj = new TypicalProject() { Name = "", Target = "" };
            BridgeSupport obj1 = new BridgeSupport() { TypicalProject = proj };
            BridgeSupport obj2 = new BridgeSupport() { TypicalProject = proj };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        #endregion

        #region FloatNullable
        [Theory]
        [InlineData(1f)]
        [InlineData(2f)]
        [InlineData(MathF.E)]
        [InlineData(MathF.PI)]
        [InlineData(float.Epsilon)]
        [InlineData(float.MaxValue)]
        [InlineData(float.MinValue)]
        public void EqualityTest_FloatNullable1(float mpsa)
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { MassivePartSizeAcross = mpsa };
            BridgeSupport obj2 = new BridgeSupport() { MassivePartSizeAcross = mpsa };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_FloatNullable2()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { MassivePartSizeAcross = 1f };
            BridgeSupport obj2 = new BridgeSupport() { MassivePartSizeAcross = 1.5f };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_FloatNullable3()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { MassivePartSizeAcross = null };
            BridgeSupport obj2 = new BridgeSupport() { MassivePartSizeAcross = 1.5f };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_FloatNullable4()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { MassivePartSizeAcross = null };
            BridgeSupport obj2 = new BridgeSupport() { MassivePartSizeAcross = null };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_FloatNullable5()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { MassivePartSizeAcross = 1.0001f };
            BridgeSupport obj2 = new BridgeSupport() { MassivePartSizeAcross = 1.0002f };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        #endregion

        #region Material
        [Fact]
        public void EqualityTest_Material1()
        {
            //arrange
            var mat = new Material();
            BridgeSupport obj1 = new BridgeSupport() { Material = mat };
            BridgeSupport obj2 = new BridgeSupport() { Material = mat };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_Material2()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Material = new Material() };
            BridgeSupport obj2 = new BridgeSupport() { Material = new Material() };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_Material3()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Material = new Material() { Name = "123"} };
            BridgeSupport obj2 = new BridgeSupport() { Material = new Material() };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_Material4()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Material = new Material() { Name = "123"} };
            BridgeSupport obj2 = new BridgeSupport() { Material = new Material() { Name = "123" } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualityTest_Material5()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Material = null };
            BridgeSupport obj2 = new BridgeSupport() { Material = new Material() { Name = "123" } };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualityTest_Material6()
        {
            //arrange
            BridgeSupport obj1 = new BridgeSupport() { Material = null };
            BridgeSupport obj2 = new BridgeSupport() { Material = null };
            //act
            var res = obj1 == obj2;
            //assert
            Assert.True(res);
        }
        #endregion
    }
}
