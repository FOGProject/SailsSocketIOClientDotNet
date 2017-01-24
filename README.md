# SailsSocketIOClientDotNet
A Sails Socket IO Client for Dot Net

[![Build status](https://ci.appveyor.com/api/projects/status/grxdg7xikb76cm10?svg=true)](https://ci.appveyor.com/project/jbob182/sailssocketioclientdotnet)

## Usage
SailsSocketIoClientDotNet has a similar api to those of sail's  [JavaScript client](https://github.com/balderdashy/sails.io.js).
It is built directly ontop of [SocketIoClientDotNet](https://github.com/Quobject/SocketIoClientDotNet).

```cs
using FOG.SailsSocketIoClientDotNet;

// For direct access to the underlying socket use client.Socket
var client = new SailsClient("http://localhost");

var response = await client.Get("/csrfToken", null); 
Console.WriteLine("Response code: " + response.statusCode);
Console.WriteLine("CSRF Token: " + response.Body["_csrf"]);

```
