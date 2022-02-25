# jwt
A sample ASP.NET Core 6 Jwt Token Authentication with auth api application and separate api application

If you set you environment to run both API projects you can use the Server to create a Jwt token and can the make a request with or without the token to the client.  If the token is valid you will receive a decoded breakdown.

## Rider
Run both projects by doing the following

![Compound Configuration](../../readme/compound.png)

Run | Edit Configurations

+ Add New Configuration

Select Compound 

Give it a sensible name for example: 'Run Both' then add both the server and client projects

Ensure that the run configuration is selected then start running
