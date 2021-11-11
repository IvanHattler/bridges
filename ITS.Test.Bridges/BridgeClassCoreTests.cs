using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.Domain;
using System;
using Xunit;
using System.Collections.Generic;

namespace ITS.Test.Bridges
{
    public class BridgeClassCoreTests
    {
        [Fact]
        public void ObstaclesAsStringTest1()
        {
            //arrange
            var obj = new Bridge()
            {
                Obstacles = new System.Collections.Generic.List<BridgeObstacle>()
                {
                    new BridgeObstacle(ObstacleType.River,"Борла"),
                }
            };
            //act
            string str = obj.ObstaclesAsString;
            //assert
            Assert.Equal("река Борла", str);
        }
        [Fact]
        public void ObstaclesAsStringTest2()
        {
            //arrange
            var obj = new Bridge()
            {
                Obstacles = new System.Collections.Generic.List<BridgeObstacle>()
                {
                    new BridgeObstacle(ObstacleType.River,"Борла"),
                    new BridgeObstacle(ObstacleType.River,"Балдашка"),
                }
            };
            //act
            string str = obj.ObstaclesAsString;
            //assert
            Assert.Equal("река Борла, река Балдашка", str);
        }
        [Fact]
        public void ObstaclesAsStringTest3()
        {
            //arrange
            var obj = new Bridge()
            {
                Obstacles = new System.Collections.Generic.List<BridgeObstacle>()
                {
                    new BridgeObstacle(ObstacleType.River,"Борла"),
                    new BridgeObstacle(ObstacleType.Road,"Балдашка"),
                    new BridgeObstacle(ObstacleType.River,"Балдашка"),
                }
            };
            //act
            string str = obj.ObstaclesAsString;
            //assert
            Assert.Equal("река Борла, автодорога Балдашка, река Балдашка", str);
        }

        [Fact]
        public void ExpandedRoadCodeTest1()
        {

            //arrange
            var obj = new Bridge()
            {
                SubjectCode = 10,
                TerritorialRoadControlCode = 121,
                RoadCode = 177,
            };
            //act
            string scheme = obj.ExpandedRoadCode;
            //assert
            Assert.Equal("10.121.0177", scheme);
        }

        [Fact]
        public void CharactObstacleAsStringTest1()
        {
            //arrange
            var obj = new Bridge()
            {
                CharactObstacleB = 5.36f,
                CharactObstacleH = 0.2f,
                CharactObstacleV = 0.35f,
            };
            //act
            string scheme = obj.CharactObstacleAsString;
            //assert
            Assert.Equal("B=5,36; H=0,20; V=0,35; ", scheme);
        }
        [Fact]
        public void CharactObstacleAsStringTest2()
        {
            //arrange
            var obj = new Bridge()
            {
                CharactObstacleB = 5.36f,
                CharactObstacleH = 0.2f,
                CharactObstacleV = 0.35f,
                ConstructionType = BridgeType.Overpass,
                RoadCategory = RoadCategory.V,
            };
            //act
            string scheme = obj.CharactObstacleAsString;
            //assert
            Assert.Equal("B=5,36; H=0,20; V=0,35; ", scheme);
        }

        [Fact]
        public void CharactObstacleDirectionFlowAsStringTest1()
        {
            //arrange
            var obj = new Bridge()
            {
                CharactObstacleDirectionOfFlow = false,
            };
            //act
            string scheme = obj.CharactObstacleDirectionFlowAsString;
            //assert
            Assert.Equal("-1", scheme);
        }
        [Fact]
        public void CharactObstacleDirectionFlowAsStringTest2()
        {
            //arrange
            var obj = new Bridge()
            {
                CharactObstacleDirectionOfFlow = true,
            };
            //act
            string scheme = obj.CharactObstacleDirectionFlowAsString;
            //assert
            Assert.Equal("1", scheme);
        }

