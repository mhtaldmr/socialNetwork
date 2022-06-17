
# TP. Net Week 5

This project is an example of using RabbitMQ message queuing, Hangfire services and generating reports and emails.  
To be able to make the project Clean Architecture Design has been used.

### What I have used so far:
- Asp.Net Core Web API and ConsoleApp with `.Net6.0` framework.
- RabbitMQ server and packages. For more info about installing on windows check the [link!](https://www.rabbitmq.com/install-windows.html)
- Hangfire server packages and jobs.
- Mailkit for sending emails, ClosedXL for generating excel files.
- EntityFramworkCore as an ORM and Tools packages.
- MSSQL Server as an Database and SQLServer packages.
- Postman and Swagger used for tests.

## Requirements
- Creating a filter system for an endpoint like Paging, Filtering and Searching.
- Generate a message queue in one of the operations. (e.g. When creating a User)
- Create an event to Consume that message queue.
- Create a background service to get Current User List as Excel file and Email at 7.35am on weekdays only.

## Installation and Usage

- To get the project :
```
    git clone https://github.com/186-Teleperformans-Net-Bootcamp/hafta5-mhtaldmr.git
```
- To create the database first, in the `TP.Net.Hw.Infrastructure` folder :
```c
    update-database
```
- To start the project, in the `TP.Net.Hw.WebApi` and `TP.Net.Hw.Consumer` folders:
```c
    dotnet run
```
- "***dotnet restore***" command can be used to restore dependencies and tools inside the project.
-  The project can be directly started in VisualStudio by pressing '***F5***'.
- The port will be listenin on : https://localhost:7182

## Testing

**1. Filtering Example**

- For filtering  https://localhost:7182/messages url can be used. Filter options are;

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/hafta5-mhtaldmr/blob/main/images/filtering.png" alt="filtering" />

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

<img src="https://github.com/186-Teleperformans-Net-Bootcamp/hafta5-mhtaldmr/blob/main/images/consumer.png" alt="consumer" />

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
 
 <img src="https://github.com/186-Teleperformans-Net-Bootcamp/hafta5-mhtaldmr/blob/main/images/recurringjob.png" alt="recurringjob" />

**4. Email and Excel Report Example**

- The created excel report.
 
 <img src="https://github.com/186-Teleperformans-Net-Bootcamp/hafta5-mhtaldmr/blob/main/images/emailreport.png" alt="emailreport" />

- The sended email with excel attachment.

 <img src="https://github.com/186-Teleperformans-Net-Bootcamp/hafta5-mhtaldmr/blob/main/images/excelreport.png" alt="excelreport" />

---