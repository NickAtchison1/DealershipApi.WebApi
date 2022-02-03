# DealershipApi.WebApi
## First Thing's First
[Link To Trello Board](https://trello.com/b/dl7IIET1/dealershipapi
)
>This application is a simulation of a database owned by a car dealership company. It allows one to view multiple unique dealerships owned by the company, what cars they have in stock, who works at them, and several other features, including individual car details, customers, and transactions. It also includes multiple authorization clearances that simulate different level employees having different access to certain features in the database, such as creating new transactions, transferring cars between dealerships, and creating new employees.

## To Run the application, do the following:
1. Clone Repo 
2. Run `update-database` in the Package Manager Console.
3. See the ASP.NET Web API Help Page for list of endpoints
4. Read the rest of the README

**The applications comes with seeded data once the `update-database` command is executed**

**This is not a production application, all users in the database have been seeded with the following password: `Password1*`**

| UserName | Role | DealershipId |
|:---      | :---:|  ---:        |
|Nick      | Admin| 2            |
|Lou    | Admin| 1         |
|Andrew| Admin| 4           |
|Manager|Manager|3 |
|AnotherManager|Manager| 2|
Sales|Sales|1|       |
Sales1|Sales|2|     |

****Newly created users will autmatically be assinged to the `Sales` role.****

### Run the below query in your sql editor of choice to get a list of all users and roles ###
```
select 
a.id
,a.UserName
,STRING_AGG(ir.Name, ',') as ListOfRoleNames
,a.DealershipId
from ApplicationUser a
join IdentityUserRole iur 
on a.Id = iur.UserId
join IdentityRole ir 
on iur.RoleId = ir.Id
GROUP BY 
a.id
,a.UserName
,ir.Name
,a.DealershipId
```
