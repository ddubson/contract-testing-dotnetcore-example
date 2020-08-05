#!/usr/bin/env bash

set -e

echo "➡️  Consumer 1 is creating a contract with AddressBook API"
dotnet test AddressBook.API.Consumer1.Pact
echo "✅ Consumer 1 wrote its contract with AddressBook API at pacts/consumer1-addressbook.api.json"
echo "➡️  AddressBook API is verifying that all consumer contracts are honored..."
dotnet test AddressBook.API.Tests || echo "❌ AddressBook API failed to verify a contract."
echo "
----------------------------------------------------------
✅ Consumer 1 wrote its contract with AddressBook API at pacts/consumer1-addressbook.api.json
✅ AddressBook API has verified all contracts successfully!
----------------------------------------------------------
"