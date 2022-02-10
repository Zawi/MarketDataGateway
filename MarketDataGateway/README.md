# .Net Challenge

Building a Market data contribution Gateway.

## Exercise

### Background
Market data distribution is at the heart of every financial system from pre-trade (pricing) to post-trade
(risks computation). It is important to have a system that can collect, store, and return these for
different scenarios.

We would like to build a Market data contribution gateway, an API based application that will allow
users to store, retrieve and distribute these market data (e.g.: financial quotes such as FxQuote, Swap’s
level, etc.) for different scenario.

Contributing a market data involves multiple steps and entities:
Business users -> Market Data contribution gateway -> Market Data Validation

1. Business users -> Individual who is contributing the market quote.
2. Market data contribution gateway -> Responsible for validating request by requesting the
market data validation service, storing market data, and returning contribution responses.
3. Market Data validation service: Allows to check the market data contribution rights, format
(example: Negative FxQuote), legal auditing (Financial regulation framework validation such as
MIFID, etc.) and reply with an appropriate response code.

We will be building the Market data contribution gateway and only simulating the Market data
validation service component in order to allow us to fully test the contribution flow.

### Requirements
The product requirements for this initial phase are the following:

1. Business users should be able to process a market data contribution through the Market data
contribution gateway and receive either a successful or unsuccessful response.

2. Business users should be able to retrieve the details of a previously contributed market data.
The next section will discuss each of these in detail.

### Process a market data contribution
The market data contribution gateway will need to provide business users with a way to process a
contribution. To do this, Business users should be able to submit a request to the gateway. A
contribution request should include appropriate fields such as market data type and the market data
itself. Market data could be of any type and structure but to keep it simple the contribution should be
able to process at least Fx quotes (ex: FxQuote, EUR/USD, bid, ask).

### Note: Simulating the validation
In your solution you should simulate or otherwise mock the validation part. This component should be
able to be switched out for a real validation service once we move to production. We should assume
that a validation service returns a unique identifier and a status that indicates whether the validation
was successful or not.

### Deliverables
Build and API that allows a business user.
a. To process a market data contribution through your Market data contribution Gateway
b. To retrieve details of a previously made contributions.

### Considerations
Include whatever documentation/notes you feel is appropriate, this should include some details of
assumptions made, areas you fell could be improved etc.

### Extra mile bonus points (not a requirement)
In addition to the above, time permitting, consider the following suggestions for taking your
implementation a step further:
- Application logging
- Application metrics
- Containerization
- Authentication
- API client
- Build script / CI
- Performance testing
- Encryption
- Data storage
- Anything else you feel may benefit your solution from a technical perspective.

## Implementation

### Application structure

This project is based on the ASP.NET MVC+Angular template provided by Visual Studio.

### Assumptions
- A contribution represents a price for an instrument, bid or ask, with a size
- The regulatory framework for a contribution depends on the market data type and 
is defined by the market contribution gateway instead of provided by the user or 
defined by the validation service

### Additional features to be implemented
- Add more details for securities handling
- Accept more security types
- Set up more contribution types for the securities: Limit Order, Iceberg...
- Allow business clients to see other market contributions
- Implement price improvement strategies depending on the business client

### Additional technical infrastructure
- Set up DevOps pipelines with TeamCity or Jenkins for building, deployment, testing
- Use Specflow to test with Gherkin and BDD
- Set up persistance with a database
- Use monitoring solutions such as ElasticSearch