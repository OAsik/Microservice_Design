# Microservice_Design
It has been a long time since I commit a new repository to my account and I'm not sure if anyone even reading these readme files. So, I decide to write this one in a more 
diary-ish way rather than a boring and professional one. This is my fourth year in my IT career and feeling quite satisfied with the way I have achieved by looking my
first repositories. The last thing I did before writing this _readme_ file was removing their pins from my main profile :)

So, after working with so many monolith designs I come up with an idea of making a nice and little microservice for myself. If you are a newbie (but a veteran in 
the heart of course!) to Microservice architecture, you will definitely find this repo very interesting.

Okay, lets start with the concept of these services. I imagine these services as  basic flight schedulers. What do you need for a flight schedule? A flight course
for sure, a handful of crew, and two pilots (talking about regular flights here). I have two pilot friends that travelling around the world with some amazing
people as their job while I'm writing this wonderful _readme_ file. Thay gave the idea of my concept and definitely better than following old catalog-product-order trios.

I'm not going in too much detail with explaining each REST API service. They are just ordinary services making all-loving CRUD operations. The only thing that should be
highlighted is they are built with CQRS principle. If someone asks you _Why CQRS_ in one day, just tell them _it is a great solution to seperate command (post, put, and delete)
and queries (read, or find) from eachother_. Imagine that you are using EF/EF Core as your ORM tool and your linq expressions are going way too crazy by joining or
fetching too many rows from different tables. By CQRS design, you can use an ORM for your commands (like EF) and a _different_ ORM for your queries (say, Dapper). The
power of CQRS design comes from this seperation. Check out my flight.api for practical examples.

And, we have completed our microservices already. But, we are far from completing. You want to deploy your project, and definitely don't want to deploy it by building
the project in release mode and than copy-pasting the files to hosing server (definitely not the way I still follow in the office T_T ). At this moment Docker comes your help.
You can even use Docker Desktop if your OS is Home edition. Just be sure your Windows version is higher than 19041 (by pressing win + R and then type _winver_). More 
details are here: https://docs.docker.com/desktop/windows/install/

After installing Docker desktop you can create Docker files very easily with the help of Visual Studio. Just right-click one of the web projects and 
choose _add container orchestration support_. You just want to adjust `docker-compose.override.yml` file. Individual container definitions will be like this
```
pilotdb
  ports:
    -80
```
You want to that DB definition as below
```
pilotdb:
    container_name: pilotdb                        #just to clarify your container identity
    environment:                                   #if you establish a secure connection with a user id and a password, state these under environment along with the database name
      - POSTGRES_USER=admin
      - POSTGRES_PASSWORD=admin1234
      - POSTGRES_DB=PilotDb
    restart: always
    ports:
      - "5432:5432"                                #port number that official image use. You can check these kind of details from images' Docker Hub sites. 5432 is used by PostgreSQL
    volumes:
      - postgres_data:/var/lib/postgresql/data     #volume is an important feature if you want persistant data even after database container is removed. They exist on the file's host system. Do not forget to define your volume statements at the bottom of docker-compose.yml file too     
```
The last warning I want to make about your Docker files is that don't forget to update them if you have changed `.csproj` file _after_ you have created Docker file (by
typically adding another project reference).

As now you are a Docker-pro too, it is time to make some of our services communicate with each other. For that purpose you have two different way. First one is to
make them communicate synchronously by adding connected service. I chose asynchronous communication by using RabbitMQ and MassTransit. Have a look at `CheckoutStaff` 
end-point on `flight.api` and consumer classes named `PilotChecoutConsumer` on `pilot.api` and `CrewChecoutConsumer` on `crew.api`.

Last but not least, you need a gateway to place it between user requests and service end-points. Luckly for .Net developers that we have Ocelot API Gateway. Ocelot 
is an open source, light-weight gateway solution for people using .NET running a micro services / service orientated architecture that need a unified point of 
entry into their system.  By using an API gateway, you can chose the end-points which you want to expose to your clients and hide the rest of them from your 
clients' curious requests.

I think that's all. I would like to finish with a `TO-DO` list just like I did on my Flutter app repo, but not much thing left I want to implement to this 
example project. Maybe a BFF pattern after (actually, if) I develop an Angular app which consumes these services.
