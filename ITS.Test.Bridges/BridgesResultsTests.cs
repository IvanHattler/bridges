using ITS.Core.Bridges.Domain;
using ITS.MapObjects.BridgesMapObject.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ITS.Test.Bridges
{
    public class BridgesResultsTests
    {
        [Fact]
        public void CountTest1()
        {
            //arrange
            var list = new List<Bridge>()
            {
                new Bridge(), new Bridge(), new Bridge()
            };
            var results = new BridgesResults(list);
            //act
            var res = results.Count;
            //assert
            Assert.Equal(3, res);
        }
        [Fact]
        public void CountTest2()
        {
            //arrange
            var list = new List<Bridge>()
            {
                
            };
            var results = new BridgesResults(list);
            //act
            var res = results.Count;
            //assert
            Assert.Equal(0, res);
        }
        [Fact]
        public void CountTest3()
        {
            //arrange
            List<Bridge> list = null;
            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => new BridgesResults(list));
        }


        [Fact]
        public void SpanStructuresCountTest1()
        {
            //arrange
            var obj1 = new Bridge()
            {
                SpanStructures = new List<SpanStructure>()
                {
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 1f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 2f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 3f
                    },
                }
            };
            var obj2 = new Bridge()
            {
                SpanStructures = new List<SpanStructure>()
                {
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 4f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 5f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 6f
                    },
                }
            };
            var list = new List<Bridge>()
            {
                obj1, obj2
            };
            var results = new BridgesResults(list);
            //act
            var res = results.SpanStructuresCount;
            //assert
            Assert.Equal(6, res);
        }

        [Fact]
        public void UnderbridgeClearanceAvgTest1()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>()
                {
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 1f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 2f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 3f
                    },
                }
            };
            var list = new List<Bridge>()
            {
                obj
            };
            var results = new BridgesResults(list);
            //act
            var res = results.UnderbridgeClearanceAvg;
            //assert
            Assert.Equal(2, res);
        }
        [Fact]
        public void UnderbridgeClearanceAvgTest2()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>()
                {
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 1f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 2f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 3f
                    },
                }
            };
            var list = new List<Bridge>()
            {
                obj, obj, obj
            };
            var results = new BridgesResults(list);
            //act
            var res = results.UnderbridgeClearanceAvg;
            //assert
            Assert.Equal(2, res);
        }
        [Fact]
        public void UnderbridgeClearanceAvgTest3()
        {
            //arrange
            var obj1 = new Bridge()
            {
                SpanStructures = new List<SpanStructure>()
                {
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 1f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 2f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 3f
                    },
                }
            };
            var obj2 = new Bridge()
            {
                SpanStructures = new List<SpanStructure>()
                {
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 4f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 5f
                    },
                    new SpanStructure()
                    {
                        UnderbridgeClearance = 6f
                    },
                }
            };
            var list = new List<Bridge>()
            {
                obj1, obj2
            };
            var results = new BridgesResults(list);
            //act
            var res = results.UnderbridgeClearanceAvg;
            //assert
            Assert.Equal(3.5, res);
        }
    }
}
