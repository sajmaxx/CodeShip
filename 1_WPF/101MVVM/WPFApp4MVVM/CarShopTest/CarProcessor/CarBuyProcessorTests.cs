using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CarShop.CarProcessor
{
    public  class CarBuyProcessorTests
    {
        [Fact]
        public void ShouldReturnNewCar()
        {
            //Arrange
            var carprop = SetCarArrangement(out var newcar);

            //Act
           CarProperties revisedProp = newcar.BookCar(carprop);

           //Assert
           Assert.NotNull(revisedProp);
            

        }

        [Fact]
        public void AreCarPropertiesSame()
        {
            //Arrange
            var carProp = SetCarArrangement(out var newcar);

            //Act
            CarProperties revisedProp = newcar.BookCar(carProp);
            revisedProp = carProp;

            //Assert
            Assert.Equal(carProp, revisedProp);
        }

        [Fact]
        public void ShouldThrowExceptionIfPropisNull()
        {
            var carProp = SetCarArrangement(out var newcar);
            
            var exception = Assert.Throws<ArgumentNullException>(() => newcar.BookCar(null));
            Assert.Equal("carprop", exception.ParamName);
        }



        private static CarProperties SetCarArrangement(out Car newcar)
        {
            var carprop = new CarProperties
            {
                Brand = "Ford",
                Model = "GT2000",
                Year = 2020
            };
            newcar = new Car();
            return carprop;
        }
    }

}
