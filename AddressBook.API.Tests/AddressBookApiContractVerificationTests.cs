using API.Tests.PactSetup;
using PactNet;
using Xunit;
using Xunit.Abstractions;

namespace API.Tests
{
    public class AddressBookApiContractVerificationTests: ContractTestBase
    {
        private const string Consumer1Contract = "consumer1-addressbook.api.json";
        private const string Consumer2Contract = "consumer2-addressbook.api.json";
        public AddressBookApiContractVerificationTests(ITestOutputHelper output): base(output)
        {
        }

        [Fact]
        public void EnsureAddressBookApiHonorsPactWithConsumer1()
        {
            new PactVerifier(_pactVerifierConfig)
                .ProviderState($"{ProviderUri}/provider-states")
                .ServiceProvider("Address Book API", ProviderUri)
                .HonoursPactWith("Consumer1")
                .PactUri($"..\\..\\..\\..\\pacts\\{Consumer1Contract}")
                .Verify();
        }
        
        [Fact]
        public void EnsureAddressBookApiHonorsPactWithConsumer2()
        {
            new PactVerifier(_pactVerifierConfig)
                .ProviderState($"{ProviderUri}/provider-states")
                .ServiceProvider("Address Book API", ProviderUri)
                .HonoursPactWith("Consumer1")
                .PactUri($"..\\..\\..\\..\\pacts\\{Consumer2Contract}")
                .Verify();
        }
    }
}