        [Fact]
        public void WidthDimensionAsStringTest1()
        {
            //arrange
            var obj = new Bridge()
            {
                WidthDimensionB = 11.93f,
                WidthDimensionG = 8.23f,
            };
            //act
            string scheme = obj.WidthDimensionAsString;
            //assert
            Assert.Equal("B=11,93; Г=8,23", scheme);
        }
        [Fact]
        public void WidthDimensionAsStringTest2()
        {
            //arrange
            var obj = new Bridge()
            {
                WidthDimensionB = 11.93f,
                WidthDimensionG = 8.23f,
                WidthDimensionT1 = 1.6f,
            };
            //act
            string scheme = obj.WidthDimensionAsString;
            //assert
            Assert.Equal("B=11,93; Г=8,23; T1=1,60", scheme);
        }
        [Fact]
        public void WidthDimensionAsStringTest3()
        {
            //arrange
            var obj = new Bridge()
            {
                WidthDimensionB = 11.93f,
                WidthDimensionG = 8.23f,
                WidthDimensionT1 = 1.6f,
                WidthDimensionT2 = 1.6f,
                WidthDimensionC1 = 0.5f,
                WidthDimensionC2 = 0.5f,
            };
            //act
            string scheme = obj.WidthDimensionAsString;
            //assert
            Assert.Equal("B=11,93; Г=8,23; T1=1,60; T2=1,60; C1=0,50; C2=0,50", scheme);
        }
        [Fact]
        public void WidthDimensionAsStringTest4()
        {
            //arrange
            var obj = new Bridge()
            {
                WidthDimensionB = 11.93f,
                WidthDimensionG = 8.23f,
                WidthDimensionT2 = 1.6f,
                WidthDimensionC2 = 0.5f,
            };
            //act
            string scheme = obj.WidthDimensionAsString;
            //assert
            Assert.Equal("B=11,93; Г=8,23; T2=1,60; C2=0,50", scheme);
        }
        [Fact]
        public void WidthDimensionAsStringTest5()
        {
            //arrange
            var obj = new Bridge()
            {
                WidthDimensionB = 11.93f,
                WidthDimensionG = 8.23f,
                WidthDimensionT2 = 1.6f,
                WidthDimensionC2 = 0.5f,
                WidthDimensionBrivewayCount = 2,
                WidthDimensionC = 3,
            };
            //act
            string scheme = obj.WidthDimensionAsString;
            //assert
            Assert.Equal("B=11,93; 2Г=8,23; T2=1,60; C=3,00; C2=0,50", scheme);
        }
        [Fact]
        public void BridgeCodeTest1()
        {
            //arrange
            var obj = new Bridge()
            {
                Kilometer = 23605,
                RoadCode = 177,
            };
            //act
            string res = obj.BridgeCode;
            //assert
            Assert.Equal("0177/0024", res);
        }
        [Fact]
        public void BridgeCodeTest2()
        {
            //arrange
            var obj = new Bridge()
            {
                Kilometer = 23499,
                RoadCode = 177,
            };
            //act
            string res = obj.BridgeCode;
            //assert
            Assert.Equal("0177/0023", res);
        }
        [Fact]
        public void BridgeCodeTest3()
        {
            //arrange
            var obj = new Bridge()
            {
                Kilometer = 23499,
                RoadCode = 177,
                IsLeft = true,
            };
            //act
            string res = obj.BridgeCode;
            //assert
            Assert.Equal("0177/0023-Л", res);
        }
        [Fact]
        public void BridgeCodeTest4()
        {
            //arrange
            var obj = new Bridge()
            {
                Kilometer = 23499,
                RoadCode = 177,
                IsLeft = false,
            };
            //act
            string res = obj.BridgeCode;
            //assert
            Assert.Equal("0177/0023-П", res);
        }
        [Fact]
        public void BridgeCodeTest5()
        {
            //arrange
            var obj = new Bridge()
            {
                Kilometer = 23499,
                RoadCode = 177,
                IsLeft = false,
                IsOverTheRoad = true,
                ConstructionType = BridgeType.Overpass,
            };
            //act
            string res = obj.BridgeCode;
            //assert
            Assert.Equal("0177&/0023-П", res);
        }
        [Fact]
        public void BridgeCodeTest6()
        {
            //arrange
            var obj = new Bridge()
            {
                Kilometer = 23499,
                RoadCode = 177,
                IsLeft = false,
                IsOverTheRoad = true,
                ConstructionType = BridgeType.Aqueduct,
            };
            //act
            string res = obj.BridgeCode;
            //assert
            Assert.Equal("0177/0023-П", res);
        }

