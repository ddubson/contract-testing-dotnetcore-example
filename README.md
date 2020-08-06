# Contract Testing example in .NET Core 3.1 and C# 8

![.NET Core](https://github.com/ddubson/contract-testing-dotnetcore-example/workflows/.NET%20Core/badge.svg)
[![Build Status](https://travis-ci.org/ddubson/contract-testing-dotnetcore-example.svg?branch=main)](https://travis-ci.org/ddubson/contract-testing-dotnetcore-example)
[![Build Status](https://dev.azure.com/ddubson0133/contract-testing-dotnetcore-example/_apis/build/status/ddubson.contract-testing-dotnetcore-example?branchName=main)](https://dev.azure.com/ddubson0133/contract-testing-dotnetcore-example/_build/latest?definitionId=2&branchName=main)
[![Maintainability](https://api.codeclimate.com/v1/badges/90e00e40f61b82d846cd/maintainability)](https://codeclimate.com/github/ddubson/contract-testing-dotnetcore-example/maintainability)

Contract testing example with two API consumers and one API provider using PactNET.

Run `ship-it.sh` to create and verify contracts between parties. Take a look for more info on parties
below in the [Scenario](#scenario) section.

## Scenario

- Provider: `AddressBook.API`
- Provider Verification: `AddressBook.API.Tests`
- Consumer 1: `AddressBook.API.Consumer1.Pact`
- Consumer 2: `AddressBook.API.Consumer2.Pact`

## Gotchas

- **Launching a Test server but no endpoints are loaded** When launching a test server in your
test cases with PactNet, we use Kestrel as a standalone Http server that hosts your provider, but
we register a `TestStartup` class instead of `Startup` in AddressBook.API. The Kestrel test server
does not automatically register the controllers in the main project so it is very important to make sure
that controllers are explicitly registered in `Startup.cs`. Refer to `ConfigureServices` method in `Startup.cs`
and point your attention to `AddApplicationPart(..)` method that makes sure the controllers are registered.

## TODO or what's not covered (yet)

- Contract Testing an OAuth-protected API
