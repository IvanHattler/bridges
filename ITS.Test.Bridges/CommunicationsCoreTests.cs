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
            Assert.Equal("��� ������", name);
        }
        [Fact]
        public void ConverterGetName_GasPipeline()
        {
            //arrange
            Communications elem = Communications.GasPipeline;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("����������", name);
        }
        [Fact]
        public void ConverterGetName_ElectricCable()
        {
            //arrange
            Communications elem = Communications.ElectricCable;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("�������������", name);
        }
        [Fact]
        public void ConverterGetName_CommunicationCable()
        {
            //arrange
            Communications elem = Communications.CommunicationCable;
            //act
            string name = Converter.GetName(elem);
            //assert
            Assert.Equal("������ �����", name);
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
            Assert.Equal("���������, ����������", name);
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
            Assert.Equal("�������������, ����������", name);
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
            Assert.Equal("���������, ����������, ����������, �������������, ������ �����," +
                " ����������", name);
        }

        [Fact]
        public void ConverterGetElement_CommunicationCable()
        {
            //arrange
            string name = "������ �����";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.CommunicationCable, elem);
        }
        [Fact]
        public void ConverterGetElement_ElectricCable()
        {
            //arrange
            string name = "�������������";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.ElectricCable, elem);
        }
        [Fact]
        public void ConverterGetElement_NoData()
        {
            //arrange
            string name = "��� ������";
            //act
            Communications elem = Converter.GetElement(name);
            //assert
            Assert.Equal(Communications.NoData, elem);
        }
        [Fact]
        public void ConverterGetElement_All()
        {
            //arrange
            string name = "���������, ����������, ����������, �������������, ������ �����," +
                " ����������";
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
            string name = "����������, ����������, �������������, ������ �����," +
                " ����������";
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
            string name = "����������, �������������, ������ �����," +
                " ����������";
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
