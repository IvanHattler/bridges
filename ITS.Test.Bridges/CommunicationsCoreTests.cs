using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using System;
using Xunit;

namespace ITS.Test.Bridges
{
    public class CommunicationsCoreTests
    {
        public CommunicationsStrings Converter = CommunicationsStrings.Instance;
        [Fact]
        public void ConverterGetName_NoData()
        {
            //arrange
            Communications elem = Communications.NoData;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("Нет данных", name);
        }
        [Fact]
        public void ConverterGetName_GasPipeline()
        {
            //arrange
            Communications elem = Communications.GasPipeline;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("Газопровод", name);
        }
        [Fact]
        public void ConverterGetName_ElectricCable()
        {
            //arrange
            Communications elem = Communications.ElectricCable;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("Электрокабель", name);
        }
        [Fact]
        public void ConverterGetName_CommunicationCable()
        {
            //arrange
            Communications elem = Communications.CommunicationCable;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("Кабель связи", name);
        }
        [Fact]
        public void ConverterGetName_HeatingNetworkWaterPipeline()
        {
            //arrange
            Communications elem = Communications.HeatingNetwork 
                | Communications.WaterPipeline;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("Теплосеть, Водопровод", name);
        }
        [Fact]
        public void ConverterGetName_ElectricCableTelecable()
        {
            //arrange
            Communications elem = Communications.ElectricCable
                | Communications.Telecable;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("Электрокабель, Телекабель", name);
        }
        [Fact]
        public void ConverterGetName_All()
        {
            //arrange
            Communications elem = Communications.CommunicationCable
                | Communications.ElectricCable
                | Communications.GasPipeline
                | Communications.HeatingNetwork
                | Communications.Telecable
                | Communications.WaterPipeline;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("Теплосеть, Водопровод, Газопровод, Электрокабель, Кабель связи," +
                " Телекабель", name);
        }

        [Fact]
        public void ConverterGetElement_CommunicationCable()
        {
            //arrange
            string name = "Кабель связи";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.CommunicationCable, elem);
        }
        [Fact]
        public void ConverterGetElement_ElectricCable()
        {
            //arrange
            string name = "Электрокабель";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.ElectricCable, elem);
        }
        [Fact]
        public void ConverterGetElement_NoData()
        {
            //arrange
            string name = "Нет данных";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.NoData, elem);
        }
        [Fact]
        public void ConverterGetElement_All()
        {
            //arrange
            string name = "Теплосеть, Водопровод, Газопровод, Электрокабель, Кабель связи," +
                " Телекабель";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.CommunicationCable
                | Communications.ElectricCable
                | Communications.GasPipeline
                | Communications.HeatingNetwork
                | Communications.Telecable
                | Communications.WaterPipeline, elem);
        }
        [Fact]
        public void ConverterGetElement_AlmostAll()
        {
            //arrange
            string name = "Водопровод, Газопровод, Электрокабель, Кабель связи," +
                " Телекабель";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.CommunicationCable
                | Communications.ElectricCable
                | Communications.GasPipeline
                | Communications.Telecable
                | Communications.WaterPipeline, elem);
        }
        [Fact]
        public void ConverterGetElement_AlmostAll1()
        {
            //arrange
            string name = "Водопровод, Электрокабель, Кабель связи," +
                " Телекабель";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.CommunicationCable
                | Communications.ElectricCable
                | Communications.Telecable
                | Communications.WaterPipeline, elem);
        }
    }
}
