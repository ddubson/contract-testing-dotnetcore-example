using System.Collections.Generic;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace APIConsumerPact
{
    public class Consumer2AddressBookApiContractTests : IClassFixture<Consumer2AddressBookApiPact>
    {
        private readonly IMockProviderService _mockProviderService;
        private readonly string _mockProviderServiceBaseUri;

        public Consumer2AddressBookApiContractTests(Consumer2AddressBookApiPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderService
                .ClearInteractions(); //NOTE: Clears any previously registered interactions before the test is run
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
        }

        [Fact]
        public void GetProfileById_WhenTheProfileWithIdExists_ReturnsTheProfile()
        {
            //Arrange
            _mockProviderService
                .Given("There is a profile in the address book with id of 1")
                .UponReceiving("A GET request to retrieve the profile")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/profiles/1",
                    Headers = new Dictionary<string, object>
                    {
                        {"Accept", "application/json"}
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        {"Content-Type", "application/json; charset=utf-8"}
                    },
                    Body =
                        new //NOTE: Note the case sensitivity here, the body will be serialised as per the casing defined
                        {
                            id = 1,
                            firstName = "Jill",
                            lastName = "Doe"
                        }
                }); //NOTE: WillRespondWith call must come last as it will register the interaction

            var consumer = new AddressBookApiClient(_mockProviderServiceBaseUri);

            //Act
            var result = consumer.GetProfileById("1");

            //Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("Jill", result.FirstName);
            Assert.Equal("Doe", result.LastName);

            //NOTE: Verifies that interactions registered on the mock provider are called at least once
            _mockProviderService.VerifyInteractions(); 
        }
    }
}