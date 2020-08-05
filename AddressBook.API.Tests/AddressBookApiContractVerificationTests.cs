using API.Tests.PactSetup;
using PactNet;
using Xunit;
using Xunit.Abstractions;

namespace API.Tests
{
    public class AddressBookApiContractVerificationTests: ContractTestBase
    {
        public AddressBookApiContractVerificationTests(ITestOutputHelper output): base(output)
        {
        }

        [Fact]
        public void EnsureAddressBookApiHonorsPactWithConsumer()
        {
            new PactVerifier(_pactVerifierConfig)
                .ProviderState($"{ProviderUri}/provider-states")
                .ServiceProvider("Address Book API", ProviderUri)
                .HonoursPactWith("Consumer1")
                .PactUri("..\\..\\..\\..\\pacts\\consumer1-addressbook.api.json")
                .Verify();
        }
    }
}