using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Domain.Photos;
using ITS.MapObjects.BridgesMapObject.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //arrange
            var obj = new Bridge()
            {
                ConstructionType = ITS.Core.Bridges.Domain.Enums.BridgeType.Bridge,
                RoadCode = 228,
                Kilometer = 11800,
                //Obstacles = new List<BridgeObstacle>{ new BridgeObstacle(ObstacleType.River,
                //"Борла")},
                RoadName = "Елшанка-Алешкино-Большая Борла",
                Territory = new Territory("Ульяновская область"),
                DateView = new DateTime(2015,12,23),
                RoadSignsAfter = "знаки123",
            };
            var photo = new Photo(Properties.Resources.CattleDrive, DateTime.Now, 0);
            var photo1 = new Photo(Properties.Resources.Bridge, DateTime.Now, 0);
            var photo2 = new Photo(Properties.Resources.testImage, DateTime.Now, 0);
            var photo3 = new Photo(Properties.Resources.testLargeImage, DateTime.Now, 0);
            photo.Description = "Общий вид моста";
            obj.Photos = new List<Photo>();
            obj.Photos.Add(photo);
            obj.Photos.Add(photo1);
            obj.Photos.Add(photo2);
            obj.Photos.Add(photo3);
            obj.Supports = new List<BridgeSupport>() {
                new BridgeSupport() { Number = 1, Bridge = obj },
                new BridgeSupport() { Number = 2, Bridge = obj },
                new BridgeSupport() { Number = 3, Bridge = obj, SchemeKLeft=1f,SchemeKRight=1f,
                SchemePileDistances=new[]{ 0.5f, 0.5f, 0.49f}, SchemePileRowDistance1=2f },
            };
            obj.SpanStructures = new List<SpanStructure>() {
                new SpanStructure() { Number = 1, Bridge = obj, UnderbridgeClearance = 1f },
                new SpanStructure() {Number = 2, Bridge = obj, UnderbridgeClearance = 1f,
                    ExpansionJointType = ExpansionJointType.FilledMasticAndMetalCompensator},
                new SpanStructure() { Number = 3, Bridge = obj, PlateThickness=1f,
                    SlopeLongitudinal = 1f, SlopeLongitudinalProfile = SlopeProfile.ConcaveCurve},
                new SpanStructure() { Number = 4, Bridge = obj, PlateThickness=2f },
            };
            var type = new DefectType() { Name = "Без оголения арматуры", Pattern = "F или L:float" };
            obj.Defects = new List<Defect>() {
                new Defect() { Category = "werq",
                    Type = type,
                    Params = "F или L=123",
                    Bridge = obj }
            };
            obj.Documentations = new List<DocumentationInfo>()
            {
                new DocumentationInfo()
                {
                    Number = 1,
                    Bridge = obj,
                    NameAndDate = "asfJKL",
                    Creator = "qwer",
                    Storage = "asf",
                }
            };
            var objects = new List<Bridge>() { obj, obj };
            var filePath = args[1];
            //act
            try
            {
                BridgeReport.ReportMake(filePath, objects, 12);
                //BridgeFindReport.BridgePassportMake(filePath, obj, 12);
                ReportHelper.Open(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            //assert
            //Console.WriteLine("success");
            //Console.ReadKey();
        }
    }
}
