# _N-tier .Net Core Blog Site Project_

## _Layers_
- Core: It is a generic layer that allows tools to be used in other projects.
- Entities: This layer contains database table classes and dto' classes created based on these classes.
- DataAccess: The layer where we do database operations.
- Business: The layer where we develop our business rules.
- WebAPI: This layer is the layer where we provide restful services communication.
 
## _Features_
- Repository Design Pattern
- Entity Framework Core Orm (SqlServer - PostgreSql)
- Autofac 
- Authentication(with Claim Extension)
- Json Web Token 
- Business Rules Const.
- Hashing and Verify hash
- IoC Container - External
- Result Const.
- Custom Extensions Middleware (Centralization)
- Cross Cutting Concerns
- Aspect Oriented Programing
- Memory Cache
- Fluent Validation
- Unit Of work
- Fluent API
- AutoMapper

## _Tables_
- Post
- Comment
- Category
- Contact
- User
- OperationClaim
- UserOperationClaim
- EmailParameter

## _Principles_
- Solid
- DRY (Dont Repeat Yourself)
