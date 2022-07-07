
# Social Network Project

This project is an example of using RabbitMQ message queuing, Caching with Redis, JWT tokens, Hangfire services and generating reports and emails..  
To be able to make the project Clean Architecture Design has been used.

### What I have used so far:
- Asp.Net Core Web API and ConsoleApp with `.Net6.0` framework.
- RabbitMQ server and packages. For more info about installing on windows check the [link!](https://www.rabbitmq.com/install-windows.html)
- Hangfire server packages and jobs.
- Mailkit for sending emails, ClosedXL for generating excel files.
- EntityFramworkCore as an ORM and Tools packages.
- MSSQL Server as an Database and SQLServer packages.
- JWT token, Identity packages used for Authentication.
- InMemoryCache and StackExchanceRedis Caching packages.
- Postman and Swagger used for tests.

## Requirements
- Creating a filter system for an endpoint like Paging, Filtering and Searching.
- Generate a message queue in one of the operations. (e.g. When creating a User)
- Create a service to Consume that message queue.
- Create and Authentication system based on JWT.
- Create caching mechanism with both InMemoryCache and DistributedCahce.
- Create a background service to get Current User List as Excel file and send that in Email at 7.35am on weekdays only.

## Installation and Usage

- To get the project :
```
    git clone https://github.com/mhtaldmr/socialNetwork.git
```
- To create the database first, in the `TP.Net.Hw.Infrastructure` folder :
```c
    update-database
```
- To start the project, **MULTIPLE STARTUP** must be selected with `TP.Net.Hw.WebUI` and `TP.Net.Hw.Consumer` or type in those folders:
```c
    dotnet run
```
- "***dotnet restore***" command can be used to restore dependencies and tools inside the project.
-  The project can be directly started in VisualStudio by pressing '***F5***'.
- The port will be listenin on : https://localhost:7182

## Testing

**1. Filtering Example**

- For filtering  https://localhost:7182/messages url can be used. Filter options are;

<img src="https://github.com/mhtaldmr/socialNetwork/blob/main/images/filtering.png" alt="filtering" />

- For SortBy option, 3 different columns can be selected:  ***messagebody***, ***createdAt***, ***Id***
- The paging details will be sending in the header as: ***x-pagination***.

**2. Message Queueing Example**

- For observing the message queues, connections, exchanges http://localhost:15672 ***RabbitMQ UI*** can be used.
- For generating a user  https://localhost:7182/accounts/signup url can be used.
- After generating a user, a mesage will be publising with that user's info. Also, queueName and routingKey options must be spesified in the service parameters.
```c
    //Publishing the user when a new user is created!.
    _publisherService.Publish(user: newUser, queueName: "direct.email", routingKey: "email1");
```
- Consumer will have the same queue name and connection, then it will consume the message immediately.

<img src="https://github.com/mhtaldmr/socialNetwork/blob/main/images/consumer.png" alt="consumer" />

**3. Hangfire Job Example**
 
- For observing how the hangfire works, https://localhost:7182/hangfire ***Hangfire UI*** will be very helpful.
- According to requirements, the job for sending email, First the excel report must be extracted. Thus, in the email service, calling the excel report service and await for the result of it. Then attach the file, email can be send.
```c
    public async Task SendEmailReport()
    {
        //Calling the excel report export service!
        await _reportService.GetUsersExcelReport();
        ...
    }
```
- The generated recurring job  can be seen in this Hangfire UI.
 
 <img src="https://github.com/mhtaldmr/socialNetwork/blob/main/images/recurringjob.png" alt="recurringjob" />

**4. Email and Excel Report Example**

- The created and sended Email.
 
 <img src="https://github.com/mhtaldmr/socialNetwork/blob/main/images/emailreport.png" alt="emailreport" />

- The generated excel files in the file explorer.

 <img src="https://github.com/mhtaldmr/socialNetwork/blob/main/images/excelreport.png" alt="excelreport" />

- The generated Excel file content.

<img src="https://github.com/mhtaldmr/socialNetwork/blob/main/images/excel.png" alt="excel" />

**5. JWT Example**

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


**6. Memory Cache**
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