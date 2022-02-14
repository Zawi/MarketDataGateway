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
### Diagrams

#### Class diagram
``` mermaid
classDiagram
    class MarketContribution {
        +Id int
        +Date Date
        +MarketDataType string
        +UserId string
        +RegulationFramework string
    }
    
    class MarketData {
        +InstrumentId string
        +Price double
        +Size double
    }

    class MarketDataSide{
        <<enumeration>>
        Bid
        Ask
    }
    MarketContribution *-- MarketData: +MarketData
    MarketData <|-- FxQuote
    MarketData *-- MarketDataSide: +Side

    class ValidationResponse {
        +Id string
    }

    class ValidationResponseStatus {
        <<enumeration>>
        SUCCESS
        ERROR
    }
    ValidationResponse *-- ValidationResponseStatus: +Status
```

#### Sequence diagram
##### Adding a contribution
``` mermaid
sequenceDiagram
    actor User
    participant MarketContributionController
    participant MarketContributionService
    participant MarketValidationService
    participant MarketContributionRepository
    participant ApplicationDbContext
    User->>MarketContributionController: POST FxQuote
    MarketContributionController->>MarketContributionService: AddContribution(userId, "FxQuote", marketData)
    MarketContributionService->>MarketValidationService: ValidateContribution(contrib)
    MarketValidationService-->>MarketContributionService: ValidationStatus
    alt SUCCESSFUL
        MarketValidationService->>MarketContributionRepository: AddContribution(contrib)
        MarketContributionRepository->>ApplicationDbContext: MarketContributions.Add(contribEntity)
        MarketContributionRepository->>ApplicationDbContext: Save()
        MarketContributionService-->>MarketContributionController: true
        MarketContributionController-->>User: HTTP OK
    else ERROR
        MarketContributionService-->>MarketContributionController: false
        MarketContributionController-->>User: HTTP Bad Request
    end
```

### Application structure
This project is based on the ASP.NET MVC+Angular template provided by Visual Studio.
The authentication mechanism already was implemented.

The app is divided into the following separate folders:
- Models: to define object models used in the app
- Controllers: to set up endpoints
- Services: to get and manipulate data
- Repositories: to retrieve data from data sources
- Data: to set up database entities, context and migrations
- ClientApp: Angular frontend code in TypeScript(see `/src/app/market-contributions/`)

The `Program.cs` file defines the application configuration and dependency injection.

The app can be built by pushing to Github with Github actions defined in `.github/workflows/`.

### API Endpoints
1. `GET /api/marketcontributions` returns the past contributions of the user
2. `POST /api/fxquotes` allows the user to contribute an FX quote with the currency pair,
price, size, and side (bid/ask)

### Assumptions and decisions
- The API for market contributions is available for logged-in users with a valid authorization token
    (user registration is open and does not require a real email address)
- The requested market contributions are ones created by the logged user
- The user email is used as identifier for simplification
- The market data represents a price for an instrument, bid or ask, with a size.
It can be extended for specific market data types, for different implementations, validations, etc...
- Only FX quote contributions are implemented. An endpoint has been created only for this type of data,
but a general case one can be set up instead, to handle multiple or any types of data if the format stays consistent
(`POST /api/marketcontributions`)
- The market contribution is an object that includes the market data quote object.
It could be made into a generic class to have it target specific data types
- The market data class as a separate object from the contribution class can be considered unnecessary
in the scope of this exercise (outside of handling the API request), but could be useful for further use cases
- The regulatory framework for a contribution depends on the market data type and 
is defined by the market contribution gateway instead of being provided by the user or 
being inferred by the validation service
- Some validation has been implemented for the FX quote type at the model level.
More can be done with the validation service

### Additional features to be implemented
- Refine inputs and outputs for the API endpoints according to real business needs
- Add more details for securities handling
- Accept more security types
- Set up more contribution types for the securities: Market Order, Limit Order, Iceberg...
- Add a choice for the target exchange, OTC...
- Allow business clients to see other market contributions
- Implement price improvement strategies depending on the business client

### Additional technical infrastructure
- Validation can be done on a seperate application and server for decoupling
- Set up DevOps pipelines with TeamCity or Jenkins for building, deployment, testing
- Implement unit tests for critical computation processes
- Use Specflow to test with Gherkin and BDD
- Add documentation with Swagger
- Set up persistance with an external database
- Use monitoring solutions such as ElasticSearch