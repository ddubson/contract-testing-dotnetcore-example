using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace APIConsumerPact
{
    public class Consumer2AddressBookApiPact : IDisposable
    {
        private const string ConsumerName = "Consumer2";
        private const string ProviderName = "AddressBook.API";
        
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort => 9310;

        public string MockProviderServiceBaseUri => $"http://localhost:{MockServerPort.ToString()}";

        public Consumer2AddressBookApiPact()
        {
            PactBuilder =
                new PactBuilder(new PactConfig
                {
                    SpecificationVersion = "2.0.0",
                    PactDir = @"../../../../pacts"
                });

            PactBuilder
                .ServiceConsumer(ConsumerName)
                .HasPactWith(ProviderName);

            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        public void Dispose()
        {
            PactBuilder.Build(); //NOTE: Will save the pact file once finished
        }
    }
}