using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Helpers;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.ManagerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.GIS.MapEntities;
using GeoAPI.Geometries;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public class BridgeCreator
    {
        private Material ferroconcrete;
        private int supportsCounter = 1;
        private int spanStructuresCounter = 1;
        private ITerritoryManager _territoryManager;
        private string _mapName;
        public static Dictionary<string, int> patternToID = new Dictionary<string, int>
            (new EquStringComparerIgnoreCase())
            {
                {"Адыге", 01},
                {"Башкортостан", 02},
                {"Бурят", 03},
                {"Алтай респ", 04},
                {"Дагестан", 05},
                {"Ингушет", 06},
                {"Кабардино-Балкар", 07},
                {"Калмык", 08},
                {"Карачаево-Черкес", 09},
                {"Карел", 10},
                {"Коми", 11},
                {"Марий Эл", 12},
                {"Мордов", 13},
                {"Саха", 14},
                {"Алания", 15},
                {"Татарстан", 16},
                {"Тыва", 17},
                {"Удмурт", 18},
                {"Хакас", 19},
                {"Чеченская", 20},
                {"Чуваш", 21},
                {"Алтайский", 22},
                {"Краснодар", 23},
                {"Краснояр", 24},
                {"Примор", 25},
                {"Ставрополь", 26},
                {"Хабаровск", 27},
                {"Амур", 28},
                {"Архангельск", 29},
                {"Астрахан", 30},
                {"Белгород", 31},
                {"Брянск", 32},
                {"Владимир", 33},
                {"Волгоград", 34},
                {"Волог", 35},
                {"Воронеж", 36},
                {"Иванов", 37},
                {"Иркутск", 38},
                {"Калининград", 39},
                {"Калу", 40},
                {"Камчат", 41},
                {"Кемеров", 42},
                {"Киров", 43},
                {"Костром", 44},
                {"Курган", 45},
                {"Курск", 46},
                {"Ленинград", 47},
                {"Липецк", 48},
                {"Магадан", 49},
                {"Москов", 50},
                {"Мурманск", 51},
                {"Нижегород", 52},
                {"Нижнийновгород", 52},
                {"Новгород", 53},
                {"Новосибирск", 54},
                {"Омск", 55},
                {"Оренбург", 56},

                {"Орловск", 57},
                {"Орёл", 57},
                {"Орел", 57},

                {"Пенз", 58},
                {"Перм", 59},
                {"Псков", 60},
                {"Ростов", 61},
                {"Рязан", 62},
                {"Самар", 63},
                {"Саратов", 64},
                {"Сахалин", 65},
                {"Свердловск", 66},
                {"Смоленск", 67},
                {"Тамбов", 68},
                {"Твер", 69},
                {"Томск", 70},
                {"Тул", 71},
                {"Тюмен", 72},
                {"Ульяновск", 73},
                {"Челябинск", 74},
                {"Забайкальский", 75},
                {"Ярослав", 76},
                {"Москва", 77},
                {"Санкт-Петербург", 78},
                {"Еврейская", 79},
                {"Ненецкий авт", 83},
                {"Ханты-Манс", 86},
                {"Чукот", 87},
                {"Ямало-Ненецкий", 89},
                {"Крым", 91},
                {"Севастополь", 92},
                {"Байконур", 99},
            };
        public Material Ferroconcrete
        {
            get
            {
                return ferroconcrete ?? (ferroconcrete = Materials.Where(m => m.Name == "Железобетон").First());
            }
        }
        public IList<Material> Materials { get; }
        public BridgeCreator(IMaterialManager materialManager, ITerritoryManager territoryManager,
            string mapName)
        {
            Materials = materialManager.GetAll();
            _territoryManager = territoryManager;
            _mapName = mapName;
            var territories = _territoryManager.GetAll();
        }
        public Bridge GetDefaultBridge(ILineString centerLine)
        {
            const float roadWidth = 10f;
            int quantityLine = (int)Math.Floor(roadWidth / 3.5);
            var obj = new Bridge()
            {
                Supports = new List<BridgeSupport>(),
                SpanStructures = new List<SpanStructure>(),
                Obstacles = new List<BridgeObstacle>(),
                WidthDimensionB = roadWidth,
                QuantityLineApproach = quantityLine,
                QuantityLineBridge = quantityLine,
                QualityBridgeType = Quality.Grade3,
                Length = (float)centerLine.Length,
            };
            obj.Territory = GetTerritory();
            obj.Supports.Add(GetDefaultSupport(obj, true));
            obj.Supports.Add(GetDefaultSupport(obj));
            obj.Supports.Add(GetDefaultSupport(obj, true));
            obj.SpanStructures.Add(GetDefaultSpanStructure(obj));
            obj.SpanStructures.Add(GetDefaultSpanStructure(obj));
            obj.Obstacles.Add(GetDefaultObstacle(obj));
            supportsCounter = spanStructuresCounter = 1;
            return obj;
        }

        private static BridgeObstacle GetDefaultObstacle(Bridge obj)
        {
            return new BridgeObstacle(ObstacleType.River, "Без названия") { Bridge = obj };
        }

        /// <summary>
        /// Возвращает территорию по названию карты или null, если название не соответствует ни одному паттерну
        /// </summary>
        /// <returns></returns>
        public Territory GetTerritory()
        {
            foreach (var item in patternToID)
            {
                if (MatchesPattern(_mapName, item.Key))
                {
                    return _territoryManager.GetByID(item.Value);
                }
            }
            return null;
        }

        /// <summary>
        /// Сравнивает строку с паттерном без учёта регистра
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private bool MatchesPattern(string value, string pattern)
        {
            return value.IndexOf(pattern, 0, StringComparison.OrdinalIgnoreCase) != -1;
        }

        public SpanStructure GetDefaultSpanStructure(Bridge bridge)
        {
            var obj = new SpanStructure()
            {
                Number = spanStructuresCounter++,
                Material = Ferroconcrete,
                Bridge = bridge,
            };
            return obj;
        }
        public BridgeSupport GetDefaultSupport(Bridge bridge, bool isShore = false)
        {
            var obj = new BridgeSupport()
            {
                IsShore = isShore,
                Number = supportsCounter++,
                Material = Ferroconcrete,
                Bridge = bridge,
            };
            return obj;
        }
    }
}
