`docker run -d -p 5672:5672 -p 5671:5671 rabbitmq`

or with Web-UI

`docker run -d -p 5672:5672 -p 5671:5671 -p 15672:15672 rabbitmq:management`

Access Web-UI: [http://localhost:15672](http://localhost:15672) -- Username: `guest` Password: `guest`
