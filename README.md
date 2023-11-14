<img src="https://github.com/DenisSemko/CryptoTraceHub/assets/53062219/5744b16a-6c1a-4d84-a37b-9713dfda7b5c" alt="logo" title="logo" align="right" height="100" />


# CryptoTraceHub
> Go-to solution for staying up-to-date with the dynamic world of cryptocurrencies. With its intuitive design and powerful features, CryptoTraceHub simplifies the way you monitor cryptocurrencies prices.

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Architecture](#architecture)
* [Features](#features)
* [Screenshots](#screenshots)
* [Setup](#setup)
* [Usage](#usage)
* [Project Status](#project-status)
* [Contact](#contact)
* [License](#license)

## General Information
CryptoTraceHub is your all-in-one solution for cryptocurrency enthusiasts. Stay updated on crypto prices. 
Simplify your crypto journey with CryptoTraceHub today!

## Technologies Used
- Web Application - React.js
- Back-end: .NET 7, C#
- Containerization: Docker
- Database: PostgreSQL
- Third-party-api: CoinMarketCapApi
- Microservices
- Microservices Communication - RabbitMQ via MassTransit
- Unit Testing: xUnit
- Logging: Serilog, Seq

## Architecture
<img width="828" alt="Screenshot 2023-10-10 at 21 17 01" src="https://github.com/DenisSemko/CryptoTraceHub/assets/53062219/fd9ea179-3e15-40f7-8a89-ae3b04e8ffed">

## Features
- Get Listings with additional query parameters;
- Get Quotes with additional query parameters;
- Get Price Conversion.

## Screenshots
<p><i>Back-end</i></p>
<img width="1454" alt="Screenshot 2023-10-29 at 18 35 19" src="https://github.com/DenisSemko/CryptoTraceHub/assets/53062219/7589e138-7f5e-47b8-83e4-e93402ebdd03">


## Setup
Project is built locally and it uses SSL certificate to run the Web App securely.

Make sure you have installed and configured [docker](https://docs.docker.com/desktop/install/windows-install/) in your environment. After that, you need to run the below commands from the /src/ directory.

`docker-compose build`
`docker-compose up`

*Another Approach:*

You need to download this repository and run it using Visual Studio 2019 or newer version or any other IDE that is suitable for you.

You can run the Web application via installing all the dependencies with the command `npm install`.

> You need to make sure you have installed PostgreSQL & RabbitMQ locally or via Docker.

## Usage
You can choose how to run the project: locally with IDE or via Docker. Both approaches work as expected. <br/>
> **NOTE:** Make sure you've configured ApiKey and BaseUrl to use CoinMarketCap API.

## Project Status
_v1.0 has not been released yet_

## Contact
Created by [@dench327](https://www.linkedin.com/in/denis-semko-551b91191) - feel free to contact me!

© 2023

## License
> You can check out the full license [here](https://github.com/DenisSemko/CryptoTraceHub/blob/master/LICENSE).
This project is licensed under the terms of the MIT license.
