using NUnit.Framework;
using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Data;
using System.Collections.Generic;

namespace NorthwindTests
{
    public class CustomerManagerShould
    {
        private CustomerManager _sut;

        [Test]
        public void BeAbleToBeConstructed()
        {
            //Arrange
            var dummyCustomerService = new Mock<ICustomerService>().Object; //this is a Dummy Customer Service
            //Act
            _sut = new CustomerManager(dummyCustomerService); //this is a Dummy Customer Manager

            //Assert
            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        [Test]
        public void ReturnTrue_WhenUpdateIsCalled_WithValid()
        {
            //arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer() {
                CustomerId = "JSMITH",
                ContactName = "John Smith",
                Country = "UK",
                City = "Birmingham",
                PostalCode = "B99 AB3"
            };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);
            
            //Act
            var result = _sut.Update("JSMITH", "Johnothan Smith", "UK", "London", originalCustomer.PostalCode);
           //Assert
            Assert.That(originalCustomer.ContactName, Is.EqualTo("Johnothan Smith"));   
            Assert.That(originalCustomer.City, Is.EqualTo("London"));   
        }

        [Test]
        public void ReturnFalse_WhenUpdateIsCalled_WithInvalid()
        {
            //arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns((Customer)null);
            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Update("JSMITH", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenCustomerId_WhenValid_ReturnTrue()
        {
            //arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer()
            {
                CustomerId = "JSMITH"               
            };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Delete("JSMITH");
            //Assert
            Assert.That(result, Is.True);
            
        }

        [Test]
        public void GivenCustomerId_WhenNull_ReturnFalse()
        {
            //arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns((Customer)null);

            _sut = new CustomerManager(mockCustomerService.Object);
            //Act
            var result = _sut.Delete("JSMITH");
            //Assert
            Assert.That(result, Is.False);
        }


        [Test]
        public void Returnfalse_WhenUpdateIsCalled_AndDatabaseExceptionIsThrow()
        {
            //arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(new Customer() { CustomerId = "JSMITH"});
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges()).Throws<DataException>();

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.Update("JSMITH", "", "", "", "");

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CallSaveCustomerChangesOnce_WhenUpdateIsCalled_WithValidID()
        {
            //arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer()
            {
                CustomerId = "JSMITH"
                
            };

            mockCustomerService.Setup(cs => cs.GetCustomerById("JSMITH")).Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            _sut.Update("JSMITH", "", "", "", "");

            //Assert
            mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Once);
        }
        [Test]
        public void LetsSeeWhatHappens_WhenUpdateIsCalled_IfAllInvocationsArentSetUp()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Loose);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.SaveCustomerChanges());
            _sut = new CustomerManager(mockCustomerService.Object);
            // Act
            var result = _sut.Update("ROCK", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            // Assert
            Assert.That(result);
        }

        //Lab
        //Retrieve All tests

        //Happy Path
        [Test]
        public void GivenCustomers_ReturnCustomerList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new List<Customer>() {new Customer(), new Customer(), new Customer() };
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.RetrieveAll();

            //Assert
            Assert.That(result, Is.EqualTo(originalCustomer));
        }

        // Sad Path
        [Test]
        public void GivenNoCustomers_ReturnEmptyList()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new List<Customer>();
            mockCustomerService.Setup(cs => cs.GetCustomerList()).Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);

            //Act
            var result = _sut.RetrieveAll();
            var expected = new List<Customer>();

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GivenACustomer_WhenExists_TheCustomerIsSelected()
        {
            //Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var customer = new Customer();

            //Act
            _sut.SetSelectedCustomer(customer);
            
            //Assert
            Assert.That(_sut.SelectedCustomer, Is.EqualTo(customer));
        }

    }
}

