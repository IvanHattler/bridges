using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using System;
using Xunit;

namespace ITS.Test.Bridges
{
    public class ArrangementsCoreTests
    {
        public ArrangementsStrings Converter = ArrangementsStrings.Instance;
        [Fact]
        public void ConverterGetName_InspectionTrolleys()
        {
            //arrange
            Arrangements arrangements = Arrangements.InspectionTrolleys;
            //act
            string name = Converter.GetName(arrangements);
            //assert
            Assert.Equal("Тележки смотровые", name);
        }
        [Fact]
        public void ConverterGetName_Doors()
        {
            //arrange
            Arrangements arrangements = Arrangements.Doors;
            //act
            string name = Converter.GetName(arrangements);
            //assert
            Assert.Equal("Двери", name);
        }
        [Fact]
        public void ConverterGetName_ObservationMoves()
        {
            //arrange
            Arrangements arrangements = Arrangements.ObservationMoves;
            //act
            string name = Converter.GetName(arrangements);
            //assert
            Assert.Equal("Смотровые хода", name);
        }
        [Fact]
        public void ConverterGetName_Cradles()
        {
            //arrange
            Arrangements arrangements = Arrangements.Cradles;
            //act
            string name = Converter.GetName(arrangements);
            //assert
            Assert.Equal("Люльки", name);
        }
        [Fact]
        public void ConverterGetName_DoorsCradles()
        {
            //arrange
            Arrangements arrangements = Arrangements.Cradles 
                | Arrangements.Doors;
            //act
            string name = Converter.GetName(arrangements);
            //assert
            Assert.Equal("Люльки, Двери", name);
        }
        [Fact]
        public void ConverterGetName_StairsInspectionTrolleys()
        {
            //arrange
            Arrangements arrangements = Arrangements.Stairs
                | Arrangements.InspectionTrolleys;
            //act
            string name = Converter.GetName(arrangements);
            //assert
            Assert.Equal("Лестницы, Тележки смотровые", name);
        }
        [Fact]
        public void ConverterGetName_NoData()
        {
            //arrange
            Arrangements arrangements = Arrangements.NoData;
            //act
            string name = Converter.GetName(arrangements);
            //assert
            Assert.Equal("Нет данных", name);
        }
        [Fact]
        public void ConverterGetName_All()
        {
            //arrange
            Arrangements arrangements = Arrangements.InspectionTrolleys
                | Arrangements.Hatches
                | Arrangements.Doors
                | Arrangements.Cradles
                | Arrangements.ObservationMoves
                | Arrangements.Stairs;
            //act
            string name = Converter.GetName(arrangements);
            //assert
            Assert.Equal("Лестницы, Тележки смотровые, Люльки, Смотровые хода," +
                " Люки, Двери", name);
        }

        [Fact]
        public void ConverterGetElement_InspectionTrolleys()
        {
            //arrange
            string name = "Тележки смотровые";
            //act
            Arrangements arrangements = Converter.GetElement(name);
            //assert
            Assert.Equal(Arrangements.InspectionTrolleys, arrangements);
        }
        [Fact]
        public void ConverterGetElement_Cradles()
        {
            //arrange
            string name = "Люльки";
            //act
            Arrangements arrangements = Converter.GetElement(name);
            //assert
            Assert.Equal(Arrangements.Cradles, arrangements);
        }
        [Fact]
        public void ConverterGetElement_NoData()
        {
            //arrange
            string name = "Нет данных";
            //act
            Arrangements arrangements = Converter.GetElement(name);
            //assert
            Assert.Equal(Arrangements.NoData, arrangements);
        }
        [Fact]
        public void ConverterGetElement_All()
        {
            //arrange
            string name = "Тележки смотровые, Люльки, Смотровые хода," +
                " Люки, Двери, Лестницы";
            //act
            Arrangements arrangements = Converter.GetElement(name);
            //assert
            Assert.Equal(Arrangements.InspectionTrolleys
                | Arrangements.Hatches
                | Arrangements.Doors
                | Arrangements.Cradles
                | Arrangements.ObservationMoves
                | Arrangements.Stairs, arrangements);
        }
        [Fact]
        public void ConverterGetElement_AlmostAll()
        {
            //arrange
            string name = "Тележки смотровые, Смотровые хода," +
                " Люки, Двери, Лестницы";
            //act
            Arrangements arrangements = Converter.GetElement(name);
            //assert
            Assert.Equal(Arrangements.InspectionTrolleys
                | Arrangements.Hatches
                | Arrangements.Doors
                | Arrangements.ObservationMoves
                | Arrangements.Stairs, arrangements);
        }
        [Fact]
        public void ConverterGetElement_AlmostAll1()
        {
            //arrange
            string name = "Тележки смотровые, Смотровые хода," +
                " Люки, Лестницы";
            //act
            Arrangements arrangements = Converter.GetElement(name);
            //assert
            Assert.Equal(Arrangements.InspectionTrolleys
                | Arrangements.Hatches
                | Arrangements.ObservationMoves
                | Arrangements.Stairs, arrangements);
        }
    }
}
