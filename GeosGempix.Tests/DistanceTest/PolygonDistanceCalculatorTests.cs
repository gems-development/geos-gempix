using GeosGempix.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Tests.DistanceTest
{
    public class PolygonDistanceCalculatorTests
    {
		// Проверка на растояние между полигоном и контуром
		[Fact]
        public void GetDistanceBetweenPolygonAnd_Success() { }
        
        // Проверка на растояние между полигоном и полигоном
        [Fact]
        public void GetDistanceBetweenPolygonAndPolygon_Success() { }
        
        // Проверка на растояние между полигоном и мультиточкой
        [Fact]
        public void GetDistanceBetweenPolygonAndMultiPoint_Success() { }
        
        // Проверка на растояние между полигоном и мультилинией
        [Fact]
        public void GetDistanceBetweenPolygonAndMultiLine_Success() { }
        
        // Проверка на растояние между полигоном и мультиполигоном
        [Fact]
        public void GetDistanceBetweenPolygonAndMultiPolygon_Success() { }
    }
}
