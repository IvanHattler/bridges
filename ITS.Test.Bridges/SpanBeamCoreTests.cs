using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using System;
using Xunit;

namespace ITS.Test.Bridges
{
    public class SpanBeamCoreTests
    {
        [Fact]
        public void EqualsTest1()
        {
            //arrange
            SpanBeam obj1 = new SpanBeam();
            SpanBeam obj2 = null;
            //act
            var res = obj1.Equals(obj2);
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualsTest2()
        {
            //arrange
            SpanBeam obj1 = new SpanBeam();
            SpanBeam obj2 = new SpanBeam();
            //act
            var res = obj1.Equals(obj2);
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualsTest3()
        {
            //arrange
            SpanBeam obj1 = new SpanBeam() { Type = SpanBeamType.RibbedTensionFreeCurvedTrackSections};
            SpanBeam obj2 = new SpanBeam() { Type = SpanBeamType.SlabsTensionFreeStationarySpans };
            //act
            var res = obj1.Equals(obj2);
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualsTest4()
        {
            //arrange
            SpanBeam obj1 = new SpanBeam() { Material = new Material() };
            SpanBeam obj2 = new SpanBeam() { Material = new Material() { Name = "qewr"} };
            //act
            var res = obj1.Equals(obj2);
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualsTest5()
        {
            //arrange
            SpanBeam obj1 = new SpanBeam() { Height = 1f };
            SpanBeam obj2 = new SpanBeam() { Height = 1.01f };
            //act
            var res = obj1.Equals(obj2);
            //assert
            Assert.False(res);
        }
        [Fact]
        public void EqualsTest6()
        {
            //arrange
            SpanBeam obj1 = new SpanBeam() { Height = 1f };
            SpanBeam obj2 = new SpanBeam() { Height = 1f };
            //act
            var res = obj1.Equals(obj2);
            //assert
            Assert.True(res);
        }
        [Fact]
        public void EqualsTest7()
        {
            //arrange
            SpanBeam obj1 = new SpanBeam() { Height = 1.0000001f };
            SpanBeam obj2 = new SpanBeam() { Height = 1f };
            //act
            var res = obj1.Equals(obj2);
            //assert
            Assert.False(res);
        }
    }
}