        [Fact]
        public void LongitudeSchemeTest1()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { LongitudeScheme = "16,0" },
                    new SpanStructure() { LongitudeScheme = "16,0" },
                    new SpanStructure() { LongitudeScheme = "16,0+К4,0" },
                }
            };
            //act
            string res = obj.LongitudeScheme;
            //assert
            Assert.Equal("16,0+16,0+16,0+К4,0", res);
        }
        [Fact]
        public void LongitudeSchemeTest2()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { LongitudeScheme = "16,0" },
                    new SpanStructure() { },
                    new SpanStructure() { LongitudeScheme = "16,0+К4,0" },
                }
            };
            //act
            string res = obj.LongitudeScheme;
            //assert
            Assert.Equal("16,0+0+16,0+К4,0", res);
        }
        [Fact]
        public void ExpansionJointTypes1()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.ClosedMetalCompensator },
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.ClosedMetalCompensator  },
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.ClosedMetalCompensator  },
                }
            };
            //act
            string res = obj.ExpansionJointsTypes;
            //assert
            Assert.Equal("Закрытого типа с металлическим компенсатором", res);
        }
        [Fact]
        public void ExpansionJointTypes2()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.ClosedMetalCompensator },
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.NoData  },
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.ClosedMetalCompensator  },
                }
            };
            //act
            string res = obj.ExpansionJointsTypes;
            //assert
            Assert.Equal("Закрытого типа с металлическим компенсатором, Нет данных", res);
        }
        [Fact]
        public void ExpansionJointTypes3()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.ClosedMetalCompensator },
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.NoData  },
                    new SpanStructure() { ExpansionJointType = ExpansionJointType.ClosedTormaJoint  },
                }
            };
            //act
            string res = obj.ExpansionJointsTypes;
            //assert
            Assert.Equal("Закрытого типа с металлическим компенсатором, Нет данных, Закрытого типа Торма Джоинт", res);
        }

        [Fact]
        public void UnderbridgeClearance1()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 1, UnderbridgeClearance=8.4f },
                    new SpanStructure() { Number = 2, UnderbridgeClearance=8.3f  },
                    new SpanStructure() { Number = 3, UnderbridgeClearance=10.7f  },
                }
            };
            //act
            string res = obj.UnderbridgeClearance;
            //assert
            Assert.Equal("Пр.1 - 8,40; Пр.2 - 8,30; Пр.3 - 10,70", res);
        }
        [Fact]
        public void UnderbridgeClearance2()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 2, UnderbridgeClearance=8.4f },
                    new SpanStructure() { Number = 5, UnderbridgeClearance=8.3f  },
                    new SpanStructure() { Number = 3, UnderbridgeClearance=10.7f  },
                }
            };
            //act
            string res = obj.UnderbridgeClearance;
            //assert
            Assert.Equal("Пр.2 - 8,40; Пр.3 - 10,70; Пр.5 - 8,30", res);
        }
        [Fact]
        public void UnderbridgeClearance3()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 2, UnderbridgeClearance=1f },
                    new SpanStructure() { Number = 5, UnderbridgeClearance=1f  },
                    new SpanStructure() { Number = 3, UnderbridgeClearance=1f  },
                }
            };
            //act
            string res = obj.UnderbridgeClearance;
            //assert
            Assert.Equal("1,00", res);
        }
        [Fact]
        public void UnderbridgeClearance4()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 2, UnderbridgeClearance=1f },
                }
            };
            //act
            string res = obj.UnderbridgeClearance;
            //assert
            Assert.Equal("1,00", res);
        }
        [Fact]
        public void UnderbridgeClearance5()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 1, UnderbridgeClearance=1f },
                    new SpanStructure() { Number = 2, UnderbridgeClearance=1.00000001f },
                }
            };
            //act
            string res = obj.UnderbridgeClearance;
            //assert
            Assert.Equal("1,00", res);
        }

        [Fact]
        public void SlopeLongitudinal1()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 1, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.ConcaveCurve },
                }
            };
            //act
            string res = obj.SlopeLongitudinalForReport;
            //assert
            Assert.Equal("V1,00%", res);
        }
        [Fact]
        public void SlopeLongitudinal2()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 1, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.ConcaveCurve },
                    new SpanStructure() { Number = 5, SlopeLongitudinal = 2f,
                        SlopeLongitudinalProfile = SlopeProfile.Up },
                    new SpanStructure() { Number = 2, SlopeLongitudinal = 3f,
                        SlopeLongitudinalProfile = SlopeProfile.Down },
                }
            };
            //act
            string res = obj.SlopeLongitudinalForReport;
            //assert
            Assert.Equal("Пр.1 - V1,00%; Пр.2 - \\3,00%; Пр.5 - /2,00%", res);
        }
        [Fact]
        public void SlopeLongitudinal3()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 1, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.Down },
                    new SpanStructure() { Number = 5, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.Down },
                    new SpanStructure() { Number = 2, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.Down },
                }
            };
            //act
            string res = obj.SlopeLongitudinalForReport;
            //assert
            Assert.Equal("\\1,00%", res);
        }
        [Fact]
        public void SlopeLongitudinal4()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 1, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.ConcaveCurve },
                    new SpanStructure() { Number = 5, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.Up },
                    new SpanStructure() { Number = 2, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.ConcaveCurve },
                }
            };
            //act
            string res = obj.SlopeLongitudinalForReport;
            //assert
            Assert.Equal("Пр.1 - V1,00%; Пр.2 - V1,00%; Пр.5 - /1,00%", res);
        }
        [Fact]
        public void SlopeLongitudinal5()
        {
            //arrange
            var obj = new Bridge()
            {
                SpanStructures = new List<SpanStructure>
                {
                    new SpanStructure() { Number = 1, SlopeLongitudinal = 1.2f,
                        SlopeLongitudinalProfile = SlopeProfile.Up },
                    new SpanStructure() { Number = 2, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.Up },
                    new SpanStructure() { Number = 3, SlopeLongitudinal = 1f,
                        SlopeLongitudinalProfile = SlopeProfile.Up },
                }
            };
            //act
            string res = obj.SlopeLongitudinalForReport;
            //assert
            Assert.Equal("Пр.1 - /1,20%; Пр.2 - /1,00%; Пр.3 - /1,00%", res);
        }
    }
}
