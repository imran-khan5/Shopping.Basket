
# Freemarket FX – Shopping Basket Web API (CQRS, Clean Arhitecture, .NET 8)

Web API showing lightweight CQRS separation (Commands/Queries + Handlers) with a simple in-process mediator.
Storage is in-memory; no external database is required.

## Implemented API End Points
- POST /v1/baskets -> create a new basket (returns id)
- GET /v1/products -> list sample catalog items data (hard coded in solution)
Note: Other features (add/remove items, discount codes, shipping, totals) are outlined as future work to keep the scope aligned with the time limit.

## Architecture (Clean, CQRS-lite)
- **Shopping.Basket.API**: Minimal API, DI wiring, endpoints ('Program.cs')
- **Shopping.Basket.Application**: CQRS contracts/handlers, mediator, ports
  - Abstractions (ICommand/IQuery, handlers, IMediator, ports)
  - Commands (CreateBasket + handler)
  - Queries (GetProducts + handler)
  - Mediator (SimpleMediator)
- **Shopping.Basket.Domain**: Entities (Basket, BasketItem)
- **Shopping.Basket.Infrastructure**: In-memory adapters
  - Repositories (InMemoryBasketRepository)
  - Services (CatalogReadService)

## CQRS repository
- Endpoints call a Mediator which resolves and invokes CommandHandlers or QueryHandlers via DI.
- Commands: alter the state -> e.g. CreateBasket : ICommand<Guid> (implemented).
- Queries: read the state -> e.g. GetProducts : IQuery<IEnumerable<Product>> (implemented).
- A LoggingBehavior added but not implemented in pipeline.

- If we Swap to EF at later stage then we should not have to change endpoints, only handlers/stores needed  to change.

## Domain model
- Basket holds a list of BasketItems. Basket.New() creates a new basket.
- BasketItem uses property setters and static factories:
	- Create(sku, name, unitPriceExclVat, qty)
	- CreateDiscounted(sku, name, discountedUnitPriceExclVat, qty)
	- LinePriceExclVat is computed from the effective unit price X quantity.

## Prerequisites
- .NET 8 SDK

## How to build and run
# from the solution root
dotnet build

# run the API
cd Shopping.Basket.API
dotnet run

Open the Swagger UI at the HTTPS URL shown (usually https://localhost:7xxx/swagger).

