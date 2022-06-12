
# TP. Net Week 4

This project is an example of using JWT Security Tokens, EF.Identity Package and Memory Caching Packages.
To be able to make the project Clean Architecture Design has been used.

### What I have used so far:
- Asp.Net Core Web API with `.Net6.0` framework.
- EntityFramworkCore as an ORM and Tools packages.
- MSSQL Server as an Database and SQLServer packages.
- JWT token, Identity packages used for Authentication.
- InMemoryCache and StackExchanceRedis Caching packages.
- AutoMapper for mapping dtos.
- Postman and Swagger used for tests.

## Requirements
- Creating a SocialNetworkDB by CodeFirst approach.
- Use EF6 and Identity package.
- Create and Authentication system based on JWT.
- Create caching mechanism with both InMemoryCache and DistributedCahce.

## Installation and Usage

- To get the project :
```
    git clone https://github.com/186-Teleperformans-Net-Bootcamp/hafta4-mhtaldmr.git
```
- To create the database first, in the `TP.Net.Hw4.Infrastructure` folder :
```c
    update-database
```
- To start the project, in the `TP.Net.Hw4.WebApi` folder:
```c
    dotnet run
```
- The port will be listenin on : https://localhost:7182

## DB Design

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/hafta4-mhtaldmr/blob/main/images/social.png" alt="design" />

## Endpoints

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/hafta4-mhtaldmr/blob/main/images/endpoints.png" alt="endpoints" />

## Testing
**1. JWT Example**

- To test the project, first a user must be created. After signing up a token generated. 
```c
    {   "userName": "string",
        "firstName": "string",
        "lastName": "string",
        "email": "string",
        "password": "string"  }
```
- To be able to login, a user and password entered correctly. 
```c
    {   "email": "string",
        "password": "string"  }
```


- With the token  in postman, by using `../users/authorization` endpoint, api can tested.
- Without the right token, user will get Unautorized response.
- To create a Refresh Token, a DTO used to have it inside the Access Token
```c
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
``` 
- To test the Token in the Postman, in Authorization, token must be inserted in the Bearer Token section.
- To test the refresh token, `../accounts/refreshToken` endpoint can be tested.

**2. Memory Cache**
- To test the Memory Cache, two endpoint is exist in the swagger. In postman the performane can be tested.
- To be able to use Redis Cache Server, it needs to be installed.
- For windows you can check this [guide!](https://redis.io/docs/getting-started/installation/install-redis-on-windows/)
- Redis is using datas as bytes, thus JsonSerializer must be used.
```c 
    var seralizedUserDtoToSet = JsonSerializer.Serialize(userDto);
    var cacheOptions = DistributedCacheOptions.CacheOptions();
    _distributedCache.Set(_cacheKeyDistributed, Encoding.UTF8.GetBytes(seralizedUserDtoToSet), cacheOptions);
```


---